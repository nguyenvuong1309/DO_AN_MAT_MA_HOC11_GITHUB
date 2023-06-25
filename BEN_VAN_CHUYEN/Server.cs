using iText.Samples.Signatures.Chapter02;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BEN_VAN_CHUYEN
{
    public partial class Server : UserControl
    {
        public string FILE_PATH;
        string KEY_STRING = "CE16A8E87AB2C9C7023DED4D69EEFECB838D51ECD4BDCE2B43B94923EF3CB2A9";
        string IV_STRING = "FA22F0CF07B6F6A3000AA9A77CD7DA4E";

        static MongoClient mongoClient = new MongoClient("mongodb+srv://21522809:21522809@cluster0.m7a6l0t.mongodb.net/?retryWrites=true&w=majority");
        static IMongoCollection<Contract> contractCollection = mongoClient.GetDatabase("Contract").GetCollection<Contract>("Contract");

        private TcpListener listener;
        private TcpClient client;
        private SslStream sslStream;
        private Thread receiveThread;
        public Server()
        {
            InitializeComponent();
        }

        private void stop_Click(object sender, EventArgs e)
        {
            try
            {
                start.Enabled = true; // Disable the start button while server is running

                // Create a new thread to start the server and handle client connections
                receiveThread = new Thread(StartServer);
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            start.Enabled = false; // Disable the start button while server is running

            // Create a new thread to start the server and handle client connections
            receiveThread = new Thread(StartServer);
            receiveThread.Start();
        }

        private void send_Click(object sender, EventArgs e)
        {
            string message = textBox1.Text;

            if (!string.IsNullOrEmpty(message))
            {
                SendMessage(message);
                //inputTextBox.Clear();
            }
        }
        private void StartServer()
        {
            try
            {
                // Start TCP listener
                listener = new TcpListener(IPAddress.Loopback, Int32.Parse(port.Text));
                listener.Start();

                // Wait for client connection
                client = listener.AcceptTcpClient();

                // Get client stream
                var stream = client.GetStream();

                // Wrap client in SSL stream
                sslStream = new SslStream(stream, false);

                // Read self-signed certificate
                var certificate = new X509Certificate2("..\\..\\Signature\\server.pfx", "password");

                // Authenticate server with self-signed certificate, false (for not requiring client authentication), SSL protocol type
                sslStream.AuthenticateAsServer(certificate, false, System.Security.Authentication.SslProtocols.Default, false);

                // Continuously receive and display data from the client
                while (client.Connected)
                {
                    byte[] buffer = new byte[client.ReceiveBufferSize];
                    int bytesRead = sslStream.Read(buffer, 0, client.ReceiveBufferSize);
                    string receivedMessage = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    DisplayMessage(receivedMessage);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }
        private void DisplayMessage(string message)
        {
            if (textBox2.InvokeRequired)
            {
                // Invoke the method on the UI thread
                Invoke(new Action<string>(DisplayMessage), message);
            }
            else
            {
                // Append the message to the textbox
                textBox2.AppendText(message + Environment.NewLine);
            }
        }
        private void Disconnect()
        {
            // Close the SSL stream, TCP client, and listener
            sslStream?.Close();
            client?.Close();
            listener?.Stop();
            receiveThread?.Join();

            start.Enabled = true; // Enable the start button
        }
        private void SendMessage(string message)
        {
            try
            {
                byte[] buffer = Encoding.ASCII.GetBytes(message);
                sslStream.Write(buffer, 0, buffer.Length);
                sslStream.Flush();
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                MessageBox.Show("An error occurred while sending the message: " + ex.Message);
            }
        }

        private void choosefile_Click(object sender, EventArgs e)
        {
            string filename = "";
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "Pdf File|*.pdf";
                if (opf.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(opf.FileName))
                    {
                        filename = opf.FileName;
                        this.pdfViewer1.LoadFromFile(opf.FileName);
                        FILE_PATH = filename;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Sign_Click(object sender, EventArgs e)
        {
            Sign_verify.Sign();
        }

        private void uploadToDb_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] KEY_BYTE = Aes.ConvertStringToByte(KEY_STRING);
                byte[] IV_BYTE = Aes.ConvertStringToByte(IV_STRING);
                byte[] filePdfByte = File.ReadAllBytes(FILE_PATH);
                byte[] encryptedText = Aes.encrypt_Byte(filePdfByte, KEY_BYTE, IV_BYTE);
                string hexString = BitConverter.ToString(encryptedText).Replace("-", string.Empty);

                List<string> list = new List<string>();
                list.Add("ben ban");
                List<string> arrayKey = new List<string>();
                arrayKey.Add("key");
                List<string> arrayIv = new List<string>();
                arrayIv.Add("iv");

                Contract c = new Contract(hexString, list, DateTime.Now, arrayKey, arrayIv);
                contractCollection.InsertOne(c);
                MessageBox.Show("Success add data to mongodb");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
