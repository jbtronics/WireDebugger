/*   Copyright (C)  2017  Jan Böhmer
*
*    This program is free software; you can redistribute it and/or modify
*    it under the terms of the GNU General Public License as published by
*    the Free Software Foundation; either version 2 of the License, or
*    (at your option) any later version.
*
*    This program is distributed in the hope that it will be useful,
*    but WITHOUT ANY WARRANTY; without even the implied warranty of
*    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
*    GNU General Public License for more details.
*
*    You should have received a copy of the GNU General Public License along
*    with this program; if not, write to the Free Software Foundation, Inc.,
*    51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugWire
{
    public class Signature
    {
        byte[] _sig;

        /// <summary>
        /// Creates a Signature object with the given signature.
        /// </summary>
        /// <param name="sigbytes">A byte array containing a devices signature.</param>
        public Signature(byte[] sigbytes)
        {
            if (sigbytes.Length != 2)
                throw new ArgumentException("The sigbytes array has to contain 2 bytes.");
            _sig = sigbytes;
        }

        /// <summary>
        /// Convert the signature to a hexadecimal string in the format "0xZZZZ"
        /// </summary>
        /// <returns>A string representation of the signature bytes.</returns>
        public override string ToString()
        {
            return "0x" + BitConverter.ToString(_sig).Replace("-", String.Empty);
        }

        /// <summary>
        /// Convert the signature to a hexadecimal string.
        /// </summary>
        /// <param name="no_0x">true if no trailing "0x" should be added to the signature.</param>
        /// <returns>A string representation of the signature bytes.</returns>
        public string ToString(bool no_0x)
        {
            if (no_0x)
                return BitConverter.ToString(_sig).Replace("-", String.Empty);
            else
                return ToString();
        }

        /// <summary>
        /// Convert the signature bytes to the full device signature in the form "0x1EZZZZ"
        /// </summary>
        /// <returns>A hexadecimal string representation of the signature bytes.</returns>
        public string ToFullString()
        {
            return "0x1E" + BitConverter.ToString(_sig).Replace("-", String.Empty);
        }

        /// <summary>
        /// The name of the MCU with this signature.
        /// </summary>
        public string Name
        {
            get
            {
                switch (ToString())
                {
                    case "0x9007":
                        return "ATTiny13";
                    case "0x950f":
                        return "ATmega328P";
                    case "0x9514":
                        return "ATmega328";

                    default:
                        return "Unknown AVR";
                }
            }
        }

        /// <summary>
        /// A byte array containing the bytes of the device Signature
        /// </summary>
        public byte[] SignatureBytes{
            get
            {
                return _sig;
            }
        }
    }
}
