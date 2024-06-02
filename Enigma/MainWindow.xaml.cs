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
        Podesavanja podesavanja;
        EnigmaIspodHaube animacija;
        Color svetlo = new Color();
        int brojacBoja = 0;
        char trenutnoSlovoPlug = ' ';
        Plugboard plugboard = new Plugboard();
        SolidColorBrush[] boje = new SolidColorBrush[13];
        Ellipse[] svetla = new Ellipse[26];
        object pocetniIzgledSvetla;
        private void Load(object sender, RoutedEventArgs e)
        {
            svetlo = NapraviRGB(255, 189, 89);
            NapraviBoje();
            NapraviSvetla();
            pocetniIzgledSvetla = (RadialGradientBrush)As.Fill;
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
                podesavanja.cbx_zarez1.SelectedIndex = 0;
                podesavanja.cbx_zarez2.SelectedIndex = 0;
                podesavanja.cbx_zarez3.SelectedIndex = 0;
                podesavanja.cbx_pozicija1.SelectedIndex = Convert.ToInt32(char.Parse(R1S.Content.ToString())) - 65;
                podesavanja.cbx_pozicija2.SelectedIndex = Convert.ToInt32(char.Parse(R2S.Content.ToString())) - 65;
                podesavanja.cbx_pozicija3.SelectedIndex = Convert.ToInt32(char.Parse(R3S.Content.ToString())) - 65;
                podesavanja.Main = this;
                podesavanja.Show();
                podesavanja.Left = Left;
                podesavanja.Top = Top + 50;
            }
            else
            {
                Button gornjeDugme = null;
                Button donjeDugme = null;
                Button srednjeDugme = null;
                if (rotorID == 1)
                {
                    gornjeDugme = R1G;
                    donjeDugme = R1D;
                    srednjeDugme = R1S;
                }
                else if (rotorID == 2)
                {
                    gornjeDugme = R2G;
                    donjeDugme = R2D;
                    srednjeDugme = R2S;
                }
                else if (rotorID == 3)
                {
                    gornjeDugme = R3G;
                    donjeDugme = R3D;
                    srednjeDugme = R3S;
                }
                if (pravac == 'D')
                {
                    string originalDole = donjeDugme.Content.ToString();
                    donjeDugme.Content = srednjeDugme.Content;
                    srednjeDugme.Content = gornjeDugme.Content;
                    if (originalDole != "X")
                    {
                        gornjeDugme.Content = (char)(Convert.ToChar(gornjeDugme.Content) + 1);
                    }
                    else
                    {
                        gornjeDugme.Content = "A";
                    }
                }
                else if (pravac == 'G')
                {
                    string originalGore = gornjeDugme.Content.ToString();
                    gornjeDugme.Content = srednjeDugme.Content;
                    srednjeDugme.Content = donjeDugme.Content;
                    if (originalGore != "C")
                    {
                        donjeDugme.Content = (char)(Convert.ToChar(donjeDugme.Content) - 1);
                    }
                    else
                    {
                        donjeDugme.Content = "Z";
                    }
                }
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
            char[] pom = sender.ToString().ToCharArray();
            Button s = (Button)sender;
            trenutnoSlovoPlug = pom[pom.Length - 1];
            s.Background = boje[brojacBoja / 2];
            brojacBoja++;
            plugboard.KlikSlovo(trenutnoSlovoPlug);
            Oboj(trenutnoSlovoPlug);
        }
        private void KoraciSifrovanja(object sender, RoutedEventArgs e)
        {
            animacija = new EnigmaIspodHaube();
            animacija.Show();
        }
    }
}
