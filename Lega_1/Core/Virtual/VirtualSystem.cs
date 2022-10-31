using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lega_1.Core.Virtual
{
    internal static class VirtualSystem
    {

        public static VirtualDisplay Display;
        public static VirtualMemory Memory;

        static VirtualSystem()
        {
            //0x000
            //0x080
            //0x1FF
            Memory = new VirtualMemory(512);
            Display = new VirtualDisplay();
            Span<byte> span = Memory.Data;
            Span<byte> backBuffer = span.Slice(0x000, 0x080);
            backBuffer[0] = 0;
        }

        public static byte Boot()
        {
            return 0x00;
        }

    }
}
