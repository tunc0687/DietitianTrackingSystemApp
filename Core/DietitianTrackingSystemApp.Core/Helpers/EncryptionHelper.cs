using System.Security.Cryptography;
using System.Text;

namespace Kaizen.Common.Encryptions
{
    public class EncryptionHelper
    {
        public static string EncryptWithAes(string text, string key, string iv, CipherMode mode = CipherMode.CBC)
        {
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Mode = mode;

                ICryptoTransform encryptor = aes.CreateEncryptor(Encoding.UTF8.GetBytes(key), Encoding.UTF8.GetBytes(iv));

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(text);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptWithAes(string cipherText, string key, string iv, CipherMode mode = CipherMode.CBC)
        {
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Mode = mode;

                ICryptoTransform decryptor = aes.CreateDecryptor(Encoding.UTF8.GetBytes(key), Encoding.UTF8.GetBytes(iv));

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}