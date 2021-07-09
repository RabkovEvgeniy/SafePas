using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptLib
{
    public class EncryptedRecord:ICloneable
    {
        private EncryptedRecord() { }
        
        /// <summary>
        /// Создает шифруемую запись со значением value
        /// </summary>
        /// <param name="value">Шифруемое значение</param>
        public EncryptedRecord(string value) 
        {
            Value = (string)value.Clone();
        }

        /// <summary>
        /// Строковое представление шифруемой записи.
        /// </summary>
        private string _value;
        
        /// <summary>
        /// Значение записи.
        /// </summary>
        public string Value {
            get => isEncrypted ?"**********": (string)_value.Clone();
            private set =>_value = (string)value.Clone();
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

        public object Clone()
        {
            return new EncryptedRecord
            {
                Value = (string)Value.Clone(),
                KeyID = KeyID,
                isEncrypted = isEncrypted
            };
        }
    }
}
