using System;
using System.Collections.Generic;
using System.Text;

namespace Decoder_Study
{
    internal class Alias : Cipher
    {
        private Encoding enc = Encoding.GetEncoding(1251);

        public Alias() : base("Alias")
        {
            parameterRequired = false;
        }

        public override string Encode(string code, string parameter)
        {
            string result = "";
            byte[] code_bytes = enc.GetBytes(code);
            string binary_values = "";
            for (int i = 0; i < code_bytes.Length; i++)
            {
                binary_values += Convert.ToString(code_bytes[i], 2).PadLeft(8, '0');
            }

            result += binary_values[0];
            List<string> grouped_values = new List<string>();
            char last = '\0';
            foreach (char c in binary_values)
            {
                if (c != last)
                {
                    grouped_values.Add(c.ToString());
                }
                else
                {
                    grouped_values[grouped_values.Count - 1] += c;
                }
                last = c;
            }

            for (int i = 0; i < grouped_values.Count; i++)
            {
                grouped_values[i] = Convert.ToString(grouped_values[i].Length, 2);
                grouped_values[i] = grouped_values[i].PadLeft(grouped_values[i].Length * 2 - 1, '0');
                result += grouped_values[i];
            }

            return result;
        }
    }
}