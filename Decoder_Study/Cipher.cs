using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoder_Study
{
    internal abstract class Cipher
    {
        private readonly string name;

        public Cipher(string n = "empty")
        {
            name = n;
        }

        public virtual string Decode(string code, int parametr)
        {
            return "Empty:" + code;
        }

        public virtual string Encode(string code, int parametr)
        {
            return "Empty:" + code;
        }
    }
}