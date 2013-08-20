using System;
using System.Security.Cryptography;
using System.Text;
using LunchPicker.Domain.Utilities;

namespace LunchPicker.Infrastructure.Utilities
{
    public class EncryptionUtility : IEncryptionUtility
    {
        private const string Key = "the lunch hour crunch";

        public string Encrypt(string toEncrypt, bool useHasing)
        {
            byte[] keyArray;
            var toEncryptArray = Encoding.ASCII.GetBytes(toEncrypt);
            if (useHasing)
            {
                var hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(Encoding.ASCII.GetBytes(Key));
                hashmd5.Clear();
            }
            else
            {
                keyArray = Encoding.ASCII.GetBytes(Key);
            }
            var tDes = new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            var cTransform = tDes.CreateEncryptor();
            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tDes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public string Decrypt(string toDecrypt, bool useHasing)
        {
            byte[] keyArray;
            var toDecryptArray = Convert.FromBase64String(toDecrypt);

            if (useHasing)
            {
                var hashmd = new MD5CryptoServiceProvider();
                keyArray = hashmd.ComputeHash(Encoding.ASCII.GetBytes(Key));
                hashmd.Clear();
            }
            else
            {
                keyArray = Encoding.ASCII.GetBytes(Key);
            }
            var tDes = new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            var cTransform = tDes.CreateDecryptor();
            var resultArray = cTransform.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);

            tDes.Clear();
            return Encoding.UTF8.GetString(resultArray, 0, resultArray.Length);
        }
    }
}
