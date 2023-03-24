using System;

namespace Client.Communication
{
    /*
     * Look at https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography?view=netframework-4.8
     */
    internal class Crypto
    {
        public String Encrypt(String cleanText, bool encrypt, int key)
        {
            if(!encrypt) return cleanText;
            return Encrypt(cleanText, key);
        }

        /**
         * Add method for encrypt data
         */
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

        /**
         * Add method for decrypt data
         */
        private String Decrypt(String ciphertext, int key)
        {
            String cleanText = ciphertext;  // Dummy
            return cleanText;
        }

    }
}