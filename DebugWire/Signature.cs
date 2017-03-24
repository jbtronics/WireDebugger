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

        public Signature(byte[] sigbytes)
        {
            if (sigbytes.Length != 2)
                throw new ArgumentException("The sigbytes array has to contain 2 bytes.");
            _sig = sigbytes;
        }


        public override string ToString()
        {
            return "0x" + BitConverter.ToString(_sig).Replace("-", String.Empty);
        }

        public string ToString(bool no_0x)
        {
            if (no_0x)
                return BitConverter.ToString(_sig).Replace("-", String.Empty);
            else
                return ToString();
        }

        public string ToFullString()
        {
            return "0x1E" + BitConverter.ToString(_sig).Replace("-", String.Empty);
        }

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
