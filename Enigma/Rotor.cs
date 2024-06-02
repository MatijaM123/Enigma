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
        public Rotor(int redBroj)
        {
            if (redBroj < 1 || redBroj > 5)
                throw new Exception($"Ne postoji rotor {redBroj}");
            switch (redBroj) 
            {
                case 1:
                    char[] t1 = { 'E', 'K', 'M', 'F', 'L', 'G', 'D', 'Q', 'V', 'Z', 'N', 'T', 'O', 'W', 'Y', 'H', 'X', 'U', 'S', 'P', 'A', 'I', 'B', 'R', 'C', 'J' };
                    elementi = new List<char>(t1);
                    ObrtniZarez = 'Q';
                    break;
                case 2:
                    char[] t2 = { 'A', 'J', 'D', 'K', 'S', 'I', 'R', 'U', 'X', 'B', 'L', 'H', 'W', 'T', 'M', 'C', 'Q', 'G', 'Z', 'N', 'P', 'Y', 'F', 'V', 'O', 'E' };
                    elementi = new List<char>(t2);
                    ObrtniZarez = 'E';
                    break;
                case 3:
                    char[] t3 = { 'B', 'D', 'F', 'H', 'J', 'L', 'C', 'P', 'R', 'T', 'X', 'V', 'Z', 'N', 'Y', 'E', 'I', 'W', 'G', 'A', 'K', 'M', 'U', 'S', 'Q', 'O'};
                    elementi = new List<char>(t3);
                    ObrtniZarez = 'V';
                    break;
                case 4:
                    char[] t4 = { 'E', 'S', 'O', 'V', 'P', 'Z', 'J', 'A', 'Y', 'Q', 'U', 'I', 'R', 'H', 'X', 'L', 'N', 'F', 'T', 'G', 'K', 'D', 'C', 'M', 'W', 'B'};
                    elementi = new List<char>(t4);
                    ObrtniZarez = 'J';
                    break;
                case 5:
                    char[] t5 = { 'V', 'Z', 'B', 'R', 'G', 'I', 'T', 'Y', 'U', 'P', 'S', 'D', 'N', 'H', 'L', 'X', 'A', 'W', 'M', 'J', 'Q', 'O', 'F', 'E', 'C', 'K'};
                    elementi = new List<char>(t5);
                    ObrtniZarez = 'Z';
                    break;
            }
        }
    }
}
