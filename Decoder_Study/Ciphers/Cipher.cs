namespace Decoder_Study
{
    internal abstract class Cipher
    {
        private readonly string name;
        public string docDir;

        public Cipher(string n = "empty")
        {
            name = n;
        }

        public virtual string Decode(string code, int parameter)
        {
            return "Empty";
        }

        public virtual string Encode(string code, int parameter)
        {
            return "Empty";
        }
    }
}