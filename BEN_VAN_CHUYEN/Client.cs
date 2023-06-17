using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BEN_VAN_CHUYEN
{
    public partial class Client : UserControl
    {
        private TcpClient tcpClient;
        private NetworkStream clientStream;
        public string FILE_PATH;

        static MongoClient mongoClient = new MongoClient();
        static IMongoDatabase db = mongoClient.GetDatabase("contractDB");
        static IMongoCollection<Contract> collection = db.GetCollection<Contract>("contract");

        string KEY_STRING = "CE16A8E87AB2C9C7023DED4D69EEFECB838D51ECD4BDCE2B43B94923EF3CB2A9";
        string IV_STRING = "FA22F0CF07B6F6A3000AA9A77CD7DA4E";
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

                string savePath = "..\\..\\Signature\\contract.pdf";
                byte[] KEY_BYTE = Aes.ConvertStringToByte(KEY_STRING);
                byte[] IV_BYTE = Aes.ConvertStringToByte(IV_STRING);

                string hex = textBox2.Text;
                byte[] fileByte = Aes.ConvertStringToByte(hex);
                byte[] fileDecrypt = Aes.decrypt_Byte(fileByte, KEY_BYTE, IV_BYTE);


                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Pdf File|*.pdf";
                savePath = sfd.FileName;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    savePath = sfd.FileName;
                    File.WriteAllBytes(savePath, fileDecrypt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                Contract c = new Contract(hexString);
                collection.InsertOneAsync(c);
                MessageBox.Show("Success add data to mongodb");
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

        private void Verify_Click(object sender, EventArgs e)
        {

        }
    }
}
