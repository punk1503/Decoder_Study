using System;
using System.Collections.Generic;
using System.Linq;
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

        public override string Decode(string code, string parameter)
        {
            string result = "";

            code = code.Replace(" ", "");
            bool first_char_zero = code[0] == 0;
            code = code.Substring(1);
            List<int> alias_fragments_values = new List<int>();
            int zero_counter = 0;
            for (int i = 0; i < code.Length; i++)
            {
                if (code[i] == '0')
                {
                    zero_counter++;
                }
                else
                {
                    alias_fragments_values.Add(Convert.ToInt32(code.Substring(i - zero_counter, zero_counter * 2 + 1), 2));
                    i += zero_counter;
                    zero_counter = 0;
                }
            }
            string result_binary = "";
            foreach (int value in alias_fragments_values)
            {
                if (first_char_zero)
                {
                    result_binary += string.Concat(Enumerable.Repeat("0", value));
                }
                else
                {
                    result_binary += string.Concat(Enumerable.Repeat("1", value));
                }
                first_char_zero = !first_char_zero;
            }

            for (int i = 0; i < result_binary.Length; i += 4)
            {
            }
            /*for (int i = 0; i < result_binary.Length; i += 8)
            {
                int ascii_val = Convert.ToInt32(result_binary.Substring(i, 8), 2);
                byte[] b = { (byte)Convert.ToInt32(result_binary.Substring(i, 8), 2) };
                result += enc.GetString(b);
            }*/
            return result;
        }
    }
}