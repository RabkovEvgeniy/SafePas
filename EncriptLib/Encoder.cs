using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptLib
{
    public static class Encoder
    {   
        public static string Encrypt(string value, EncryptionKey key) 
        {
            char[] result = new char[value.Length];

            for (int i = 0; i < value.Length; i++)
            {
                result[i] = (char)((value[i] + key.Value[i % 100]) % 1104);
            }

            return new string(result);
        }

        public static string Decrypt(string value,EncryptionKey key) 
        {
            char[] result = new char[value.Length];

            for (int i = 0; i < value.Length; i++)
            {
                result[i] = (char)(value[i] - key.Value[i] + (value[i] < key.Value[i % 100]?1104:0));
            }

            return new string(result);
        }
    }
}
