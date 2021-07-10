using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EncryptLib
{
    [Serializable]
    class PasswordEntryModel:ICloneable
    {
        public string URI { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Comment { get; set; }

        public object Clone()
        {
            return new PasswordEntryModel
            {
                URI = (string)URI.Clone(),
                UserName = (string)UserName.Clone(),
                Password = (string)Password.Clone(),
                Comment = (string)Comment.Clone()
            };
        }
    }
}
