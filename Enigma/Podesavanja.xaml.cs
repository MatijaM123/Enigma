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
using System.Windows.Shapes;

namespace Enigma
{
    /// <summary>
    /// Interaction logic for Podesavanja.xaml
    /// </summary>
    public partial class Podesavanja : Window
    {
        public MainWindow Main;
        public Podesavanja()
        {
            InitializeComponent();
        }

        private void Ponisti_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            Main.enigma.Pozicije[0] = cbx_pozicija3.Text[0];
            Main.enigma.Pozicije[1] = cbx_pozicija2.Text[0];
            Main.enigma.Pozicije[2] = cbx_pozicija1.Text[0];
            Main.Iscrtaj();
            Main.R1G.Content = SledeceSlovo(cbx_pozicija1.Text);
            Main.R2G.Content = SledeceSlovo(cbx_pozicija2.Text);
            Main.R3G.Content = SledeceSlovo(cbx_pozicija3.Text);
            Main.R1D.Content = ProsloSlovo(cbx_pozicija1.Text);
            Main.R2D.Content = ProsloSlovo(cbx_pozicija2.Text);
            Main.R3D.Content = ProsloSlovo(cbx_pozicija3.Text);
            Main.Rotor1 = cbx_rotor1.SelectedIndex + 1;
            Main.Rotor2 = cbx_rotor2.SelectedIndex + 1;
            Main.Rotor3 = cbx_rotor3.SelectedIndex + 1;
            Main.SacuvajReflektor = cbx_reflektor.SelectedIndex;
            Close();
        }

        private string SledeceSlovo(string slovo)
        {
            char ch = (char)(slovo[0]+1);
            if (ch == 'Z'+1)
            {
                return "A";
            }
            return ch.ToString();


        }
        private string ProsloSlovo(string slovo)
        {
            char ch = (char)(slovo[0] - 1);
            if (ch == 'A' - 1)
            {
                return "Z";
            }
            return ch.ToString();
        }
    }
}
