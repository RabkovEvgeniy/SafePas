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

        private static readonly string AttemptGetValueUninitializedKey = "Была произведена попытка " +
            "получить значении неинициализированного ключа";


        private int[] _value;
        public int[] Value 
        {
            get
            {
                if (_value == null) throw new Exception(AttemptGetValueUninitializedKey);
                return (int[])_value.Clone();
            }

            set 
            {
                if (value.Length != 100) throw new Exception(SizeOfSetValueArrayError);
                if (!value.All(i => i >= 0 && i <= 1103)) throw new Exception(SetValueError);
                
                _value = (int[])value.Clone();
            } 
        }
        public static EncryptionKey GetRandomEncryptionKey(Random random)
        {
            int[] Value = new int[100];
            for (int i = 0; i < 100; i++)
                Value[i] = random.Next(1103);

            return new EncryptionKey() {Value = Value};
        }
    }
}
    
