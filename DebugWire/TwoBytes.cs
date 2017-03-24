using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugWire
{
    public class TwoBytes
    {
        private byte[] _data;

        /// <summary>
        /// Creates a new TwoBytes object from the given bytes.
        /// </summary>
        /// <param name="data">A byte array containing the two bytes.</param>
        public TwoBytes(byte[] data)
        {
            if (data.Length != 2)
                throw new ArgumentException("The data array has to contain two bytes!");

            _data = data;
        }
        
        /// <summary>
        /// Returns the two bytes as a short.
        /// </summary>
        /// <returns>A short containing the two bytes.</returns>
        public short ToShort()
        {
            return BitConverter.ToInt16(_data, 0);
        }
       
        /// <summary>
        /// Returns a string representation of the two bytes in the format "0xZZZZ"
        /// </summary>
        /// <returns>A string with the two bytes in hexadecimal.</returns>
        public override string ToString()
        {
            return "0x" + BitConverter.ToString(_data).Replace("-", string.Empty);     
        }

    }
}
