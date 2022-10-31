using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lega_1.Core.Virtual
{
    internal class VirtualDisplay
    {
        public void Fill(byte value)
        {
            Span<byte> span = VirtualSystem.Memory.Data;
            Span<byte> backBuffer = span.Slice(0x000, 0x080);
            backBuffer.Fill(value);
        }
    }
}
