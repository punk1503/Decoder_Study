using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoder_Study
{
    internal class Hex : Cipher
    {
        public Hex()
        {
            name = "Hex";
            docDir = docDir + name + ".xaml";
            parameterRequired = false;
        }

        public override string Decode(string code, string parameter)
        {
            string result = String.Empty;
            code = code.Replace(" ", "");
            for (int i = 0; i < code.Length; i += 2)
            {
                result += Convert.ToChar(Convert.ToUInt32(code.Substring(i, 2), 16));
            }

            return result;
        }

        public override string Encode(string code, string parameter)
        {
            string result = String.Empty;
            code = code.Replace(" ", "");
            for (int i = 0; i < code.Length; i++)
            {
                result += string.Format("{0:x2}", (byte)code[i]);
            }

            return result;
        }
    }
}