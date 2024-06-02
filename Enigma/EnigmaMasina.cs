using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Enigma
{
    internal class EnigmaMasina : ISifrovanje
    {
        List<Rotor> rotori = new List<Rotor>();
        Reflektor reflektor = new Reflektor();
        Plugboard plugboard = new Plugboard();
        public string TokSifrovanja = null;
        public List<char> Pozicije { get; set; }
        public char Sifruj(char x, bool smer = false)
        {
            ZarotirajRotore();
            StringBuilder sb = new StringBuilder();
            sb.Append(x);
            sb.Append(x = plugboard.Sifruj(x));
            int t = x;
            for (int i = 0; i < rotori.Count; i++)
            {
                sb.Append(x = rotori[i].Sifruj((char)((t + Pozicije[i] - 'A' - 'A') % 26 + 'A')));
                t = (x - Pozicije[i] + 26) % 26 + 'A';
            }
            x = reflektor.Sifruj((char)t);
            t = x;
            for (int i = 0; i < rotori.Count; i++)
            {
                sb.Append(x = rotori[i].Sifruj((char)((t + Pozicije[i] - 'A' - 'A') % 26 + 'A'), true));
                t = (x - Pozicije[i] + 26) % 26 + 'A';
            }
            sb.Append(x = plugboard.Sifruj((char)t));
            TokSifrovanja = sb.ToString();
            return x;
        }

        private void ZarotirajRotore()
        {
            for (int i = 0; i < rotori.Count; i++)
            {
                char x = Pozicije[i];
                Pozicije[i] = (char)((Pozicije[i] + 1) % 26 + 'A');
                if (x != rotori[i].ObrtniZarez) break;
            }
        }

        public EnigmaMasina(List<Rotor> rotori, Reflektor reflektor, Plugboard plugboard, List<char> pozicije)
        {
            if (rotori.Count != pozicije.Count)
                throw new Exception("Rotori nisu dobro prosledjeni.");
            for (int i = 0; i < pozicije.Count; i++)
                if (pozicije[i]-'A' < 0 || pozicije[i] -'A' > 26)
                    throw new Exception("Pozicije moraju biti slova od 'A' do 'Z'.");
            Pozicije = pozicije;
            this.rotori = rotori;
            this.plugboard = plugboard;
            this.reflektor = reflektor;
        }
        public void NacrtajEnigmu(List<Canvas> rotoriPlatna, Canvas reflektorPlatno, Canvas plugboardPlatno)
        {
            if (rotoriPlatna.Count != rotori.Count)
                throw new Exception("Unet razlicit broj Canvasa od broja rotora.");
            for (int i = 0; i < rotori.Count; i++)
                rotori[i].NacrtajRotor(rotoriPlatna[i],Pozicije[i]);
            reflektor.NacrtajReflektor(reflektorPlatno);
            plugboard.NacrtajPlugboard(plugboardPlatno);
        }
    }
}
