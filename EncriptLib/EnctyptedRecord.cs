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
        /// <returns>Возвращает true в случае успеха, иначе false</returns>
        public bool Encrypt(EncryptionKey key) 
        {
            char[] encryptedValue = new char[_value.Length];
            if (!isEncrypted) 
            {
                for (int i = 0; i < _value.Length; i++)
                {
                    encryptedValue[i] = (char)((_value[i] + key[i]) % 1104);
                }
                _value = new string(encryptedValue);
                
                KeyID = key.Id;
                isEncrypted = true;
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Расшифровать запись используя ключ key.
        /// </summary>
        /// <param name="key">Ключ шифрования</param>
        /// <returns>Возвращает true в случае успеха, иначе false</returns>
        public bool Decrypt(EncryptionKey key) 
        {
            char[] decryptedValue = new char[_value.Length];
            if (isEncrypted && KeyID == key.Id)
            {
                for (int i = 0; i < _value.Length; i++)
                {
                    if (_value[i] < key[i])
                        decryptedValue[i] = (char)(1104 + _value[i]- key[i]);
                    else 
                        decryptedValue[i] = (char)(_value[i] - key[i]);
                }
                _value = new string(decryptedValue);

                KeyID = Guid.Empty;
                isEncrypted = false;
                return true;
            }
            else return false;
        }

        public object Clone()
        {
            return new EncryptedRecord
            {
                Value = (string)_value.Clone(),
                KeyID = KeyID,
                isEncrypted = isEncrypted
            };
        }
    }
}
