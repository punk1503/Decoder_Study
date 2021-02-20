using System;

namespace Decoder_Study
{
    internal class Caesar : Cipher
    {
        public Caesar() : base()
        {
            name = "caesar";
            docDir = "..\\..\\Paragraphs\\Caesar.xaml";
            parameterRequired = true;
            parameterHintText = "Шаг по алфавиту";
        }

        private static string UniversalCode(string code = "", int step = 0)
        {
            string alphabet_ru_upper = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string alphabet_ru_lower = alphabet_ru_upper.ToLower();
            string alphabet_en_upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string alphabet_en_lower = alphabet_en_upper.ToLower();

            string output = string.Empty;

            for (int i = 0; i < code.Length; i++)
            {
                if (alphabet_ru_upper.Contains(code[i].ToString()))
                {
                    int index = (alphabet_ru_upper.Length + alphabet_ru_upper.IndexOf(code[i]) + step % alphabet_ru_upper.Length) % alphabet_ru_upper.Length;
                    output += alphabet_ru_upper[index];
                }
                else if (alphabet_ru_lower.Contains(code[i].ToString()))
                {
                    int index = (alphabet_ru_lower.Length + alphabet_ru_lower.IndexOf(code[i]) + step % alphabet_ru_lower.Length) % alphabet_ru_lower.Length;
                    output += alphabet_ru_lower[index];
                }
                else if (alphabet_en_upper.Contains(code[i].ToString()))
                {
                    int index = (alphabet_en_upper.Length + alphabet_en_upper.IndexOf(code[i]) + step % alphabet_en_upper.Length) % alphabet_en_upper.Length;
                    output += alphabet_en_upper[index];
                }
                else if (alphabet_en_lower.Contains(code[i].ToString()))
                {
                    int index = (alphabet_en_lower.Length + alphabet_en_lower.IndexOf(code[i]) + step % alphabet_en_lower.Length) % alphabet_en_lower.Length;
                    output += alphabet_en_lower[index];
                }
                else
                { output += code[i]; }
            }
            return output;
        }

        public override string Encode(string code, string parameter)
        {
            int step;
            Int32.TryParse(parameter, out step);
            return UniversalCode(code, step);
        }

        public override string Decode(string code, string parameter)
        {
            int step;
            Int32.TryParse(parameter, out step);
            return UniversalCode(code, -step);
        }
    }
}