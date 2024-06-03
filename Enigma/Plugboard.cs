using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace Enigma
{
    struct PlugSlovo
    {
        public char Slovo;
        public int IdBoje;
        public Button Dugme;
        public PlugSlovo(char slovo, int idBoje, Button dugme = null)
        {
            Slovo = slovo; IdBoje = idBoje; Dugme = dugme;
        }
    }

    internal class Plugboard : ElementEnigme,ISifrovanje
    {
        public PlugSlovo[] Izlazna { get; private set; } // sadrzi slovo i index boje
        (Color boja, bool zauzeta)[] bojeSlova;
        char prethodni;
        public Plugboard()
        {
            Izlazna = new PlugSlovo[]
            {
                 new PlugSlovo('.', -1,new Button()), new PlugSlovo('.', -1,new Button()), new PlugSlovo('.', -1,new Button()),
                 new PlugSlovo('.', -1,new Button()), new PlugSlovo('.', -1,new Button()), new PlugSlovo('.', -1,new Button()),
                 new PlugSlovo('.', -1,new Button()), new PlugSlovo('.', -1,new Button()), new PlugSlovo('.', -1,new Button()),
                 new PlugSlovo('.', -1,new Button()), new PlugSlovo('.', -1,new Button()), new PlugSlovo('.', -1,new Button()),
                 new PlugSlovo('.', -1,new Button()), new PlugSlovo('.', -1,new Button()), new PlugSlovo('.', -1,new Button()),
                 new PlugSlovo('.', -1,new Button()), new PlugSlovo('.', -1,new Button()), new PlugSlovo('.', -1,new Button()),
                 new PlugSlovo('.', -1,new Button()), new PlugSlovo('.', -1,new Button()), new PlugSlovo('.', -1,new Button()),
                 new PlugSlovo('.', -1,new Button()), new PlugSlovo('.', -1,new Button()), new PlugSlovo('.', -1,new Button()),
                 new PlugSlovo('.', -1,new Button()), new PlugSlovo('.', -1,new Button())
            };
            prethodni = '-';
            bojeSlova = new (Color,bool)[] // 26 slova, 13 boja
            {
                (Color.FromArgb(255, 255, 0, 0), false),      // Crvena
                (Color.FromArgb(255, 255, 255, 0), false),    // Zuta
                (Color.FromArgb(255, 0, 0, 255), false),      // Plava
                (Color.FromArgb(255, 0, 255, 0), false),      // Zelena
                (Color.FromArgb(255, 238, 130, 238), false),  // SvetloLjubicasta 
                (Color.FromArgb(255, 173, 216, 230), false),  // SvetloPlava
                (Color.FromArgb(255, 255, 165, 0), false),    // Narandzasta 
                (Color.FromArgb(255, 139, 69, 19), false),    // TamnoBraon 
                (Color.FromArgb(255, 128, 0, 128), false),    // TamnoLjubicasta 
                (Color.FromArgb(255, 0, 100, 0), false),      // TamnoZelena
                (Color.FromArgb(255, 210, 180, 140), false),  // SvetloBraon 
                (Color.FromArgb(255, 144, 238, 144), false),  // SvetloZelena 
                (Color.FromArgb(255, 70, 130, 180), false)    // MutnoPlava 
            };
        }
        private int IzaberiBoju() // biranje prve slobodne boje
        {
            for (int i = 0; i < bojeSlova.Length; i++)
                if (!bojeSlova[i].zauzeta)
                {
                    return i;
                }
            return -1; // nemoguc slucaj
        }
        int trBoja;
        bool spec = false;//specijalan slucaj gde se spojeni par razdvaja nakon sto je pritisnut samo 1 slovo
        private void KlikSlovo(char s) // updateuje Izlazni niz slova
        {
            int i1 = s - 'A'; 
            if (Izlazna[i1].Slovo != '.') //provera da li je vec povezano, brisanje
            {
                
                int i2 = Izlazna[i1].Slovo - 'A';
                char p = prethodni; // pomocna
                if (prethodni>45 && !bojeSlova[Izlazna[prethodni - 'A'].IdBoje].zauzeta)
                { trBoja = Izlazna[prethodni - 'A'].IdBoje; spec = true; }
                RazdvojiSlova(i1,i2);
                if (spec) prethodni = p;
                return;
            }
            if (!spec)
            { trBoja = IzaberiBoju(); }
            spec = false;
            Izlazna[i1].IdBoje = trBoja;
            if (prethodni == '-') //provera da li je prvo ili drugo slovo u paru
            {
                prethodni = s; ObojiDugme(Izlazna[i1]);
            }
            else if (prethodni == s) // prethodni slovo je vec u upotrebi, brisanje
            {  
                Izlazna[i1].Slovo = '.'; Izlazna[i1].IdBoje = -1; prethodni = '-'; ObojiDugme(Izlazna[i1]);
            }
            else 
            {
                int i2 = prethodni - 'A';
                SpojiSlova(s,prethodni);
            }

        }
        private void ObojiDugme(PlugSlovo x)
        {
            if (x.IdBoje == -1) // nema boje
                x.Dugme.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            else
                x.Dugme.Background = new SolidColorBrush(bojeSlova[x.IdBoje].boja);
        }
        private void RazdvojiSlova(int i1, int i2)
        {
            Izlazna[i2].Slovo = '.';
            Izlazna[i1].Slovo = '.';
            prethodni = '-';
            bojeSlova[Izlazna[i1].IdBoje].zauzeta = false;
            Izlazna[i1].IdBoje = -1;
            Izlazna[i2].IdBoje = -1;
            ObojiDugme(Izlazna[i1]); 
            ObojiDugme(Izlazna[i2]);
        }
        private void SpojiSlova(char s1, char s2)
        {
            int i1 = s1 - 'A';
            int i2 = s2 - 'A';
            Izlazna[i1].Slovo = s2; 
            Izlazna[i2].Slovo = s1;
            prethodni = '-';
            bojeSlova[trBoja].zauzeta = true;
            ObojiDugme(Izlazna[i1]); 
            ObojiDugme(Izlazna[i2]);
        }
        public void BtnKlikSlovo(object sender) // Kliknut buttton u aplikacji, prosledjuje se slovo
        {
            Button dugme = sender as Button;
            char[] pom = sender.ToString().ToCharArray();
            char slovo = pom[pom.Length - 1];
            Izlazna[slovo-'A'].Dugme = dugme;
            KlikSlovo(slovo);
        }
        public char Sifruj(char x, bool smer = false) // vraca slovo koje je spojeno sa unetim slovom
        {
            return Izlazna[x - 'A'].Slovo=='.'?(char)(x+'A'): Izlazna[x - 'A'].Slovo;
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
        private char[] ParsirajIzlazniNiz(PlugSlovo[] izlazna)
        {
            char[] x = new char[izlazna.Length];
            for (int i = 0; i < x.Length; i++)
                if (izlazna[i].Slovo == '.') x[i] = (char)('A' + i);
                else x[i] = Izlazna[i].Slovo;
            return x;
        }
    }
}
