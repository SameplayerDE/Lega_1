using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lega_1.Core.Virtual
{
    internal class VirtualMemory
    {
        public byte[] Data;
        public VirtualMemory(int lenght)
        {
            Data = new byte[lenght];
        }

        public void Poke(int from, int to, byte value)
        {
            for (var i = from; i < to; i++)
            {
                Data[i] = value;
            }
        }

        public void Poke(int adress, byte value)
        {
            Data[adress] = value;
        }

        public byte Peek(int adress)
        {
            return Data[adress];
        }
    }
}
