using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace Enigma
{
    internal class Rotor : ElementEnigme, ISifrovanje 
    {
        List<char> elementi = new List<char>();
        public char ObrtniZarez {  get; private set; }
        char trenutnoSlovo;
        public char Sifruj(char x, bool SuprotniSmer = false) => SuprotniSmer?(char)('A'+elementi.IndexOf(x)):elementi[x - 'A'];
        protected override void NacrtajElement(Canvas C)
        {
            NacrtajKvadratice(C, trenutnoSlovo);
            NacrtajLinijeIzmedjuKvadratica(C, elementi.ToArray(), trenutnoSlovo);
            //CRTANJE NOTCHA
        }
        public void NacrtajRotor(Canvas C, char trSlovo)
        {
            trenutnoSlovo = trSlovo;
            NacrtajElement(C);
        }
    }
}
