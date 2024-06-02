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
            Main.R1S.Content = cbx_pozicija1.Text;
            Main.R2S.Content = cbx_pozicija2.Text;
            Main.R3S.Content = cbx_pozicija3.Text;
            Close();
        }
    }
}
