using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
        PasswordEntryModel this[int i] => _passwordEntries[i];

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
        public void RemovePasswordEntry(int index) => _passwordEntries.RemoveAt(index);

        public void ClearAndReadPasswordList(string pathToFile) 
        {
            FileInfo file = new FileInfo(pathToFile);

            if (!file.Exists) throw new Exception();
            if (file.Extension!="pas") throw new Exception();
            
            BinaryFormatter formatter = new BinaryFormatter();
            
            using (FileStream fs = file.Open(FileMode.Open)) 
            {
                _passwordEntries = (List<PasswordEntryModel>)formatter.Deserialize(fs);       
            }
        }

        public void ClearAndReadEncryptionKeyList(string pathToFile)
        {
            FileInfo file = new FileInfo(pathToFile);

            if (!file.Exists) throw new Exception();
            if (file.Extension != "key") throw new Exception();

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = file.Open(FileMode.Open))
            {
                _encryptionKeys = (List<EncryptionKey>)formatter.Deserialize(fs);
            }
        }

        public void EncryptAndWritePasswordList(string passwordListPath, string encryptionKeyListPath) 
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream passwordsFS = new FileStream($"{passwordListPath}\\passwords.pas", FileMode.Create))
            using (FileStream keysFS = new FileStream($"{encryptionKeyListPath}\\keys.key", FileMode.Create))
            {
                formatter.Serialize(passwordsFS, _passwordEntries);
                formatter.Serialize(keysFS, _encryptionKeys);
            }
        }
    }
}
