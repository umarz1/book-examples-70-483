using System;
using System.IO;
using System.Security.Cryptography;

namespace book_examples_70_483.Chapter_3
{
    public class AESEncryption
    {
        static void DumpBytes(string title, byte[] bytes)
        {
            Console.Write(title);

            foreach (byte b in bytes)
            {
                Console.Write("{0:X} ", b);
            }

            Console.WriteLine();
        }

        public static void Example1()
        {
            string plainText = "This is my super secret data";

            byte[] cipherText;
            byte[] key;
            byte[] initializationVector;

            using (Aes aes = Aes.Create())
            {
                key = aes.Key;
                initializationVector = aes.IV;

                ICryptoTransform encryptor = aes.CreateEncryptor();

                using (MemoryStream encryptMemoryStream = new MemoryStream())
                {
                    using (CryptoStream encryptCryptoStream = new CryptoStream(encryptMemoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(encryptCryptoStream))
                        {
                            swEncrypt.Write(plainText);
                        }

                        cipherText = encryptMemoryStream.ToArray();
                    }
                }
            }

            Console.WriteLine("String to encrypt: {0}", plainText);
            DumpBytes("Key: ", key);
            DumpBytes("Initialized Vector ", initializationVector);
            DumpBytes("Encrypted: ", cipherText);

            //Decryption

            string decryptedText;

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = initializationVector;

                ICryptoTransform decryptor = aes.CreateDecryptor();

                using(MemoryStream decryptStream = new MemoryStream(cipherText))
                {
                    using(CryptoStream decryptCryptoStream = new CryptoStream(decryptStream, decryptor, CryptoStreamMode.Read))
                    {
                        using(StreamReader srDecrypt = new StreamReader(decryptCryptoStream))
                        {

                            decryptedText = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            Console.WriteLine("Decrypted: {0}", decryptedText);
        }


    }

}
