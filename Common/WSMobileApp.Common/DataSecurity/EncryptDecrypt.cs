using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace WSMobileApp.Common.DataSecurity
{
    public class EncryptDecrypt
    {
        //'A string of 16 numbers.  {n1, .. , n16} // = 1111111111111111
        private static readonly Byte[] Sharedkey = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        private static readonly Byte[] Sharedvector = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

        /// <summary>
        /// Method to Encrypt a string
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string Encrypt(string val)
        {
            var tdes = new TripleDESCryptoServiceProvider();

            var toEncrypt = Encoding.UTF8.GetBytes(val);
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, tdes.CreateEncryptor(Sharedkey, Sharedvector), CryptoStreamMode.Write))
                {

                    cs.Write(toEncrypt, 0, toEncrypt.Length);
                    cs.FlushFinalBlock();

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        /// <summary>
        /// Method to Decrypt a string
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string Decrypt(string val)
        {
            val = val.Replace(" ", "+");

            var tdes = new TripleDESCryptoServiceProvider();

            var toDecrypt = Convert.FromBase64String(val);

            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, tdes.CreateDecryptor(Sharedkey, Sharedvector), CryptoStreamMode.Write))
                {

                    cs.Write(toDecrypt, 0, toDecrypt.Length);
                    cs.FlushFinalBlock();

                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }
    }
}
