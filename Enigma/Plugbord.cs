using System;

public class Plugboard : IUlazIzlaz
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
        int i1 = s - 97;
        if (Izlazna[i1] != '.') // vec je povezan
        {
            int i2 = Izlazna[i1] - 97;// index drugog slova u paru
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
        int i1 = s1 - 97;
        int i2 = s2 - 97;
        Izlazna[i1] = s2;
        Izlazna[i2] = s1;
        kliknuto = '-';
    }
}
