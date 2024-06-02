using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Enigma
{
    internal class Plugboard : ElementEnigme,ISifrovanje
    {
        public char[] Izlazna { get; private set; }
        char kliknuto; // slovo koje je kliknuto
        public Plugboard()
        {
            Izlazna = new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' };
            kliknuto = '-';
        }
        public void KlikSlovo(char s)
        {
            //provera da li je vec povezano
            int i1 = s - 'A';
            if (Izlazna[i1] != '.') // vec je povezan
            {
                int i2 = Izlazna[i1] - 'A';// index drugog slova u paru
                Izlazna[i2] = '.';
                Izlazna[i1] = '.';
            }
            //provera da li je kliknuto drugo slovo u paru
            if (kliknuto == '-')
                kliknuto = s;
            else if (kliknuto == s)
                kliknuto = '-';
            else
                SpojiSlova(kliknuto, s);
        }
        private void SpojiSlova(char s1, char s2)
        {
            int i1 = s1 - 'A';
            int i2 = s2 - 'A';
            Izlazna[i1] = s2;
            Izlazna[i2] = s1;
            kliknuto = '-';
        }

        public char Sifruj(char x, bool smer = false)
        {
            return Izlazna[x - 'A'];
        }

        protected override void NacrtajElement(Canvas C)
        {
            char[] slova = ParsirajIzlazniNiz(Izlazna);
            NacrtajKvadratice(C);
            NacrtajLinijeIzmedjuKvadratica(C, slova);
        }
        public void NacrtajPlugboard(Canvas C)
        {
            NacrtajElement(C);
        }
        private char[] ParsirajIzlazniNiz(char[] izlazna)
        {
            char[] x = new char[izlazna.Length];
            for (int i = 0; i < x.Length; i++)
                if (izlazna[i] == '.') x[i] = (char)('A' + i);
                else x[i] = Izlazna[i];
            return x;
        }
    }
}
