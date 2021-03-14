using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoder_Study
{
    internal class Xor : Cipher
    {
        public Xor() : base("Xor")
        {
            parameterRequired = true;
            parameterHintText = "Феникс";
        }

        public override string Encode(string code, string parameter)
        {
            string result = "";
            for (int i = 0; i < code.Length; i++)
            {
                result += (code[i] ^ parameter[i % parameter.Length]).ToString("X2") + " ";
            }
            return result;
        }

        public override string Decode(string code, string parameter)
        {
            return base.Decode(code, parameter);
        }
    }
}