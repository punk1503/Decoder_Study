using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoder_Study
{
    internal abstract class Cipher
    {
        public string name;
        public string docDir;
        public bool parameterRequired;
        public string parameterHintText = "Параметр";

        public Cipher()
        {
        }

        public virtual string Decode(string code, string parameter)
        {
            return null;
        }

        public virtual string Encode(string code, string parameter)
        {
            return null;
        }
    }
}