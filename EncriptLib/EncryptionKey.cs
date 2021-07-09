using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptLib
{
    public class EncryptionKey
    {
        const string LenthErrorMassage = "В переданном для иницализации ключа массиве не 100 эллементов";
        const string ValueErrorMassage = "В переданном для иницализации ключа массиве содержатся" +
            " эллементы, не входящие в диапазон 0..1103 включительно";

        /// <summary>
        /// Конструктор для создания ключа шифрования.
        /// </summary>
        /// <param name="id">ID ключа</param>
        /// <param name="Value">Ключ,массив целых чисел на 100 эллементов
        /// со значениями 0..1103 включительно</param>
        public EncryptionKey(Guid id, int[] Value) 
        {
            Id = id;
            if (Value.Length != 100) throw new Exception(LenthErrorMassage);

            if(!Value.All<int>(i=>i>=0&&i<=1103)) throw new Exception(ValueErrorMassage);
            this.Value = (int[])Value.Clone(); 
        }
        
        public EncryptionKey(Random random)
        {
            Id = Guid.NewGuid();

            Value = new int[100];
            for (int i = 0; i < 100; i++)
                Value[i] = random.Next(1103);
        }

        public Guid Id { get; private set; }

        private int[] Value;

        public int this[int a]
        {
            get
            {
                return Value[a % 100];
            }
        }
    }
}
    
