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
        private void Load(object sender, RoutedEventArgs e)
        {
            svetlo.A = 255;
            svetlo.R = 255;
            svetlo.G = 189;
            svetlo.B = 89;
            Oboj(Qs);
        }
        private void Oboj(Ellipse e )
        {
            e.Fill = new SolidColorBrush(svetlo);
        }

        private void Spoji(object sender, RoutedEventArgs e)
        {
            string[] pom = sender.ToString().Split();
            trenutnoSlovoPlug = pom[1];
        }
    }
}
