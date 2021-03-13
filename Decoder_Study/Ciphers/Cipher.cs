namespace Decoder_Study
{
    internal abstract class Cipher
    {
        public string name;
        public string docDir = "..\\..\\Paragraphs\\";
        public bool parameterRequired;
        public string parameterHintText = "Параметр";

        public Cipher()
        {
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