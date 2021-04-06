using System;
using System.Linq;

namespace Decoder_Study
{
    internal class Vigenere : Cipher
    {
        public Vigenere() : base("Vigenere")
        {
            parameterRequired = true;
            parameterHintText = "Ключевое слово";
        }

        public override string Encode(string code, string parameter)
        {
            string result = "";
            string alphabet_en_upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            for (int i = 0; i < code.Length; i++)
            {
                /*
                1. находим букву, с которой будет идти смещение для текущей code[i]
                2. находим индекс буквы параметра в алфавите
                3. берем из алфавита букву по индексу (индекс code[i] + индекс буквы параметра)
                4. добавляем букву в result
                */
                if (alphabet_en_upper.Contains(char.ToUpper(code[i])))
                {
                    Console.WriteLine("RESULT IS " + result);
                    int offset_index = alphabet_en_upper.IndexOf(char.ToUpper(parameter[i % parameter.Length]));
                    char new_letter = alphabet_en_upper[(alphabet_en_upper.IndexOf(char.ToUpper(code[i])) + offset_index) % alphabet_en_upper.Length];
                    result += char.IsUpper(code[i]) ? new_letter : char.ToLower(new_letter);
                }
                else
                {
                    result += code[i];
                }
            }
            return result;
        }

        public override string Decode(string code, string parameter)
        {
            string result = "";
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < code.Length; i++)
            {
                if (alphabet.Contains(code[i]))
                {
                    result += alphabet[(alphabet.IndexOf(code[i]) + alphabet.Length - alphabet.IndexOf(parameter[i % parameter.Length])) % alphabet.Length];
                }
                else
                {
                    result += code[i];
                }
            }
            return result;
        }
    }
}