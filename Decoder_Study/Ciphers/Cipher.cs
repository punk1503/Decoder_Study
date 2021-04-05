namespace Decoder_Study
{
    internal abstract class Cipher
    {
        public string name;
        public string docDir = "..\\..\\Paragraphs\\";
        public bool parameterRequired;
        public string parameterHintText = "Параметр";

        public Cipher(string name_param)
        {
            name = name_param;
            docDir = $"..\\..\\Paragraphs\\{name_param}.xaml";
        }

        public virtual string Decode(string code, string parameter)
        {
            return null;
        }

        public virtual string Encode(string code, string parameter)
        {
            return null;
        }
    }
}