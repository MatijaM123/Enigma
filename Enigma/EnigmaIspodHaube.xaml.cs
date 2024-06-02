using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
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
        List<Canvas> rotorskiCanvasi = new List<Canvas>();
        public EnigmaIspodHaube(MainWindow Main)
        {
            this.Main = Main;
            InitializeComponent();
            Loaded += Load;
        }
        private void Load(object sender, RoutedEventArgs e)
        {
            rotorskiCanvasi.Add(Rotor1Canvas);
            rotorskiCanvasi.Add(Rotor2Canvas);
            rotorskiCanvasi.Add(Rotor3Canvas);
            Iscrtaj();
        }
        private MainWindow Main { get; set; }
        private void SacuvajFajl(object sender, RoutedEventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.FileName = "Koraci sifrovanja.txt";
            s.ShowDialog();
            StreamWriter sw = new StreamWriter(s.FileName);
            sw.WriteLine("Unos -> Plugboard -> Rotor I -> Rotor II -> Rotor III -> Reflektor -> Rotor III -> Rotor II -> Rotor I -> Plugboard -> Svetlo");
            sw.Close();
        }
        private void TastaturaKlik(object sender, RoutedEventArgs e)
        {

            Button t = (Button)sender;         
            Main.enigma.Sifruj(t.Content.ToString()[0]);
            Iscrtaj();
            //t.Background = Brushes.AliceBlue;

        }
        private void PomeriRotor(object sender, RoutedEventArgs e)
        {
            Button t = (Button)sender;
            if (t.Name.ToString()[2] == 'U')
                Main.enigma.Pozicije[int.Parse(t.Name[1].ToString()) - 1] = (char)((Main.enigma.Pozicije[int.Parse(t.Name[1].ToString())-1] - 1 + 26 - 'A') % 26 + 'A');
            else
                Main.enigma.Pozicije[int.Parse(t.Name[1].ToString()) -1] = (char)((Main.enigma.Pozicije[int.Parse(t.Name[1].ToString())-1] + 1 - 'A') % 26 + 'A');
            Iscrtaj();
        }
        private void ObrisiPlatna()
        {
            for (int i = 0; i < rotorskiCanvasi.Count; i++)
                rotorskiCanvasi[i].Children.Clear();
            ReflectorCanvas.Children.Clear();
            PlugboardCanvas.Children.Clear();
        }
        private void Iscrtaj()
        {
            ObrisiPlatna();
            Main.enigma.NacrtajEnigmu(rotorskiCanvasi, ReflectorCanvas, PlugboardCanvas);
            Rotor1TrSlovo.Text = Main.enigma.Pozicije[0].ToString();
            Rotor2TrSlovo.Text = Main.enigma.Pozicije[1].ToString();
            Rotor3TrSlovo.Text = Main.enigma.Pozicije[2].ToString();
        }
    }
}
