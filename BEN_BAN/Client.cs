using iText.Samples.Signatures.Chapter02;
using MongoDB.Driver;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BEN_BAN
{
    public partial class Client : UserControl
    {
        public string FILE_PATH;
        string KEY_STRING = "CE16A8E87AB2C9C7023DED4D69EEFECB838D51ECD4BDCE2B43B94923EF3CB2A9";
        string IV_STRING = "FA22F0CF07B6F6A3000AA9A77CD7DA4E";

        static MongoClient mongoClient = new MongoClient("mongodb+srv://21522809:21522809@cluster0.m7a6l0t.mongodb.net/?retryWrites=true&w=majority");
        static IMongoCollection<Contract> contractCollection = mongoClient.GetDatabase("Contract").GetCollection<Contract>("Contract");

        private TcpClient client;
        private SslStream sslStream;
        private Thread receiveThread;
        public Client()
        {
            InitializeComponent();
        }
        private void stop_Click(object sender, EventArgs e)
        {
            connect.Enabled = true;
            Disconnect();
        }

        private void connect_Click(object sender, EventArgs e)
        {
            connect.Enabled = false; // Disable the button while connecting

            // Create a new thread to establish the connection and receive data
            receiveThread = new Thread(ReceiveData);
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
        private void ReceiveData()
        {
            try
            {
                // Create a TCP client
                client = new TcpClient(ip.Text, Int32.Parse(port.Text));
                var stream = client.GetStream();

                // Wrap the stream in an SSL stream and authenticate
                sslStream = new SslStream(stream, false, new RemoteCertificateValidationCallback(CertificateValidationCallback));
                sslStream.AuthenticateAsClient("clientName");

                // Continuously receive and display data
                while (true)
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = sslStream.Read(buffer, 0, buffer.Length);
                    string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
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
        private void Disconnect()
        {
            sslStream?.Close();
            client?.Close();

            // Asynchronously join the receiveThread using Task.Run
            Task.Run(() => receiveThread?.Join()).ConfigureAwait(false);

            // Enable the connect button
            connect.Enabled = true;
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
        private static bool CertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        private void SendMessage(string message)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                sslStream.Write(buffer, 0, buffer.Length);
                sslStream.Flush();
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                MessageBox.Show("An error occurred while sending the message: " + ex.Message);
            }
        }
   
        private void encrypt_Key()
        {
            try
            {
                string plainText = "nguyen duc vuong";
                string cihperText = Encrypt_decrypt_key.encrypt(plainText);
                string decryptedCipherText = Encrypt_decrypt_key.decrypt(cihperText);
                MessageBox.Show(decryptedCipherText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          /*  try
            {
                RSACryptoServiceProvider RSApublicKey = Encrypt_decrypt_key.ImportPublicKey(publicKey);

                RSACryptoServiceProvider RSAprivateKey = Encrypt_decrypt_key.ImportPrivateKey(privateKey);

                var plainTextData = "test simple";

                System.Diagnostics.Debug.WriteLine("plainTextData : " + plainTextData);

                //for encryption, always handle bytes...
                var bytesPlainTextData = System.Text.Encoding.Unicode.GetBytes(plainTextData);

                //apply pkcs#1.5 padding and encrypt our data 
                var bytesCypherText = RSApublicKey.Encrypt(bytesPlainTextData, false);

                //we might want a string representation of our cypher text... base64 will do
                var cypherText = Convert.ToBase64String(bytesCypherText);

                MessageBox.Show("cypherText : " + cypherText);
                *//*
                 * some transmission / storage / retrieval
                 * 
                 * and we want to decrypt our cypherText
                 *//*

                //first, get our bytes back from the base64 string ...
                bytesCypherText = Convert.FromBase64String(cypherText);

                //we want to decrypt, therefore we need a csp and load our private key


                //decrypt and strip pkcs#1.5 padding
                bytesPlainTextData = RSAprivateKey.Decrypt(bytesCypherText, false);

                //get our original plainText back...
                plainTextData = System.Text.Encoding.Unicode.GetString(bytesPlainTextData);

                MessageBox.Show("DecryptData : " + plainTextData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("err : " + ex.StackTrace);
            }*/
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

                Contract c = new Contract(hexString,list,DateTime.Now,arrayKey,arrayIv);
                contractCollection.InsertOne(c);
                MessageBox.Show("Success add data to mongodb");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Verify_Click(object sender, EventArgs e)
        {

        }
    }
}
