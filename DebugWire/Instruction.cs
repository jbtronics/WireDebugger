using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugWire
{
    public class Instruction : TwoBytes
    {
        public Instruction(byte[] data) : base(data)
        {
        }
    }
}
