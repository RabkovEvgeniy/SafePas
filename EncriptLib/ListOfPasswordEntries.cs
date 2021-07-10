using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptLib
{
    class ListOfPasswordEntries
    {

        private static Random _random = new Random();

        private List<PasswordEntryModel> _passwordEntries;
        
        private List<EncryptionKey> _encryptionKeys;

        public ListOfPasswordEntries() 
        {
            _passwordEntries = new List<PasswordEntryModel>();
            _encryptionKeys = new List<EncryptionKey>();
        }

        public int Count 
        {
            get => _passwordEntries.Count;
        }
        
        PasswordEntryModel this[int i] 
        {
            get => (PasswordEntryModel)_passwordEntries[i].Clone(); 
        }

        public void AddPasswordEntry(string URI, string userName, string password, string comment)
        {
            _passwordEntries.Add(new PasswordEntryModel
            {
                URI = URI,
                UserName = userName,
                Password = password,
                Comment = comment
            });
        }

        public void ReadPasswordList(string path) 
        {
            throw new NotImplementedException();
        }

        public void ReadEncryptionKeyList(string path)
        {
            throw new NotImplementedException();
        }

        public void WritePasswordList(string passwordListPath, string encryptionKeyListPath) 
        {
            throw new NotImplementedException();
        }
    }
}
