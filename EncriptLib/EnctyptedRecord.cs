using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptLib
{
    public class EncryptedRecord
    {
        /// <summary>
        /// Создает шифруемую запись со значением value
        /// </summary>
        /// <param name="value">Шифруемое значение</param>
        public EncryptedRecord(string value) 
        {
            this.Value = (string)Value.Clone();
        }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="record">Шифруемая запись</param>
        public EncryptedRecord(EncryptedRecord record)
        {
            this.Value = (string)record.Value.Clone();
            this.KeyID = record.KeyID;
            this.isEncrypted = record.isEncrypted;
        }

        /// <summary>
        /// Строковое представление шифруемой записи.
        /// </summary>
        private string _value;
        
        /// <summary>
        /// Значение записи.
        /// </summary>
        public string Value {
            get => isEncrypted ?"**********": _value;
            private set =>_value = value;
        }
        
        /// <summary>
        /// Зашифровано ли значение.
        /// </summary>
        public bool isEncrypted{get; private set;}
        
        /// <summary>
        /// ID ключа, если значение зашифровано, иначе пустой Guid
        /// </summary>
        public Guid KeyID {get; private set;}
        
        /// <summary>
        /// Зашифровать запись используя ключ key
        /// </summary>
        /// <param name="key">Ключ шифрования</param>
        public void Encrypt(EncryptionKey key) 
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Расшифровать запись используя ключ key.
        /// </summary>
        /// <param name="key">Ключ шифрования</param>
        /// <returns>Возвращает true в случае успеха, иначе else</returns>
        public bool Decrypt(EncryptionKey key) 
        {
            throw new NotImplementedException();
        }

    }
}
