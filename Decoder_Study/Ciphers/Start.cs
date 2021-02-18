using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoder_Study
{
    internal class Start : Cipher
    {
        public Start() : base()
        {
            name = "start";
            docDir = "..\\..\\Paragraphs\\Start.xaml";
            parameterRequired = false;
        }
    }
}