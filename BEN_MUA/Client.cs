using iText.Kernel.Pdf;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using iTextSharp.text.pdf;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;

namespace BEN_NGAN_HANG
{
    public partial class Client : UserControl
    {
        public TcpClient tcpClient;
        private NetworkStream clientStream;
        string FILE_PATH = "";
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

       /* private void ReceiveDataFromServer()
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead = clientStream.Read(buffer, 0, buffer.Length);
                    string receivedData = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    DisplayMessageInTextBox(receivedData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }*/

        private void ReceiveDataFromServer()
        {
            try
            {
                while (true)
                {
                    //byte[] buffer = new byte[4096];
                    //int bytesRead = clientStream.Read(buffer, 0, buffer.Length);



                    //
                    string savePath = "C:\\Users\\ADMIN\\Documents\\MMH\\DO_AN_MAT_MA_HOC_1\\BEN_MUA\\Signature\\test.pdf";
                    using (FileStream fileStream = File.Create(savePath))
                    {
                        byte[] buffer = new byte[4096];
                        int bytesRead;

                        Console.WriteLine("Receiving file...");

                        // Read the incoming data and save it to a file
                        while ((bytesRead = clientStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fileStream.Write(buffer, 0, bytesRead);
                        }
                    }

                    //



                    //string receivedData = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    DisplayMessageInTextBox("success");
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

                    //MessageBox.Show("Sent data to server: " + data);
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
                textBox2.AppendText(message + Environment.NewLine);

            }
        }
        public void ConvertStringToPDF(string text, string savePath)
        {
            try
            {
                // Create a new document
                Document document = new Document();

                // Create a new PDF writer
                iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream(savePath, FileMode.Create));

                // Open the document
                document.Open();

                // Add the text to the document
                document.Add(new iTextSharp.text.Paragraph(text));

                // Close the document
                document.Close();

                MessageBox.Show("PDF file created successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating PDF file: " + ex.Message);
            }
        }
        public void stop_Click(object sender, EventArgs e)
        {   
            try
            {
                if (clientStream != null)
                {
                    tcpClient.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            /*string savePath = "C:\\Users\\ADMIN\\Documents\\MMH\\DO_AN_MAT_MA_HOC_1\\BEN_MUA\\Signature\\test.pdf";
            Pdf.ConvertStringToPDF(textBox2.Text, savePath);*/
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

        private void send1_Click(object sender, EventArgs e)
        {
            try
            {
                //string data = textBox1.Text;
                //byte[] buffer = Encoding.ASCII.GetBytes(data);
                if (clientStream != null)
                {
                    FileStream fileStream = File.OpenRead(FILE_PATH);


                    byte[] Buffer = new byte[4096];
                    int bytesRead;

     

                    // Read the file and send it to the server in chunks
                    while ((bytesRead = fileStream.Read(Buffer, 0, Buffer.Length)) > 0)
                    {
                        clientStream.Write(Buffer, 0, bytesRead);
                    }
                    fileStream.Flush();
                    clientStream.Flush();

                   /* clientStream.Write(buffer, 0, buffer.Length);
                    clientStream.Flush*/
                }
                else
                {
                    MessageBox.Show("not connect to server");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
