using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iText.Samples.Signatures.Chapter02;
using System.Collections.ObjectModel;
using MongoDB.Driver;

namespace BEN_NGAN_HANG
{
    public partial class Server : UserControl
    {
        byte[] KEY_BYTE = new byte[32];
        byte[] IV_BYTE = new byte[16];
        string FILE_PATH = "";
        private TcpListener tcpListener;
        private Thread listenThread;
        private List<TcpClient> connectedClients = new List<TcpClient>();


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

                using (ECDiffieHellmanCng DH = new ECDiffieHellmanCng())
                {
                    DH.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                    DH.HashAlgorithm = CngAlgorithm.Sha256;
                    byte[] publicKey_A = DH.PublicKey.ToByteArray();


                    TcpListener listener = new TcpListener(IPAddress.Any, 50505);
                    listener.Start();
                    TcpClient client_s = listener.AcceptTcpClient();
                    NetworkStream stream = client_s.GetStream();

                    byte[] publicKey_B = new byte[140];
                    stream.Read(publicKey_B, 0, publicKey_B.Length);

                    // Gửi phản hồi về client
                    stream.Write(publicKey_A, 0, publicKey_A.Length);


                    Aes aes = new AesCryptoServiceProvider();
                    byte[] IV = aes.IV;
                    stream.Write(IV, 0, IV.Length);

                    CngKey bob = CngKey.Import(publicKey_B, CngKeyBlobFormat.EccPublicBlob);
                    byte[] shared_Key = DH.DeriveKeyMaterial(bob);
                    client_s.Close();
                    listener.Stop();

                    IV_BYTE = IV;
                    KEY_BYTE = shared_Key;
                }
                TcpClient tcpClient = (TcpClient)client;
                NetworkStream clientStream = tcpClient.GetStream();
                connectedClients.Add(tcpClient);

                byte[] message = new byte[4096];
                int bytesRead;
                //string data = "";
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
                    //MessageBox.Show("Received from client: " + data);

                    // Handle the received data here, such as updating UI or sending a response

                    /*// Send a response back to the client
                    byte[] response = Encoding.ASCII.GetBytes("Message received by server");
                    clientStream.Write(response, 0, response.Length);
                    clientStream.Flush();*/

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
                string savePath = "..\\..\\Signature\\contract.pdf";
                string hex = textBox2.Text;


                byte[] fileByte = AES.ConvertStringToByte(hex);


                byte[] fileDecrypt = AES.decrypt_Byte(fileByte, KEY_BYTE, IV_BYTE);
                File.WriteAllBytes(savePath, fileDecrypt);
            }
            catch(Exception ex)
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

                File.ReadAllBytes(FILE_PATH);
                byte[] fileData = File.ReadAllBytes(FILE_PATH);
                byte[] FILE_ENCRYPT = AES.encrypt_Byte(fileData, KEY_BYTE, IV_BYTE);
                string hex = BitConverter.ToString(FILE_ENCRYPT).Replace("-", "");
                textBox1.Text = "";
                textBox1.Text = hex;
                MessageBox.Show("done");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Sign_Click(object sender, EventArgs e)
        {
            SignPDF.Sign();
        }

        private void upload_to_db_Click(object sender, EventArgs e)
        {
            try
            {

                byte[] filePdfByte = File.ReadAllBytes(FILE_PATH);
                byte[] encryptedText = AES.encrypt_Byte(filePdfByte, KEY_BYTE, IV_BYTE);
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

        private void Server_Load(object sender, EventArgs e)
        {

        }
    }
}
