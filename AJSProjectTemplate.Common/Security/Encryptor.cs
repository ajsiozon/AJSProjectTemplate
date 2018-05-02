using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AJSProjectTemplate.Common.Security
{
    public class Encryptor
    {
        public static string Encrypt(string publicKey, string plainText)
        {
            return EncryptorRSA.EncryptText(plainText, publicKey);
        }

        public static string Decrypt(string privateKey, string encryptdText)
        {
            return EncryptorRSA.DecryptText(encryptdText, privateKey);
        }

        public static string Encrypt(string plainText)
        {
            return BitConverter.ToString(SHA1.Create().ComputeHash(Encoding.Default.GetBytes(plainText))).Replace("-", "");
        }
    }
}
