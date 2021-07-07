using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncriptLib
{
    public class EncryptedRecord
    {
        public string Value { get; private set; }
        public bool isEncrypted{ get; private set; }
        // public Id KeyID { get; private set; }
        // public void Encrypt(Key key) { };

    }
}
