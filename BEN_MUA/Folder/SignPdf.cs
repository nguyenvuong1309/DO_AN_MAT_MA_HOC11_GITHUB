using iText.Kernel.Pdf;
using iText.Signatures;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.X509;
using System.IO;

/*
#generate the RSA private key
openssl genpkey -outform PEM -algorithm RSA -pkeyopt rsa_keygen_bits:2048 -out priv.key

#Create the CSR (Click csrconfig.txt in the command below to download config)
openssl req -new - nodes - key priv.key - config csrconfig.txt - nameopt utf8 - utf8 -out cert.csr*/


namespace BEN_NGAN_HANG
{
    internal class SignPdf
    {
        public static void Sign()
        {
            string KEYSTORE = "C:\\Users\\ADMIN\\Documents\\MMH\\DO_AN_MAT_MA_HOC_1\\BEN_MUA\\Signature\\cert.pfx";
            char[] PASSWORD = "123".ToCharArray();

            Pkcs12Store pk12 = new Pkcs12Store(new FileStream(KEYSTORE,
            FileMode.Open, FileAccess.Read), PASSWORD);
            string alias = null;
            foreach (object a in pk12.Aliases)
            {
                alias = ((string)a);
                if (pk12.IsKeyEntry(alias))
                {
                    break;
                }
            }
            ICipherParameters pk = pk12.GetKey(alias).Key;


            //


            X509CertificateEntry[] ce = pk12.GetCertificateChain(alias);
            X509Certificate[] chain = new X509Certificate[ce.Length];
            for (int k = 0; k < ce.Length; ++k)
            {
                chain[k] = ce[k].Certificate;
            }


            //


            string DEST = "C:\\Users\\ADMIN\\Documents\\MMH\\DO_AN_MAT_MA_HOC_1\\BEN_MUA\\Signature\\SignedPDF.pdf";
            string SRC = "C:\\Users\\ADMIN\\Documents\\MMH\\DO_AN_MAT_MA_HOC_1\\BEN_MUA\\Signature\\Contract.pdf";

            PdfReader reader = new PdfReader(SRC);
            PdfSigner signer = new PdfSigner(reader,
            new FileStream(DEST, FileMode.Create),
            new StampingProperties());


            //


            PdfSignatureAppearance appearance = signer.GetSignatureAppearance();
            appearance.SetReason("My reason to sign...")
                .SetLocation("Lahore")
                .SetPageRect(new iText.Kernel.Geom.Rectangle(50, 50, 200, 100))
                .SetPageNumber(1);
            signer.SetFieldName("MyFieldName");



            //


            IExternalSignature pks = new PrivateKeySignature(pk, DigestAlgorithms.SHA256);


            //  


            signer.SignDetached(pks, chain, null, null, null, 0,
            PdfSigner.CryptoStandard.CMS);
        }
    }
}
