using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BEN_TRUNG_GIAN
{
    public partial class Server : UserControl
    {
        private TcpListener tcpListener;
        private Thread listenThread;
        private List<TcpClient> connectedClients = new List<TcpClient>();

        string KEY_STRING = "CE16A8E87AB2C9C7023DED4D69EEFECB838D51ECD4BDCE2B43B94923EF3CB2A9";
        string IV_STRING = "FA22F0CF07B6F6A3000AA9A77CD7DA4E";
        string FILE_PATH;

        static MongoClient mongoClient = new MongoClient();
        static IMongoDatabase db = mongoClient.GetDatabase("contractDB");
        static IMongoCollection<Contract> collection = db.GetCollection<Contract>("contract");

        public Server()
        {
            InitializeComponent();
        }
        private void start_Click(object sender, EventArgs e)
        {
            try
            {
                listenThread = new Thread(new ThreadStart(ListenForClients));
                listenThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void send_Click(object sender, EventArgs e)
        {
            try
            {
                string data = textBox1.Text;
                if (connectedClients.Count > 0)
                {
                }
                else
                {
                    MessageBox.Show("don't have client");
                }
                foreach (TcpClient client in connectedClients)
                {
                    NetworkStream clientStream = client.GetStream();

                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    clientStream.Write(buffer, 0, buffer.Length);
                    clientStream.Flush();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void stop_Click(object sender, EventArgs e)
        {
            try
            {
                tcpListener.Stop();

                // Close all client connections
                foreach (TcpClient client in connectedClients)
                {
                    client.Close();
                }
                connectedClients.Clear();

                // Any other necessary cleanup steps

                MessageBox.Show("Server stopped.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ListenForClients()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, Int32.Parse(port.Text));
                tcpListener.Start();
                MessageBox.Show("Server started. Listening for clients...");

                while (true)
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                    clientThread.Start(client);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void HandleClientComm(object client)
        {
            try
            {
                TcpClient tcpClient = (TcpClient)client;
                NetworkStream clientStream = tcpClient.GetStream();
                connectedClients.Add(tcpClient);

                byte[] message = new byte[4096];
                int bytesRead;

                while (true)
                {
                    bytesRead = 0;

                    try
                    {
                        bytesRead = clientStream.Read(message, 0, 4096);
                    }
                    catch
                    {
                        break;
                    }

                    if (bytesRead == 0)
                    {
                        break;
                    }

                    string data = Encoding.ASCII.GetString(message, 0, bytesRead);

                    // Handle the received data here, such as updating UI or sending a response

                    // Display the received data in the textbox
                    DisplayMessageInTextBox(data);
                }

                tcpClient.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DisplayMessageInTextBox(string message)
        {
            try
            {
                if (textBox2.InvokeRequired)
                {
                    textBox2.Invoke(new Action<string>(DisplayMessageInTextBox), new object[] { message });
                }
                else
                {
                    textBox2.AppendText(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            try
            {
                string savePath = "..\\..\\Signature\\Contract.pdf";
                byte[] KEY_BYTE = Aes.ConvertStringToByte(KEY_STRING);
                byte[] IV_BYTE = Aes.ConvertStringToByte(IV_STRING);
                string hex = textBox2.Text;


                byte[] fileByte = Aes.ConvertStringToByte(hex);


                byte[] fileDecrypt = Aes.decrypt_Byte(fileByte, KEY_BYTE, IV_BYTE);
                File.WriteAllBytes(savePath, fileDecrypt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void get_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] KEY_BYTE = Aes.ConvertStringToByte(KEY_STRING);
                byte[] IV_BYTE = Aes.ConvertStringToByte(IV_STRING);
                File.ReadAllBytes(FILE_PATH);
                byte[] fileData = File.ReadAllBytes(FILE_PATH);
                byte[] FILE_ENCRYPT = Aes.encrypt_Byte(fileData, KEY_BYTE, IV_BYTE);
                string hex = BitConverter.ToString(FILE_ENCRYPT).Replace("-", "");
                textBox1.Text = "";
                textBox1.Text = hex;
                MessageBox.Show("done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void upload_to_db_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] KEY_BYTE = Aes.ConvertStringToByte(KEY_STRING);
                byte[] IV_BYTE = Aes.ConvertStringToByte(IV_STRING);
                byte[] filePdfByte = File.ReadAllBytes(FILE_PATH);
                byte[] encryptedText = Aes.encrypt_Byte(filePdfByte, KEY_BYTE, IV_BYTE);
                string hexString = BitConverter.ToString(encryptedText).Replace("-", string.Empty);
                Contract c = new Contract(hexString);
                collection.InsertOneAsync(c);
                MessageBox.Show("Success add data to mongodb");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
