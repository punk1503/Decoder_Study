using System.Linq;

namespace Decoder_Study
{
    internal class Vigenere : Cipher
    {
        public Vigenere() : base()
        {
            name = "vigenere";
            docDir = "..\\..\\Paragraphs\\Vigenere.xaml";
            parameterRequired = true;
            parameterHintText = "Ключевое слово";
        }

        public override string Encode(string code, string parameter)
        {
            string result = "";
            string alphabet_en_upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            code = code.ToUpper();
            parameter = parameter.ToUpper();
            for (int i = 0; i < code.Length; i++)
            {
                if (alphabet_en_upper.Contains(code[i]))
                {
                    result += alphabet_en_upper[(alphabet_en_upper.IndexOf(code[i]) + alphabet_en_upper.IndexOf(parameter[i % parameter.Length])) % alphabet_en_upper.Length];
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