using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Drawing;
using System.Windows.Shapes;
using System.IO;
using System.Threading;


namespace Enigma
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Loaded += Load;
            InitializeComponent();
        }
        internal EnigmaMasina enigma;
        public int Rotor1, Rotor2, Rotor3;
        public int SacuvajReflektor;
        public TextBlock Ulaz { get => nesifrovaniTekst; }
        public TextBlock Izlaz { get => sifrovaniTekst; }
        List<char> pozicije = new List<char>();
        List<Rotor> rotori;
        Reflektor reflektor;
        Podesavanja podesavanja;
        EnigmaIspodHaube animacija;
        Color svetlo = new Color();
        int brojacBoja = 0;
        char trenutnoSlovoPlug = ' ';
        Plugboard plugboard = new Plugboard();
        SolidColorBrush[] boje = new SolidColorBrush[13];
        Ellipse[] svetla = new Ellipse[26];
        object pocetniIzgledSvetla;
        public StringBuilder sr = new StringBuilder();
        private void Load(object sender, RoutedEventArgs e)
        {
            // Forma.Focus();
            svetlo = NapraviRGB(255, 189, 89);
            NapraviBoje();
            NapraviSvetla();
            pocetniIzgledSvetla = (RadialGradientBrush)As.Fill;
            Rotor1 = 3;
            Rotor2 = 2;
            Rotor3 = 1;
            rotori = new List<Rotor>();
            rotori.Add(new Rotor(1));
            pozicije.Add('A');
            rotori.Add(new Rotor(2));
            pozicije.Add('A');
            rotori.Add(new Rotor(3));
            pozicije.Add('A');
            reflektor = new Reflektor(0);
            enigma = new EnigmaMasina(rotori, reflektor, plugboard, pozicije);
        }
        public void Iscrtaj()
        {
            R1S.Content = pozicije[2];
            R1G.Content = (char)((pozicije[2]+1-'A')%26 + 'A');
            R1D.Content = (char)((pozicije[2] - 1 - 'A'+26) % 26 + 'A');
            R2S.Content = pozicije[1];
            R2G.Content = (char)((pozicije[1] + 1 - 'A') % 26 + 'A');
            R2D.Content = (char)((pozicije[1] - 1 - 'A' + 26) % 26 + 'A');
            R3S.Content = pozicije[0];
            R3G.Content = (char)((pozicije[0] + 1 - 'A') % 26 + 'A');
            R3D.Content = (char)((pozicije[0] - 1 - 'A' + 26) % 26 + 'A');

        }
        private void NapraviSvetla()
        {
            svetla[0] = As;
            svetla[1] = Bs;
            svetla[2] = Cs;
            svetla[3] = Ds;
            svetla[4] = Es;
            svetla[5] = Fs;
            svetla[6] = Gs;
            svetla[7] = Hs;
            svetla[8] = Is;
            svetla[9] = Js;
            svetla[10] = Ks;
            svetla[11] = Ls;
            svetla[12] = Ms;
            svetla[13] = Ns;
            svetla[14] = Os;
            svetla[15] = Ps;
            svetla[16] = Qs;
            svetla[17] = Rs;
            svetla[18] = Ss;
            svetla[19] = Ts;
            svetla[20] = Us;
            svetla[21] = Vs;
            svetla[22] = Ws;
            svetla[23] = Xs;
            svetla[24] = Ys;
            svetla[25] = Zs;
        }
        private Color NapraviRGB(byte r, byte g, byte b)
        {
            Color boja = new Color();
            boja.A = 255;
            boja.R = r;
            boja.G = g;
            boja.B = b;
            return boja;
        }
        private void NapraviBoje()
        {
            boje[0] = new SolidColorBrush(NapraviRGB(138, 43, 226));
            boje[1] = new SolidColorBrush(NapraviRGB(255, 0, 0));
            boje[2] = new SolidColorBrush(NapraviRGB(0, 255, 0));
            boje[3] = new SolidColorBrush(NapraviRGB(0, 0, 255));
            boje[4] = new SolidColorBrush(NapraviRGB(186, 85, 211));
            boje[5] = new SolidColorBrush(NapraviRGB(255, 215, 0));
            boje[6] = new SolidColorBrush(NapraviRGB(210, 180, 140));
            boje[7] = new SolidColorBrush(NapraviRGB(0, 255, 255));
            boje[8] = new SolidColorBrush(NapraviRGB(32, 178, 170));
            boje[9] = new SolidColorBrush(NapraviRGB(199, 21, 112));
            boje[10] = new SolidColorBrush(NapraviRGB(255, 69, 0));
            boje[11] = new SolidColorBrush(NapraviRGB(160, 82, 45));
            boje[12] = new SolidColorBrush(NapraviRGB(255, 182, 193));
        }
        public async void BojiBelo(char e)
        {
            await Task.Delay(500);
            svetla[e - 'A'].Fill = (Brush)pocetniIzgledSvetla;
        }
        private void Oboj(char e)
        {
            svetla[e - 'A'].Fill = new SolidColorBrush(svetlo);
            BojiBelo(e);
        }
        private void PomeriRotor(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int rotorID = int.Parse(button.Name[1].ToString());
            char pravac = button.Name[2];
            if (pravac == 'S')
            {
                podesavanja = new Podesavanja();
                podesavanja.cbx_pozicija1.SelectedIndex = Convert.ToInt32(char.Parse(R1S.Content.ToString())) - 65;
                podesavanja.cbx_pozicija2.SelectedIndex = Convert.ToInt32(char.Parse(R2S.Content.ToString())) - 65;
                podesavanja.cbx_pozicija3.SelectedIndex = Convert.ToInt32(char.Parse(R3S.Content.ToString())) - 65;
                podesavanja.Main = this;
                podesavanja.Owner = this;
                podesavanja.cbx_rotor1.SelectedIndex = Rotor1 - 1;
                podesavanja.cbx_rotor2.SelectedIndex = Rotor2 - 1;
                podesavanja.cbx_rotor3.SelectedIndex = Rotor3 - 1;
                podesavanja.cbx_reflektor.SelectedIndex = SacuvajReflektor;
                podesavanja.Show();
                podesavanja.Left = Left;
                podesavanja.Top = Top + 50;
                Rotor R1 = new Rotor(Rotor1);
                Rotor R2 = new Rotor(Rotor2);
                Rotor R3 = new Rotor(Rotor3);
                rotori = new List<Rotor> { R1, R2, R3 };
                enigma = new EnigmaMasina(rotori, new Reflektor(SacuvajReflektor),enigma.PB, enigma.Pozicije);

            }
            else
            {
                Button gornjeDugme = null;
                Button donjeDugme = null;
                int t;
                if (rotorID == 1)
                {
                    gornjeDugme = R1G;
                    donjeDugme = R1D;
                    enigma.Pozicije[2] = pravac == 'D' ? R1D.Content.ToString()[0] : R1G.Content.ToString()[0];
                }
                else if (rotorID == 2)
                {
                    gornjeDugme = R2G;
                    donjeDugme = R2D;
                    enigma.Pozicije[1] = pravac == 'D' ? R2D.Content.ToString()[0] : R2G.Content.ToString()[0];
                }
                else if (rotorID == 3)
                {
                    gornjeDugme = R3G;
                    donjeDugme = R3D;
                    enigma.Pozicije[0] = pravac == 'D' ? R3D.Content.ToString()[0] : R3G.Content.ToString()[0];
                }
                Iscrtaj();
            }

        }
        private void Window_LocationChanged(object sender, EventArgs e)
        {
            if (podesavanja != null)
            {
                podesavanja.Left = Left;
                podesavanja.Top = Top + 50;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (podesavanja != null)
            {
                podesavanja.Close();
            }
        }

        private void Spoji(object sender, RoutedEventArgs e)
        {
            plugboard.BtnKlikSlovo(sender);
        }
        private void KoraciSifrovanja(object sender, RoutedEventArgs e)
        {
            animacija = new EnigmaIspodHaube(this);
            this.Visibility = Visibility.Hidden;
            animacija.ShowDialog();
            this.Visibility = Visibility.Visible;
            Iscrtaj();
        }

        private void OtvaranjeObjasnjenja(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Objasnjenje O = new Objasnjenje();
            O.ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        private void Uputstvo_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("pomoc.html");
        }

        private void ResetText_Click(object sender, RoutedEventArgs e)
        {
            sr.Clear();
            Ulaz.Text = "";
            Izlaz.Text = "";
        }

        private void TastaturaKlik(object sender, RoutedEventArgs e)
        {
            Button t = (Button)sender;
            char x = enigma.Sifruj(t.Content.ToString()[0]);
            Oboj(x);
            nesifrovaniTekst.Text += t.Content.ToString()[0];
            sifrovaniTekst.Text += x;
            R3G.Content = (char)((enigma.Pozicije[0] + 1 + 26 - 'A') % 26 + 'A');
            R3S.Content = enigma.Pozicije[0];
            R3D.Content = (char)((enigma.Pozicije[0] - 1 + 26 - 'A') % 26 + 'A');

            R2G.Content = (char)((enigma.Pozicije[1] + 1 + 26 - 'A') % 26 + 'A');
            R2S.Content = enigma.Pozicije[1];
            R2D.Content = (char)((enigma.Pozicije[1] - 1 + 26 - 'A') % 26 + 'A');

            R1G.Content = (char)((enigma.Pozicije[2] + 1 + 26 - 'A') % 26 + 'A');
            R1S.Content = enigma.Pozicije[2];
            R1D.Content = (char)((enigma.Pozicije[2] - 1 + 26 - 'A') % 26 + 'A');
            sr.Append("\nUnos -> Plugboard -> Rotor I -> Rotor II -> Rotor III -> Reflektor -> Rotor III -> Rotor II -> Rotor I -> Plugboard -> Svetlo\n");
            for (int i = 0; i < enigma.TokSifrovanja.Length - 1; i += 2)
            {
                sr.Append(enigma.TokSifrovanja[i]);
                sr.Append(" -> ");
            }
            sr.Append(enigma.TokSifrovanja[enigma.TokSifrovanja.Length - 1]);
        }

        private void FizickaTastaturaKlik(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString().Length == 1)
            {
                char x = enigma.Sifruj(e.Key.ToString()[0]);
                Oboj(x);
                nesifrovaniTekst.Text += e.Key.ToString()[0];
                sifrovaniTekst.Text += x;
                R3G.Content = (char)((enigma.Pozicije[0] + 1 + 26 - 'A') % 26 + 'A');
                R3S.Content = enigma.Pozicije[0];
                R3D.Content = (char)((enigma.Pozicije[0] - 1 + 26 - 'A') % 26 + 'A');

                R2G.Content = (char)((enigma.Pozicije[1] + 1 + 26 - 'A') % 26 + 'A');
                R2S.Content = enigma.Pozicije[1];
                R2D.Content = (char)((enigma.Pozicije[1] - 1 + 26 - 'A') % 26 + 'A');

                R1G.Content = (char)((enigma.Pozicije[2] + 1 + 26 - 'A') % 26 + 'A');
                R1S.Content = enigma.Pozicije[2];
                R1D.Content = (char)((enigma.Pozicije[2] - 1 + 26 - 'A') % 26 + 'A');
                sr.Append("\nUnos -> Plugboard -> Rotor I -> Rotor II -> Rotor III -> Reflektor -> Rotor III -> Rotor II -> Rotor I -> Plugboard -> Svetlo\n");
                for (int i = 0; i < enigma.TokSifrovanja.Length - 1; i += 2)
                {
                    sr.Append(enigma.TokSifrovanja[i]);
                    sr.Append(" -> ");
                }
                sr.Append(enigma.TokSifrovanja[enigma.TokSifrovanja.Length - 1]);
            }
        }
    }
}
