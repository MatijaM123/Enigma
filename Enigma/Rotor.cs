using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    internal class Rotor : ISifrovanje
    {
        List<char> elementi = new List<char>();
        public char Sifruj(char x, bool SuprotniSmer = false) => SuprotniSmer?(char)('A'+elementi.IndexOf(x)):elementi[x - 'A'];
    }
}
