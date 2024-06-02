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
            NacrtajPutanju();
            
        }

        private void NacrtajPutanju()
        {
            string s = Main.enigma.TokSifrovanja;
            List<Point> tacke = new List<Point>();
            Canvas C = PlugboardCanvas;
            NacrtajKvadraticSaSlovom(C, C.Width - C.Height / 26, C.Height - (s[0] - 'A' + 1) * C.Height / 26, ((char)((s[0] - 'A' + 26) % 26 + 'A')).ToString(), Brushes.Aqua);
            NacrtajKvadraticSaSlovom(C, 0, C.Height - (s[1]-'A' + 1) * C.Height / 26, ((char)((s[1] - 'A' + 26) % 26 + 'A')).ToString(),Brushes.Aqua);
            for (int i = 0; i < 3; i++)
            {
                C = i == 1 ? Rotor2Canvas : i == 2 ? Rotor3Canvas : Rotor1Canvas;
                NacrtajKvadraticSaSlovom(C, 0, C.Height - (s[2+2*i] - 'A' + 1) * C.Height / 26, ((char)((s[2 + 2* i] - 'A' + Main.enigma.Pozicije[i] - 'A' + 26) % 26 + 'A')).ToString(), Brushes.Aqua);
                NacrtajKvadraticSaSlovom(C, C.Width - C.Height / 26, C.Height - (s[3 + 2 * i] - 'A' + 1) * C.Height / 26, ((char)((s[3 + 2 * i] - 'A' + Main.enigma.Pozicije[i] - 'A' + 26) % 26 + 'A')).ToString(), Brushes.Aqua);
            }
        }
        protected void NacrtajKvadraticSaSlovom(Canvas c, double x, double y, string slovo,Brush b)
        {
            Rectangle rect = new Rectangle
            {
                Width = c.Height / 26,
                Height = c.Height / 26,
                Fill = b,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            Canvas.SetLeft(rect, x);
            Canvas.SetTop(rect, y);
            c.Children.Add(rect);

            TextBlock tb = new TextBlock
            {
                Text = slovo,
                Width = c.Height / 26,
                Height = c.Height / 26,
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(0, 5, 0, 0)
            };
            Canvas.SetLeft(tb, x);
            Canvas.SetTop(tb, y);
            c.Children.Add(tb);
        }
        protected void NacrtajLinijeIzmedjuKvadratica(Canvas c, char[] slova,Brush b, char TrSlovo = 'A')
        {
            // Simple example to draw lines between letters (A to Z, B to Y, ...)
            for (int i = 0; i < slova.Length; i++)
            {
                Line line = new Line
                {
                    X1 = (c.Height / 26) + 2,
                    Y1 = c.Height - ((slova[i] - TrSlovo + 26) % 26) * (c.Height / 26) - c.Height / 52,
                    X2 = c.Width - 2 - c.Height / 26,
                    Y2 = c.Height - ((26 - TrSlovo + 'A' + i) % 26) * (c.Height / 26) - c.Height / 52,
                    Stroke = b,
                    StrokeThickness = 1
                };
                c.Children.Add(line);
            }
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
