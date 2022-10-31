using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lega_1.Core
{
    internal static class Util
    {

        public static Color[] FromByte(Span<byte> data)
        {
            var result = new List<Color>();
            var bitArray = new BitArray(data.ToArray());
            foreach (var bit in bitArray)
            {
                result.Add((bool)bit ? Color.White: Color.Black);
            }
            return result.ToArray();
        }

    }
}
