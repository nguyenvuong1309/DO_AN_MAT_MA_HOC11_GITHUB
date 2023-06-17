using iText.Samples.Signatures.Chapter02;
using MongoDB.Driver;
using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BEN_NGAN_HANG
{
    public partial class Client : UserControl
    {
        private TcpClient tcpClient;
        private NetworkStream clientStream;
        public string FILE_PATH;
        byte[] KEY_BYTE = new byte[32];
        byte[] IV_BYTE = new byte[16];


        static MongoClient mongoClient = new MongoClient();
        static IMongoDatabase db = mongoClient.GetDatabase("contractDB");
        static IMongoCollection<Contract> collection = db.GetCollection<Contract>("contract");


        public Client()
        {
            InitializeComponent();
        }

        private void connect_Click(object sender, EventArgs e)
        {
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(ip.Text, Int32.Parse(port.Text));
                clientStream = tcpClient.GetStream();
                MessageBox.Show("connect to server");
                //LogMessage("Connected to server");

                // Start a new thread to listen for incoming data from the server
                Thread receiveThread = new Thread(ReceiveDataFromServer);
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //LogMessage("Error connecting to server: " + ex.Message);
            }
        }
        private void ReceiveDataFromServer()
        {
            try
            {
                
                while (true)
                {
                    
                    byte[] buffer = new byte[4096];
                    int bytesRead = clientStream.Read(buffer, 0, buffer.Length);
                    string receivedData = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    //LogMessage("Received data from server: " + receivedData);

                    // Display the received data in the textbox
                    DisplayMessageInTextBox(receivedData);
                }
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
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                
                if (clientStream != null)
                {
                    clientStream.Write(buffer, 0, buffer.Length);
                    clientStream.Flush();

                    //LogMessage("Sent data to server: " + data);
                }
                else
                {
                    MessageBox.Show("not connect to server");
                }

                /*// Receive a response from the server
                byte[] response = new byte[4096];
                int bytesRead = clientStream.Read(response, 0, 4096);
                string responseData = Encoding.ASCII.GetString(response, 0, bytesRead);
                MessageBox.Show("Received response from server: " + responseData);
                //LogMessage("Received response from server: " + responseData);

                // Display the response in the textbox
                DisplayMessageInTextBox(responseData);*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //LogMessage("Error sending data to server: " + ex.Message);
            }
        }
        private void DisplayMessageInTextBox(string message)
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

        private void stop_Click(object sender, EventArgs e)
        {
            try
            {
                tcpClient.Close();
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
                using (ECDiffieHellmanCng DH = new ECDiffieHellmanCng())
                {
                    DH.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                    DH.HashAlgorithm = CngAlgorithm.Sha256;
                    byte[] publicKey_A = DH.PublicKey.ToByteArray();


                    TcpClient client_s = new TcpClient("10.0.129.87", 50505);
                    NetworkStream stream = client_s.GetStream();

                    stream.Write(publicKey_A, 0, publicKey_A.Length);

                    byte[] publicKey_B = new byte[140];
                    stream.Read(publicKey_B, 0, publicKey_B.Length);

                    byte[] IV = new byte[16];
                    stream.Read(IV, 0, IV.Length);

                    CngKey bob = CngKey.Import(publicKey_B, CngKeyBlobFormat.EccPublicBlob);
                    byte[] shared_Key = DH.DeriveKeyMaterial(bob);

                    client_s.Close();

                    IV_BYTE = IV;
                    KEY_BYTE = shared_Key;

                }
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

        private void save_Click(object sender, EventArgs e)
        {
            try
            {
                string savePath = "..\\..\\Signature\\Contract.pdf";
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

        private void Sign_Click(object sender, EventArgs e)
        {
            Sign_Verify.Sign();
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
    }
}
