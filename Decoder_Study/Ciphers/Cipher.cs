namespace Decoder_Study
{
    internal abstract class Cipher
    {
        protected string name;
        public string docDir;

        public Cipher()
        {
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