using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.IO;
using System.Security.Cryptography;

namespace MACEncryptor
{
    public class MACEncryptor
    {
        public String Encrypt(String filepath)
        {
            byte[] secretKey = new byte[128];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(secretKey);
            FileStream inputFile = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            KeyedHashAlgorithm cryptoProvider = new HMACSHA256(secretKey);
            byte[] hmacValue = null;
            hmacValue = cryptoProvider.ComputeHash(inputFile);
            inputFile.Close();

            return System.Text.Encoding.UTF8.GetString(hmacValue);
        }      
    }
}
