using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decoder_Study
{
    internal class Hex : Cipher
    {
        private Encoding enc_1251 = Encoding.GetEncoding(1251);

        public Hex() : base("Hex")
        {
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
            string result = "";
            /*1. переводим строчку в набор чисел в 10 СС
            2. переводим 10СС в 16СС
            3. добавляем значение и пробел в result*/
            byte[] decimal_values = enc_1251.GetBytes(code);
            foreach (byte val in decimal_values)
            {
                result += val.ToString("X") + ' ';
            }

            return result;
        }
    }
}