using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoder_Study
{
    internal class Hex : Cipher
    {
        private Encoding enc_1251 = Encoding.GetEncoding(1251);

        public Hex()
        {
            name = "Hex";
            docDir = docDir + name + ".xaml";
            parameterRequired = false;
        }

        public override string Decode(string code, string parameter)
        {
            string result = "";

            List<String> hex_values = code.Split(' ').ToList();
            foreach (string val in hex_values)
            {
                /*1. перевести значение в 10 СС
                 2. получить из этого значения букву
                 3. добавить эту букву в result*/
                int decimal_val = Convert.ToInt32(val, 16);
                string letter = enc_1251.GetString(new byte[] { (byte)decimal_val });
                result += letter;
            }

            return result;
        }

        public override string Encode(string code, string parameter)
        {
            string result = String.Empty;
            for (int i = 0; i < code.Length; i++)
            {
                result += string.Format("{0:x2}", (byte)code[i]);
            }

            return result;
        }
    }
}