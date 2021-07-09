using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptLib
{
    class ListOfPasswordEntries
    {
        private LinkedList<PasswordEntryModel> PasswordEntries;

        public void AddPasswordEntry(string URI, string userName, EncryptedRecord password, string comment)
        {
            PasswordEntries.AddLast(new PasswordEntryModel
            {
                URI = (string)URI.Clone(),
                UserName = (string)userName.Clone(),
                //Password = ,
                Comment = (string)comment.Clone()
            }) ;
        }

    }
}
