// 代码生成时间: 2025-09-09 14:10:08
using System;
using System.Security.Cryptography;
using System.Text;

namespace MAUIApp
{
    public class PasswordEncryptionDecryptionTool
    {
        // 使用AES算法进行密码加密和解密
        private static readonly string EncryptionAlgorithm = "AES";
        private static readonly int KeySize = 256;
        private static readonly int KeySizeInBits = KeySize * 8;
        private static readonly int BlockSizeInBytes = 128 / 8;

        // 加密和解密的密钥
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("YourSecureKey");
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("YourSecureIV");

        /// <summary>
        /// 加密密码
        /// </summary>
        /// <param name="password">待加密的密码</param>
        /// <returns>加密后的密码</returns>
        public static string EncryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password cannot be null or empty.");
            }

            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                byte[] encrypted = EncryptStringToBytes_Aes(password, encryptor);
                return Convert.ToBase64String(encrypted);
            }
        }

        /// <summary>
        /// 解密密码
        /// </summary>
        /// <param name="encryptedPassword">待解密的密码</param>
        /// <returns>解密后的密码</returns>
        public static string DecryptPassword(string encryptedPassword)
        {
            if (string.IsNullOrEmpty(encryptedPassword))
            {
                throw new ArgumentException("Encrypted password cannot be null or empty.");
            }

            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                byte[] decrypted = DecryptStringFromBytes_Aes(encryptedPassword, decryptor);
                return Encoding.UTF8.GetString(decrypted);
            }
        }

        private static byte[] EncryptStringToBytes_Aes(string plainText, ICryptoTransform transform)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, transform, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                }
                return ms.ToArray();
            }
        }

        private static byte[] DecryptStringFromBytes_Aes(string cipherText, ICryptoTransform transform)
        {
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText)))
            {
                using (CryptoStream cs = new CryptoStream(ms, transform, CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        return Encoding.UTF8.GetBytes(sr.ReadToEnd());
                    }
                }
            }
        }
    }
}