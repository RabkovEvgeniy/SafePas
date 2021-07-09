using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptLib
{
    class ListOfPasswordEntries
    {
        /// <summary>
        /// Статический генератор случайных чисел
        /// </summary>
        private static Random _random;

        /// <summary>
        /// 
        /// </summary>
        static ListOfPasswordEntries() => _random = new Random();

        public ListOfPasswordEntries() 
        {
            _passwordEntries = new List<PasswordEntryModel>();
            _encryptionKeys = new List<EncryptionKey>();
        }

        /// <summary>
        /// Возвращает количество записей о поролях. 
        /// </summary>
        public int Count 
        {
            get => _passwordEntries.Count;
        }

        /// <summary>
        /// Список записей поролей.
        /// </summary>
        private List<PasswordEntryModel> _passwordEntries;
        
        /// <summary>
        /// Список ключей шифрования.
        /// </summary>
        private List<EncryptionKey> _encryptionKeys;
        
        PasswordEntryModel this[int i] 
        {
            get => (PasswordEntryModel)_passwordEntries[i].Clone(); 
        }

        /// <summary>
        /// Создает запись и генерирует ключ шифрования.
        /// </summary>
        /// <param name="URI">URI-адресс сайта</param>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        /// <param name="comment">Комментарий к записи</param>
        public void AddPasswordEntry(string URI, string userName, string password, string comment)
        {
            _passwordEntries.Add(new PasswordEntryModel
            {
                URI = (string)URI.Clone(),
                UserName = (string)userName.Clone(),
                Password = new EncryptedRecord(password),
                Comment = (string)comment.Clone()
            });
            _encryptionKeys.Add(new EncryptionKey(_random));
        }

        /// <summary>
        /// Считывает список записей о поролях из файла по пути path. 
        /// </summary>
        /// <param name="path">Путь до файла с записями</param>
        public void ReadPasswordList(string path) 
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Считывает список ключей шифрования из файла по пути path, если он не подходит
        /// выбрасывает исключение.
        /// </summary>
        /// <param name="path">Путь до файла с ключами шифрования</param>
        public void ReadEncryptionKeyList(string path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Записывает список записей о поролях по пути passwordListPath и список ключей шифрования
        /// по пути encrypteKeyListPath.
        /// </summary>
        /// <param name="passwordListPath"></param>
        /// <param name="encryptionKeyListPath"></param>
        public void WritePasswordList(string passwordListPath, string encryptionKeyListPath) 
        {
            throw new NotImplementedException();
        }
    }
}
