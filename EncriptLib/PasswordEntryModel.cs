using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptLib
{
    class PasswordEntryModel:ICloneable
    {
        public string URI { get; set; }

        public string UserName { get; set;}
        public EncryptedRecord Password { get; set;}
        public string Comment { get; set; }

        public object Clone()
        {
            return new PasswordEntryModel
            {
                URI = (string)URI.Clone(),
                UserName = (string)UserName.Clone(),
                Password = (EncryptedRecord)Password.Clone(),
                Comment = (string)Comment.Clone()
            };
        }
    }
}
