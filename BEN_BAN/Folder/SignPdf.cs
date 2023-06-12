using System;
using System.IO;
using Org.BouncyCastle.Crypto;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Signatures;
using Org.BouncyCastle.Pkcs;
using iText.Commons.Bouncycastle.Cert;
using iText.Bouncycastle.X509;
using iText.Bouncycastle.Crypto;
using iText.Html2pdf;
using System.Collections.Generic;
using BEN_NGAN_HANG;

namespace iText.Samples.Signatures.Chapter02
{
    public class SignPdf
    {
        public static readonly string DEST = "..\\..\\Signature\\";
        public static readonly string KEYSTORE = "..\\..\\Signature\\store.p12";
        public static readonly string SRC = "..\\..\\Signature\\contract.pdf";
        public static readonly char[] PASSWORD = "contract".ToCharArray();
        public void createPdf(string baseUri, string html, string dest)
        {
            ConverterProperties properties = new ConverterProperties();
            properties.SetBaseUri(baseUri);
            HtmlConverter.ConvertToPdf(html, new FileStream(dest, FileMode.Create), properties);
        }
        public void Sign(String src, String dest, IX509Certificate[] chain, ICipherParameters pk,
            String digestAlgorithm, PdfSigner.CryptoStandard subfilter, String reason, String location)
        {
            PdfReader reader = new PdfReader(src);
            PdfSigner signer = new PdfSigner(reader, new FileStream(dest, FileMode.OpenOrCreate), new StampingProperties().UseAppendMode());
            // Create the signature appearance
            Rectangle rect = new Rectangle(200, 280, 100, 100);
            PdfSignatureAppearance appearance = signer.GetSignatureAppearance();
            appearance
                .SetReason(reason)
                .SetLocation(location)
                // Specify if the appearance before field is signed will be used
                // as a background for the signed field. The "false" value is the default value.
                .SetLayer2Text("Signed by Nguyen Thanh Tai")
                .SetReuseAppearance(false)
                .SetPageRect(rect)
                .SetPageNumber(1);
            signer.SetFieldName("sign_by_ben_ban");

            IExternalSignature pks = new PrivateKeySignature(new PrivateKeyBC(pk), digestAlgorithm);
            // Sign the document using the detached mode, CMS or CAdES equivalent.
            signer.SignDetached(pks, chain, null, null, null, 0, PdfSigner.CryptoStandard.CMS);

        }
        public static void Sign()
        {
            Pkcs12Store pk12 = new Pkcs12Store(new FileStream(KEYSTORE, FileMode.Open, FileAccess.Read), PASSWORD);

            string alias = null;
            foreach (var a in pk12.Aliases)
            {
                alias = ((string)a);
                if (pk12.IsKeyEntry(alias))
                    break;
            }
            ICipherParameters pk = pk12.GetKey(alias).Key;
            X509CertificateEntry[] ce = pk12.GetCertificateChain(alias);
            IX509Certificate[] chain = new IX509Certificate[ce.Length];
            for (int k = 0; k < ce.Length; ++k)
            {
                chain[k] = new X509CertificateBC(ce[k].Certificate);
            }
            /*string html = File.ReadAllText("..\\..\\Signature\\contract.html");*/
            CREATE_BILL create_Bill = new CREATE_BILL();
            List<Item> items = new List<Item>();
            for (int i = 0; i < 3; ++i)
            {
                Item item = new Item();
                item.item = "áo";
                item.price = 100000;
                item.quantity = i + 1;
                items.Add(item);
            }
            string html;
            SignPdf app = new SignPdf();
            create_Bill.create_bill(out html, "Nguyen Duc Vuong", "0111111111", "Ho Chi Minh", items);
            app.createPdf(SRC, html, SRC);
            app.Sign(SRC, DEST + "contract_signed.pdf", chain, pk, DigestAlgorithms.SHA256,
                PdfSigner.CryptoStandard.CMS, "Ok", "Sell");


        }
    }
}