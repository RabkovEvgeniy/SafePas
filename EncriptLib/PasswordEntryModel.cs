using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptLib
{
    class PasswordEntryModel
    {
        public string URI { get; set; }
        public string Comment { get; set; }

        public EncryptedRecord Password { get; set;}
        public string UserName { get; set;}
    }
}
