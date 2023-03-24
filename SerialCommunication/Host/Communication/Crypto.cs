using System;

namespace Host.Communication
{
    internal class Crypto
    {
        public String Encrypt(String cleanText, bool encrypt, int key)
        {
            if (!encrypt) return cleanText;
            return Encrypt(cleanText, key);
        }

        private String Encrypt(String cleanText, int key)
        {
            String ciphertext = cleanText;  // Dummy
            return ciphertext;
        }


        public String Decrypt(String ciphertext, bool encrypt, int key)
        {
            if (!encrypt) return ciphertext;
            return Decrypt(ciphertext, key);
        }

        private String Decrypt(String ciphertext, int key)
        {
            String cleanText = ciphertext;  // Dummy
            return cleanText;
        }

    }
}