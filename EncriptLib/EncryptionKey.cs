using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptLib
{
    [Serializable]
    public class EncryptionKey
    {
        [NonSerialized]
        static readonly string SizeOfSetValueArrayError = "Переданный для установки значения ключа массив " +
            "хранит не 100 элементов";
        
        [NonSerialized]
        private static readonly string SetValueError = "Элементы переданного для установки значения " +
            "ключа массива, не лежат в диапозоне 0..1103";
        
        private int[] _value;
        public int[] Value 
        {
            get => (int[])_value.Clone();
            
            set 
            {
                if (value.Length != 100) throw new Exception(SizeOfSetValueArrayError);
                if (!value.All(i => i >= 0 && i <= 1103)) throw new Exception(SetValueError);
                
                _value = (int[])value.Clone();
            } 
        }
        public static EncryptionKey GetRandomEncryptionKey(Random random)
        {
            EncryptionKey key = new EncryptionKey();

            key.Value = new int[100];
            for (int i = 0; i < 100; i++)
                key.Value[i] = random.Next(1103);

            return key;
        }
    }
}
    
