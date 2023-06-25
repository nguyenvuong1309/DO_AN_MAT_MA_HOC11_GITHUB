using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BEN_MUA
{
    public class Encrypt_decrypt_key
    {
        public static RSACryptoServiceProvider ImportPrivateKey(string pem)
        {
            PemReader pr = new PemReader(new StringReader(pem));
            AsymmetricCipherKeyPair KeyPair = (AsymmetricCipherKeyPair)pr.ReadObject();
            RSAParameters rsaParams = DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters)KeyPair.Private);

            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();// cspParams);
            csp.ImportParameters(rsaParams);
            return csp;
        }
        /// <summary>
        /// Import OpenSSH PEM public key string into MS RSACryptoServiceProvider
        /// </summary>
        /// <param name="pem"></param>
        /// <returns></returns>
        public static RSACryptoServiceProvider ImportPublicKey(string pem)
        {
            PemReader pr = new PemReader(new StringReader(pem));
            AsymmetricKeyParameter publicKey = (AsymmetricKeyParameter)pr.ReadObject();
            RSAParameters rsaParams = DotNetUtilities.ToRSAParameters((RsaKeyParameters)publicKey);

            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();// cspParams);
            csp.ImportParameters(rsaParams);
            return csp;
        }

        public static string encrypt(string plainText, string keyPath)   // this function encrypt using public key rsa 2048 bit.
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            /*PemReader publicKeyReader = new PemReader(
                (StreamReader)File.OpenText("C:\\Users\\ADMIN\\Documents\\MMH\\DO_AN_MAT_MA_HOC_4\\BEN_BAN\\Signature_temp1\\public.key")
            );*/
            PemReader publicKeyReader = new PemReader(
                (StreamReader)File.OpenText(keyPath)
            );
            AsymmetricKeyParameter publicKey = (AsymmetricKeyParameter)publicKeyReader.ReadObject();

            // PKCS1 OAEP paddings
            OaepEncoding eng = new OaepEncoding(new RsaEngine());
            eng.Init(true, publicKey);

            int length = plainTextBytes.Length;
            int blockSize = eng.GetInputBlockSize();
            List<byte> cipherTextBytes = new List<byte>();
            for (int chunkPosition = 0; chunkPosition < length; chunkPosition += blockSize)
            {
                int chunkSize = Math.Min(blockSize, length - chunkPosition);
                cipherTextBytes.AddRange(eng.ProcessBlock(plainTextBytes, chunkPosition, chunkSize));
            }
            return Convert.ToBase64String(cipherTextBytes.ToArray());
        }
        public static string decrypt(string cipherText, string keyPath)         // this function using private key rsa 2048 to decrypt.
        {
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            /*PemReader privateKeyReader = new PemReader(
                (StreamReader)File.OpenText("C:\\Users\\ADMIN\\Documents\\MMH\\DO_AN_MAT_MA_HOC_4\\BEN_BAN\\Signature_temp1\\private.key")
            );*/
            PemReader privateKeyReader = new PemReader(
                (StreamReader)File.OpenText(keyPath)
            );
            RsaPrivateCrtKeyParameters privateKey = (RsaPrivateCrtKeyParameters)privateKeyReader.ReadObject();

            // PKCS1 OAEP paddings
            OaepEncoding eng = new OaepEncoding(new RsaEngine());
            eng.Init(false, privateKey);

            int length = cipherTextBytes.Length;
            int blockSize = eng.GetInputBlockSize();
            List<byte> plainTextBytes = new List<byte>();
            for (int chunkPosition = 0; chunkPosition < length; chunkPosition += blockSize)
            {
                int chunkSize = Math.Min(blockSize, length - chunkPosition);
                plainTextBytes.AddRange(eng.ProcessBlock(cipherTextBytes, chunkPosition, chunkSize));
            }
            return Encoding.UTF8.GetString(plainTextBytes.ToArray());
        }
    }
}
