﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if (Regex.IsMatch(code, @"\p{IsCyrillic}"))
            {
                result = "Строка не должна содержать кириллицу";
            }
            else
            {
                for (int i = 0; i < code.Length; i++)
                {
                    result += (code[i] ^ parameter[i % parameter.Length]).ToString("X2") + " ";
                }
            }
            return result;
        }

        public override string Decode(string code, string parameter)
        {
            code = code.Replace(" ", "");

            string result = "";
            for (int i = 0; i < code.Length; i += 2)
            {
                result += Convert.ToChar(Convert.ToUInt32(code.Substring(i, 2), 16) ^ parameter[(i / 2) % parameter.Length]);
            }
            return result;
        }
    }
}