using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace book_examples_70_483.Chapter_3
{
    public class RSAEncryption
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
            Console.WriteLine("Plain text: {0}", plainText);

            ASCIIEncoding converter = new ASCIIEncoding();

            byte[] plainBytes = converter.GetBytes(plainText);

            DumpBytes("Plain bytes: ", plainBytes);

            byte[] encryptedBytes;
            byte[] decryptedBytes;

            var rSAEncrypt = new RSACryptoServiceProvider();

            string publicKey = rSAEncrypt.ToXmlString(true);
            Console.WriteLine("Public key: {0}", publicKey);

            string privateKey = rSAEncrypt.ToXmlString(false);
            Console.WriteLine("Private key: {0}", privateKey);

            rSAEncrypt.FromXmlString(privateKey);

            encryptedBytes = rSAEncrypt.Encrypt(plainBytes, fOAEP: false);

            DumpBytes("Encrypted bytes: ", encryptedBytes);

            RSACryptoServiceProvider rsaDecrypt = new RSACryptoServiceProvider();

            rsaDecrypt.FromXmlString(privateKey);

            decryptedBytes = rsaDecrypt.Decrypt(encryptedBytes, fOAEP: false);

            DumpBytes("Decrypted bytes: ", decryptedBytes);

            Console.WriteLine("Decrypted string: {0}", converter.GetString(decryptedBytes));

            Console.ReadKey();
        }

    }

}
