using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    internal class Reflektor : ISifrovanje
    {

        List<char> elementi = new List<char>();
        public char Sifruj(char x, bool smer = false) => elementi[x - 'A'];
    }
}
