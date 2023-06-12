using System;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace BEN_NGAN_HANG
{
    internal class Pdf
    {
        public static string ConvertPDFToString(string filePath)
        {
            try
            {
                using (PdfReader reader = new PdfReader(filePath))
                {
                    string text = string.Empty;

                    for (int page = 1; page <= reader.NumberOfPages; page++)
                    {
                        text += PdfTextExtractor.GetTextFromPage(reader, page);
                    }

                    return text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error converting PDF to string: " + ex.Message);
                return string.Empty;
            }
        }
        public static void ConvertStringToPDF(string text, string savePath)
        {
            try
            {
                // Create a new document
                Document document = new Document();

                // Create a new PDF writer
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(savePath, FileMode.Create));

                // Open the document
                document.Open();

                // Add the text to the document
                document.Add(new Paragraph(text));

                // Close the document
                document.Close();

                //MessageBox.Show("PDF file created successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating PDF file: " + ex.Message);
            }
        }
    }
}
