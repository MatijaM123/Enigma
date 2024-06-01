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
        Color svetlo = new Color();
        int brojacBoja = 0;
        string trenutnoSlovoPlug = "";
        char R3Srednje, R2Srednje, R1Srednje;
        private void Load(object sender, RoutedEventArgs e)
        {
            svetlo.A = 255;
            svetlo.R = 255;
            svetlo.G = 189;
            svetlo.B = 89;
            R3Srednje = 'A';
            R2Srednje = 'A';
            R1Srednje = 'A';
            Oboj(Qs);
        }
        private void Oboj(Ellipse e )
        {
            e.Fill = new SolidColorBrush(svetlo);
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

        private void Spoji(object sender, RoutedEventArgs e)
        {
            string[] pom = sender.ToString().Split();
            trenutnoSlovoPlug = pom[1];
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
