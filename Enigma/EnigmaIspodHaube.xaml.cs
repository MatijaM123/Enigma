using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for EnigmaIspodHaube.xaml
    /// </summary>
    public partial class EnigmaIspodHaube : Window
    {
        public EnigmaIspodHaube()
        {
            InitializeComponent();
        }

        private void SacuvajFajl(object sender, RoutedEventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.FileName = "Koraci sifrovanja.txt";
            s.ShowDialog();
            StreamWriter sw = new StreamWriter(s.FileName);
            sw.WriteLine("Unos -> Plugboard -> Rotor I -> Rotor II -> Rotor III -> Reflektor -> Rotor III -> Rotor II -> Rotor I -> Plugboard -> Svetlo");
            sw.Close();
        }
    }
}
