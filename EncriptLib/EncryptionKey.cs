using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptLib
{
    public class EncryptionKey
    {
        EncryptionKey(Guid id, int[] Value) 
        {
            Id = id;
            this.Value = (int[])Value.Clone(); 
        }
        EncryptionKey(Random random)
        {
            Id = Guid.NewGuid();

            Value = new int[100];
            for (int i = 0; i < 100; i++)
                Value[i] = random.Next();
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
    
