using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    internal interface ISifrovanje
    {
        char Sifruj(char x,bool smer = false);
    }
}
