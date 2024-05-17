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
using System.Windows.Shapes;

namespace Enigma
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int R3Sredina = 'A', R2Sredina = 'A', R1Sredina = 'A';
        public MainWindow()
        {
            Loaded += Load;
            InitializeComponent();
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            gbx_podesavanja.Visibility = Visibility.Hidden;
            gbx_podesavanja.IsEnabled = false;
        }
        private void R3G_Click(object sender, RoutedEventArgs e)
        {
            R3Sredina++;
            R3_Update();
        }

        private void R3_Update()
        {
            R3S.Content = Convert.ToChar(R3Sredina);
            R3G.Content = Convert.ToChar(R3Sredina - 1);
            R3D.Content = Convert.ToChar(R3Sredina + 1);
        }

        private void R2G_Click(object sender, RoutedEventArgs e)
        {
            R2Sredina++;
            R2_Update();
        }

        private void R2_Update()
        {
            R2S.Content = Convert.ToChar(R2Sredina);
            R2G.Content = Convert.ToChar(R2Sredina - 1);
            R2D.Content = Convert.ToChar(R2Sredina + 1);
        }

        private void R1G_Click(object sender, RoutedEventArgs e)
        {
            R1Sredina++;
            R1_Update();
        }
        private void R1_Update()
        {
            R1S.Content = Convert.ToChar(R1Sredina);
            R1G.Content = Convert.ToChar(R1Sredina - 1);
            R1D.Content = Convert.ToChar(R1Sredina + 1);
        }

        private void R3D_Click(object sender, RoutedEventArgs e)
        {
            R3Sredina--;
            R3_Update();
        }

        private void R2D_Click(object sender, RoutedEventArgs e)
        {
            R2Sredina--;
            R2_Update();
        }

        private void R1D_Click(object sender, RoutedEventArgs e)
        {
            R1Sredina--;
            R1_Update();
        }

        private void RS_Click(object sender, RoutedEventArgs e)
        {
            gbx_podesavanja.Visibility = Visibility.Visible;
            gbx_podesavanja.IsEnabled = true;

        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
