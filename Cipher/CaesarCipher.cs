using System;
using System.Collections.Generic;
using System.Text;

namespace Cipher
{
    public class CaesarCipher : ICipher
    {
        private const int ALPHABET_SHIFT = 65;
        private const int MODULE = 26;

        private int _key;

        public CaesarCipher(int key)
        {
            _key = key;
        }

        public string Encrypt(string message)
        {
            string encryptedMessage = "";

            foreach (char symbol in message.ToUpper())
            {
                int symbolCode = symbol - ALPHABET_SHIFT;
                if (symbolCode >= 0 && symbolCode < MODULE)
                {
                    symbolCode += _key;
                    while (symbolCode < 0)
                    {
                        symbolCode += MODULE;
                    }
                    encryptedMessage += Char.ConvertFromUtf32(ALPHABET_SHIFT + symbolCode % MODULE);
                }
                else
                {
                    encryptedMessage += symbol;
                }
            }

            return encryptedMessage;
        }

        public string Decrypt(string message)
        {
            string decryptedMessage = "";

            foreach(char symbol in message.ToUpper())
            {
                int symbolCode = symbol - ALPHABET_SHIFT;
                if (symbolCode >= 0 && symbolCode < MODULE)
                {
                    symbolCode -= _key;
                    while (symbolCode < 0)
                    {
                        symbolCode += MODULE;
                    }
                    decryptedMessage += Char.ConvertFromUtf32(ALPHABET_SHIFT + symbolCode % MODULE);
                }
                else
                {
                    decryptedMessage += symbol;
                }
            }

            return decryptedMessage;
        }
    }
}
