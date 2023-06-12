/*namespace BEN_NGAN_HANG
{
    internal class ENCRYPT_DATA
    {
        
    }
}
*/

using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace BEN_BAN
{
    internal class ENCRYPT_DATA
    {
       
        public static string ENCRYPT_AND_SIGN_DATA(string data, string publickeyreceiver, string privatekeysender)
        {
            try
            {
                // Compute the hash of the data
                string hash = ComputeSHA256Hash(data);

                // Sign the hash using the private key of the sender
                byte[] signature = SignData(hash, privatekeysender);

                // Encrypt the data using the public key of the receiver
                string encryptedData = EncryptData(data, publickeyreceiver);

                /*// Create a container for the result
                StringBuilder result = new StringBuilder();

                // Append the signature and encrypted data to the result
                result.AppendLine("Signature: " + Convert.ToBase64String(signature));
                result.AppendLine("Encrypted Data: " + encryptedData);*/
                string result = encryptedData + Environment.NewLine + Convert.ToBase64String(signature);

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }
        public static string DECRYPT_AND_VERIFY_DATA(string data, string publickeysender, string privatekeyreceiver)
        {
            try
            {
                string[] parts = data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                string encryptedData = parts[0];
                string signatureString = parts[1];

                // Convert the signature string back to bytes
                byte[] signature = Convert.FromBase64String(signatureString);

                // Decrypt the data using the private key of the receiver
                string decryptedData = DecryptData(encryptedData, privatekeyreceiver);

                // Compute the hash of the decrypted data
                string decryptedHash = ComputeSHA256Hash(decryptedData);

                // Verify the signature using the public key of the sender
                bool isSignatureValid = VerifySignature(decryptedHash, signature, publickeysender);
                MessageBox.Show(isSignatureValid.ToString());
                return decryptedData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public static byte[] SignData(string data, string privateKey)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(privateKey);
                byte[] signatureBytes = rsa.SignData(dataBytes, new SHA256CryptoServiceProvider());

                return signatureBytes;
            }
        }

        public static bool VerifySignature(string data, byte[] signature, string publicKey)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKey);
                bool isSignatureValid = rsa.VerifyData(dataBytes, new SHA256CryptoServiceProvider(), signature);

                return isSignatureValid;
            }
        }
        public static string EncryptData(string data, string publicKey)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            int chunkSize = 100; // Adjust this value to change the size of each chunk

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKey);
                List<byte[]> encryptedChunks = new List<byte[]>();

                for (int i = 0; i < dataBytes.Length; i += chunkSize)
                {
                    int chunkLength = Math.Min(chunkSize, dataBytes.Length - i);
                    byte[] chunk = new byte[chunkLength];
                    Array.Copy(dataBytes, i, chunk, 0, chunkLength);
                    byte[] encryptedChunk = rsa.Encrypt(chunk, false);
                    encryptedChunks.Add(encryptedChunk);
                }

                byte[] mergedEncryptedData = new byte[encryptedChunks.Sum(c => c.Length)];
                int offset = 0;

                foreach (byte[] encryptedChunk in encryptedChunks)
                {
                    encryptedChunk.CopyTo(mergedEncryptedData, offset);
                    offset += encryptedChunk.Length;
                }

                return Convert.ToBase64String(mergedEncryptedData);
            }
        }

        public static string DecryptData(string encryptedData, string privateKey)
        {
            try
            {
                byte[] encryptedBytes = Convert.FromBase64String(encryptedData);

                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(privateKey);

                    int blockSize = rsa.KeySize / 8; // Calculate the block size based on the key size
                    int encryptedBytesCount = encryptedBytes.Length;
                    List<byte[]> decryptedChunks = new List<byte[]>();

                    for (int offset = 0; offset < encryptedBytesCount; offset += blockSize)
                    {
                        int chunkSize = Math.Min(blockSize, encryptedBytesCount - offset);
                        byte[] chunk = new byte[chunkSize];
                        Buffer.BlockCopy(encryptedBytes, offset, chunk, 0, chunkSize);

                        byte[] decryptedChunk = rsa.Decrypt(chunk, false);
                        decryptedChunks.Add(decryptedChunk);
                    }

                    byte[] decryptedBytes = decryptedChunks.SelectMany(chunk => chunk).ToArray();
                    return Encoding.UTF8.GetString(decryptedBytes);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        /*private static string EncryptData(string data, string publicKey)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKey);
                byte[] encryptedData = rsa.Encrypt(dataBytes, false);

                return Convert.ToBase64String(encryptedData);
            }
        }*/

        /*private static string DecryptData(string encryptedData, string privateKey)
        {
            try
            {
                byte[] encryptedBytes = Convert.FromBase64String(encryptedData);

                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(privateKey);
                    byte[] decryptedBytes = rsa.Decrypt(encryptedBytes, false);

                    return Encoding.UTF8.GetString(decryptedBytes);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }*/

        public static string ComputeSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
        public static bool CompareHashes(string hash1, string hash2)
        {
            return StringComparer.OrdinalIgnoreCase.Compare(hash1, hash2) == 0;
        }
       /* public static string ConvertPdfToString(string pdfPath)
        {
            StringBuilder text = new StringBuilder();
            PdfReader pdfReader = new PdfReader(pdfPath);

            for (int page = 1; page <= pdfReader.NumberOfPages; page++)
            {
                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                string currentPageText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);
                text.Append(currentPageText);
            }

            pdfReader.Close();
            return text.ToString();
        }
        public static void ConvertStringToPdf(string text, string outputFilePath)
        {
            using (Document document = new Document())
            {
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outputFilePath, FileMode.Create));
                document.Open();
                document.Add(new Paragraph(text));
            }
        }*/
    }
}
