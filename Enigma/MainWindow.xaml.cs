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
        Podesavanja podesavanja;
        Color svetlo = new Color();
        int brojacBoja = 0;
        char trenutnoSlovoPlug = ' ';
        Plugboard plugboard = new Plugboard();
        SolidColorBrush[] boje = new SolidColorBrush[13];
        Ellipse[] svetla = new Ellipse[26];
        private void Load(object sender, RoutedEventArgs e)
        {
            svetlo = NapraviRGB(255, 189, 89);
            NapraviBoje();
            NapraviSvetla();
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
            await Task.Delay(2000);
            svetla[e - 'A'].Fill = new SolidColorBrush(NapraviRGB(255, 255, 255));
        }
        private void Oboj(char e)
        {
            svetla[e - 'A'].Fill = new SolidColorBrush(svetlo);
            BojiBelo(e);
        }

        private void R3D_Click(object sender, RoutedEventArgs e) //TreciRotor, Dole
        {
            string originalDole = R3D.Content.ToString();
            R3D.Content = R3S.Content;
            R3S.Content = R3G.Content;
            if (originalDole != "X")
            {
                R3G.Content = (char)(Convert.ToChar(R3G.Content) + 1);
            }
            else
            {
                R3G.Content = "A";
            }
        }

        private void R2G_Click(object sender, RoutedEventArgs e)
        {
            string originalGore = R2G.Content.ToString();
            R2G.Content = R2S.Content;
            R2S.Content = R2D.Content;
            if (originalGore != "C")
            {
                R2D.Content = (char)(Convert.ToChar(R2D.Content) - 1);
            }
            else
            {
                R2D.Content = "Z";
            }
        }

        private void R2D_Click(object sender, RoutedEventArgs e)
        {
            string originalDole = R2D.Content.ToString();
            R2D.Content = R2S.Content;
            R2S.Content = R2G.Content;
            if (originalDole != "X")
            {
                R2G.Content = (char)(Convert.ToChar(R2G.Content) + 1);
            }
            else
            {
                R2G.Content = "A";
            }
        }

        private void R1G_Click(object sender, RoutedEventArgs e)
        {
            string originalGore = R1G.Content.ToString();
            R1G.Content = R1S.Content;
            R1S.Content = R1D.Content;
            if (originalGore != "C")
            {
                R1D.Content = (char)(Convert.ToChar(R1D.Content) - 1);
            }
            else
            {
                R1D.Content = "Z";
            }
        }

        private void R1D_Click(object sender, RoutedEventArgs e)
        {
            string originalDole = R1D.Content.ToString();
            R1D.Content = R1S.Content;
            R1S.Content = R1G.Content;
            if (originalDole != "X")
            {
                R1G.Content = (char)(Convert.ToChar(R1G.Content) + 1);
            }
            else
            {
                R1G.Content = "A";
            }
        }

        private void RS_Click(object sender, RoutedEventArgs e) //Bilo koje srednje dugme rotora
        {
            podesavanja = new Podesavanja();
            podesavanja.Show();
            podesavanja.Left = Left;
            podesavanja.Top = Top + 50;
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
            char[] pom = sender.ToString().ToCharArray();
            Button s = (Button)sender;
            trenutnoSlovoPlug = pom[pom.Length - 1];
            if (s.Background.ToString().Equals(NapraviRGB(255, 255, 255).ToString()))
            {
                s.Background = boje[brojacBoja / 2];
                brojacBoja++;
            }
            else
            {
                s.Background = new SolidColorBrush(NapraviRGB(255, 255, 255));
                brojacBoja--;
            }
            plugboard.KlikSlovo(trenutnoSlovoPlug);
            Oboj(trenutnoSlovoPlug);
        }

        private void R3G_Click(object sender, RoutedEventArgs e) //TreciRotor, Gore
        {
            string originalGore = R3G.Content.ToString();
            R3G.Content = R3S.Content;
            R3S.Content = R3D.Content;
            if (originalGore != "C")
            {
                R3D.Content = (char)(Convert.ToChar(R3D.Content) - 1);
            }
            else
            {
                R3D.Content = "Z";
            }
        }
    }
}
