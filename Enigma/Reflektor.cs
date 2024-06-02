using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Enigma
{
    internal class Reflektor : ElementEnigme, ISifrovanje
    {

        List<char> elementi = new List<char>();
        public char Sifruj(char x, bool smer = false) => elementi[x - 'A'];

        protected override void NacrtajElement(Canvas C)
        {
            NacrtajKvadratice(C);
        }
        public void NacrtajReflektor(Canvas C) { NacrtajElement(C); }
    }
}
