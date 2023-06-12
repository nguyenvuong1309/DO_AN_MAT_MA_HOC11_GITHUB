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
using System.Collections.ObjectModel;
using MongoDB.Driver;
using iText.Samples.Signatures.Chapter02;
using BEN_BAN;
using SharpCompress.Common;
using static Org.BouncyCastle.Utilities.Test.FixedSecureRandom;

namespace BEN_NGAN_HANG
{
    public partial class Server : UserControl
    {
        public TcpListener tcpListener;
        private Thread listenThread;
        private List<TcpClient> connectedClients = new List<TcpClient>();

        static MongoClient mongoClient = new MongoClient();
        static IMongoDatabase db = mongoClient.GetDatabase("contractDB");
        static IMongoCollection<Contract> collection = db.GetCollection<Contract>("contract");

        string FILE_PATH = "";

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
                    //MessageBox.Show("have client");
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

                    //MessageBox.Show("Sent data to client: " + data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void stop_Click(object sender, EventArgs e)
        {
            try
            {
                if (tcpListener != null)
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
        /*private void HandleClientComm(object client)
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




                   
                    string savePath = "C:\\Users\\ADMIN\\Documents\\MMH\\DO_AN_MAT_MA_HOC_1\\BEN_BAN\\Signature\\test.pdf"; 

                    DisplayMessageInTextBox(data);
                }

                tcpClient.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }*/


        private void HandleClientComm(object client)
        {
            try
            {
                MessageBox.Show("success");
                TcpClient tcpClient = (TcpClient)client;
                NetworkStream clientStream = tcpClient.GetStream();
                connectedClients.Add(tcpClient);


                byte[] buffer = new byte[4096];
                int bytesRead;
                string savePath = "C:\\Users\\ADMIN\\Documents\\MMH\\DO_AN_MAT_MA_HOC_1\\BEN_BAN\\Signature\\test.pdf";
                using (FileStream fileStream = File.Create(savePath))
                {
                    // Read the incoming data and save it to a file
                    while ((bytesRead = clientStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, bytesRead);
                    }
                }
                DisplayMessageInTextBox("success");
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
                    textBox2.AppendText(message + Environment.NewLine);
                }
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

        private void upload_to_db_Click(object sender, EventArgs e)
        {
            byte[] encryptedText = null;
            Contract c = new Contract(Convert.ToBase64String(encryptedText));
            collection.InsertOneAsync(c);
            MessageBox.Show("Success add data to mongodb");
        }

        private void get_from_db_Click(object sender, EventArgs e)
        {

        }

        private void signpdf_Click(object sender, EventArgs e)
        {
            try
            {
                CREATE.Create_cert();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
            //SignPdf.Sign();
        }

        private void send1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TcpClient client in connectedClients)
                {
                    NetworkStream clientStream = client.GetStream();
                    //MessageBox.Show("Sent data to client: " + data);
                    using (FileStream fileStream = File.OpenRead(FILE_PATH))
                    {
                        byte[] buffer = new byte[4096];
                        int bytesRead;

                        // Read the file and send it to the client in chunks
                        while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            clientStream.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
