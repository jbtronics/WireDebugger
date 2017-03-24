using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugWire
{
    public class Address : TwoBytes
    {
        public Address(byte[] data) : base(data)
        {
        }
    }
}
