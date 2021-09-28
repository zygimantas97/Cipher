using System;
using System.Collections.Generic;
using System.Text;

namespace Cipher
{
    public interface ICipher
    {
        string Encrypt(string message);
        string Decrypt(string message);
    }
}
