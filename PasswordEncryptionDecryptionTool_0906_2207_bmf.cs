// 代码生成时间: 2025-09-06 22:07:21
using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Maui.Controls;

namespace PasswordEncryptionDecryptionTool
{
    public class PasswordEncryptionDecryptionTool : ContentPage
    {
        private const string SaltValue = "YourSaltValue"; // Define your salt value here
        private const int SaltSize = 16;
        private const int HashSize = 20;
        private const int KeySize = 256;

        public PasswordEncryptionDecryptionTool()
        {
            // Layout setup would go here
        }

        // Function to encrypt the password
        public string EncryptPassword(string password)
        {
            try
            {
                byte[] salt = GenerateSalt();
                byte[] key = CreateKey(password, salt);
                byte[] encryptedPassword = ProtectedData.Protect(Encoding.UTF8.GetBytes(password), key, DataProtectionScope.CurrentUser);
                return Convert.ToBase64String(encryptedPassword);
            }
            catch (CryptographicException e)
            {
                // Handle cryptographic exceptions
                return $"Error encrypting password: {e.Message}";
            }
        }

        // Function to decrypt the password
        public string DecryptPassword(string encryptedPassword)
        {
            try
            {
                byte[] key = CreateKey("", GenerateSalt());
                byte[] decryptedData = ProtectedData.Unprotect(Convert.FromBase64String(encryptedPassword), key, DataProtectionScope.CurrentUser);
                return Encoding.UTF8.GetString(decryptedData);
            }
            catch (CryptographicException e)
            {
                // Handle cryptographic exceptions
                return $"Error decrypting password: {e.Message}";
            }
        }

        // Function to generate salt
        private byte[] GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] buffer = new byte[SaltSize];
                rng.GetBytes(buffer);
                return buffer;
            }
        }

        // Function to create key
        private byte[] CreateKey(string password, byte[] salt)
        {
            using (var sha256 = new SHA256Managed())
            {
                var derivedBytes = new Rfc2898DeriveBytes(password, salt, 10000);
                return derivedBytes.GetBytes(KeySize / 8);
            }
        }
    }
}
