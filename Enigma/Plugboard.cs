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
    internal class Plugboard : ElementEnigme,ISifrovanje
    {
        public (char slovo,int idBoje)[] Izlazna { get; private set; } // sadrzi slovo i index boje
        (Color boja, bool zauzeta)[] bojeSlova;
        char kliknuto; // slovo koje je kliknuto
        public Plugboard()
        {
            Izlazna = new (char, int)[]
            {
                 ('.', -1), ('.', -1), ('.', -1),
                 ('.', -1), ('.', -1), ('.', -1),
                 ('.', -1), ('.', -1), ('.', -1),
                 ('.', -1), ('.', -1), ('.', -1),
                 ('.', -1), ('.', -1), ('.', -1),
                 ('.', -1), ('.', -1), ('.', -1),
                 ('.', -1), ('.', -1), ('.', -1),
                 ('.', -1), ('.', -1), ('.', -1),
                 ('.', -1), ('.', -1)
            };
            kliknuto = '-';
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
                    return i;
            return -1; // nemoguc slucaj
        }
        private void KlikSlovo(char s) // updateuje Izlazni niz slova
        {
            int i1 = s - 'A';
            int trBoja = IzaberiBoju();
            Izlazna[i1].idBoje = trBoja;
            if (Izlazna[i1].slovo != '.') //provera da li je vec povezano, brisanje
            {
                int i2 = Izlazna[i1].slovo - 'A';// index drugog slova u paru
                Izlazna[i2].slovo = '.'; Izlazna[i2].idBoje = -1;
                Izlazna[i1].slovo = '.'; Izlazna[i1].idBoje = -1;
                bojeSlova[trBoja].zauzeta = false;
                return;
            }
            if (kliknuto == '-') //provera da li je prvo ili drugo slovo u paru
                kliknuto = s;
            else if (kliknuto == s) // kliknuto slovo je vec u upotrebi, brisanje
            { kliknuto = '-'; Izlazna[i1].slovo = '.'; Izlazna[i1].idBoje = -1; }
            else // 
                SpojiSlova(s, kliknuto, trBoja);
        }
        private void SpojiSlova(char s1, char s2,int trBoja)
        {
            int i1 = s1 - 'A';
            int i2 = s2 - 'A';
            Izlazna[i1].slovo = s2; 
            Izlazna[i2].slovo = s1; 
            bojeSlova[trBoja].zauzeta = true;
            kliknuto = '-';
        }
        public void BtnKlikSlovo(object sender) // Kliknut buttton u aplikacji, prosledjuje se slovo
        {
            Button dugme = sender as Button;
            char slovo = (char)dugme.Content;
            KlikSlovo(slovo);
            int idBoje = Izlazna[slovo - 'A'].idBoje;
            if (idBoje == -1) // ne treba da bude obojen
                dugme.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0)); // siva/crna?
            else
                dugme.Background = new SolidColorBrush(bojeSlova[idBoje].boja);
        }
        public char Sifruj(char x, bool smer = false) // vraca slovo koje je spojeno sa unetim slovom
        {
            return Izlazna[x - 'A'].slovo;
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
