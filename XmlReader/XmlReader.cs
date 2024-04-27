using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlReader {
    public class XmlReader {
        XmlTextReader xmlReader;
        XmlTextWriter xmlWriter;
        private double[] chances = new double[9];
        
        public XmlReader() {
            Decrypt();
            xmlReader = new XmlTextReader("chances.xml");
            int i = 0;
            while (xmlReader.Read()) {
                switch (xmlReader.NodeType) {
                    case XmlNodeType.Element:
                        break;
                    case XmlNodeType.Text:
                        if (xmlReader.Value != null) {
                            if (i == 8)
                            {
                                chances[i] = Convert.ToDouble(xmlReader.Value);
                            }
                            else
                            {
                                chances[i] = System.Convert.ToInt32(xmlReader.Value);
                            }
                        }
                        break;
                    case XmlNodeType.EndElement:
                        ++i;
                        break;
                }
            }
            xmlReader.Close();
            Encrypt();
        }
       
        public double[] getChances() {
            return chances;
        }
        
        public void updateJackpot(double chance) {
            xmlWriter = new XmlTextWriter("chances.xml", null);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteWhitespace("\n");
            xmlWriter.WriteStartElement("chances");
            xmlWriter.WriteWhitespace("\n\t");
            xmlWriter.WriteElementString("cherry", "29");
            xmlWriter.WriteWhitespace("\n\t");
            xmlWriter.WriteElementString("orange", "13");
            xmlWriter.WriteWhitespace("\n\t");
            xmlWriter.WriteElementString("lemon", "13");
            xmlWriter.WriteWhitespace("\n\t");
            xmlWriter.WriteElementString("plum", "13");
            xmlWriter.WriteWhitespace("\n\t");
            xmlWriter.WriteElementString("grapes", "10");
            xmlWriter.WriteWhitespace("\n\t");
            xmlWriter.WriteElementString("melon", "10");
            xmlWriter.WriteWhitespace("\n\t");
            xmlWriter.WriteElementString("stars", "7");
            xmlWriter.WriteWhitespace("\n\t");
            xmlWriter.WriteElementString("seven", "5");
            xmlWriter.WriteWhitespace("\n\t");
            xmlWriter.WriteElementString("jackpot", chance.ToString());
            xmlWriter.WriteWhitespace("\n");
            xmlWriter.WriteEndElement();
            xmlWriter.Flush();
            xmlWriter.Close();
        }

        public void Encrypt()
        {
            byte[] encKey;
            byte[] encIV;

            FileStream inputFile = new FileStream("chances.xml", FileMode.Open, FileAccess.Read);
            FileStream outputFile = new FileStream("EncryptedChances.enc", FileMode.OpenOrCreate, FileAccess.Write);

            AesCryptoServiceProvider cryptoProvider = new AesCryptoServiceProvider();

            ICryptoTransform encryptor = cryptoProvider.CreateEncryptor();

            CryptoStream stream = new CryptoStream(outputFile, encryptor, CryptoStreamMode.Write);

            encKey = cryptoProvider.Key;
            encIV = cryptoProvider.IV;

            System.IO.File.WriteAllBytes("chances.key", encKey);
            System.IO.File.WriteAllBytes("chances.IV", encIV);

            byte[] input = new byte[128];
            int inLen = -1;

            while ((inLen = inputFile.Read(input, 0, 128)) > 0)
            {
                stream.Write(input, 0, inLen);
            }

            stream.Close();
            outputFile.Close();
            inputFile.Close();
            Trace.WriteLine(DateTime.Now.ToString("dd/MM/yyyy-hh:mm-tt") + "\tCriptat");
        }

        private void Decrypt()
        {
            FileStream inputFile = new FileStream("EncryptedChances.enc", FileMode.Open, FileAccess.Read);
            FileStream outputFile = new FileStream("chances.xml", FileMode.OpenOrCreate, FileAccess.Write);

            AesCryptoServiceProvider cryptoProvider = new AesCryptoServiceProvider();

            ICryptoTransform decryptor = cryptoProvider.CreateDecryptor(System.IO.File.ReadAllBytes("chances.key"), System.IO.File.ReadAllBytes("chances.IV"));

            CryptoStream stream = new CryptoStream(outputFile, decryptor, CryptoStreamMode.Write);

            byte[] input = new byte[128];
            int inLen = -1;

            while ((inLen = inputFile.Read(input, 0, 128)) > 0)
                stream.Write(input, 0, inLen);

            stream.Close();
            outputFile.Close();
            inputFile.Close();
            Trace.WriteLine(DateTime.Now.ToString("dd/MM/yyyy-hh:mm-tt") + "\tDecriptat");
        }
    }
}
