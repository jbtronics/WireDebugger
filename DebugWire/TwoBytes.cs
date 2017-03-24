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
        /// Creates a new TwoBytes object from the given hexadecimal string in the format "0xZZZZ"
        /// </summary>
        /// <param name="data">A string in the format "0xZZZZ"</param>
        public TwoBytes(string data)
        {
            if (data.StartsWith("0x", StringComparison.CurrentCultureIgnoreCase) ||
                 data.StartsWith("&H", StringComparison.CurrentCultureIgnoreCase))
            {
                data = data.Substring(2);
            }
            var s = ushort.Parse(data, System.Globalization.NumberStyles.HexNumber);
            _data = reverseBytes(BitConverter.GetBytes(s));
        }

        public TwoBytes(ushort data)
        {
            _data = reverseBytes(BitConverter.GetBytes(data));
        }
        
        /// <summary>
        /// Returns the two bytes as a unsigned short.
        /// </summary>
        /// <returns>A ushort containing the two bytes.</returns>
        public ushort ToShort()
        {
            return BitConverter.ToUInt16(_data, 0);
        }

        public byte[] Bytes
        {
            get
            {
                return _data;
            }
        }

        private byte[] reverseBytes(byte[] data)
        {
            byte[] b = { data[1], data[0] };
            return b;

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
