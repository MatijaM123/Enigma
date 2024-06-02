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
        public Reflektor(int redBroj)
        {
            if (redBroj < 0 || redBroj > 1)
                throw new Exception($"Ne postoji rotor {redBroj}");
            else
            {
                if(redBroj == 0)
                {
                    elementi.Add('Y');
                    elementi.Add('R');
                    elementi.Add('U');
                    elementi.Add('H');
                    elementi.Add('Q');
                    elementi.Add('S');
                    elementi.Add('L');
                    elementi.Add('D');
                    elementi.Add('P');
                    elementi.Add('X');
                    elementi.Add('N');
                    elementi.Add('G');
                    elementi.Add('O');
                    elementi.Add('K');
                    elementi.Add('M');
                    elementi.Add('I');
                    elementi.Add('E');
                    elementi.Add('B');
                    elementi.Add('F');
                    elementi.Add('Z');
                    elementi.Add('C');
                    elementi.Add('W');
                    elementi.Add('V');
                    elementi.Add('J');
                    elementi.Add('A');
                    elementi.Add('T');
                }
                else
                {
                    elementi.Add('F');
                    elementi.Add('V');
                    elementi.Add('P');
                    elementi.Add('J');
                    elementi.Add('I');
                    elementi.Add('A');
                    elementi.Add('O');
                    elementi.Add('Y');
                    elementi.Add('E');
                    elementi.Add('D');
                    elementi.Add('R');
                    elementi.Add('Z');
                    elementi.Add('X');
                    elementi.Add('W');
                    elementi.Add('G');
                    elementi.Add('C');
                    elementi.Add('T');
                    elementi.Add('K');
                    elementi.Add('U');
                    elementi.Add('Q');
                    elementi.Add('S');
                    elementi.Add('B');
                    elementi.Add('N');
                    elementi.Add('M');
                    elementi.Add('H');
                    elementi.Add('L');
                }
            }
        }
    }
}
