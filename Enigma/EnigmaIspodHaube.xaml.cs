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
        List<Button> svetla;
        Button prethodni = null;
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
            Button[] t = { lA, lB, lC, lD, lE, lF, lG, lH, lI, lJ, lK, lL, lM, lN, lO, lP, lQ, lR, lS, lT, lU, lV, lW, lX, lY, lZ };
            svetla = new List<Button>(t);
            Iscrtaj();
        }
        private MainWindow Main { get; set; }
        private void SacuvajFajl(object sender, RoutedEventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.FileName = "Koraci sifrovanja.txt";
            if (s.ShowDialog() == true)
            {
                File.WriteAllText(s.FileName, Main.sr.ToString());
            }
        }
        private void TastaturaKlik(object sender, RoutedEventArgs e)
        {

            Button t = (Button)sender;         
            char x = Main.enigma.Sifruj(t.Content.ToString()[0]);
            Iscrtaj();
            t.Background = Brushes.Aqua;
            svetla[x - 'A'].Background = Brushes.Gold;
            NacrtajPutanju();
            prethodni = t;
        }

        private void NacrtajPutanju()
        {
            string s = Main.enigma.TokSifrovanja;
            List<Point> tacke = new List<Point>();
            Canvas C = PlugboardCanvas;
            NacrtajKvadraticSaSlovom(C, C.Width - C.Height / 26, C.Height - (s[0] - 'A' + 1) * C.Height / 26, ((char)((s[0] - 'A' + 26) % 26 + 'A')).ToString(), Brushes.Aqua);
            NacrtajKvadraticSaSlovom(C, 0, C.Height - (s[1]-'A' + 1) * C.Height / 26, ((char)((s[1] - 'A' + 26) % 26 + 'A')).ToString(),Brushes.Aqua);
            Line line = new Line
            {
                X1 = (C.Height / 26) + 2,
                Y1 = C.Height - (s[1] - 'A' +1) * C.Height / 26 + C.Height / 52,
                X2 = C.Width - 2 - C.Height / 26,
                Y2 = C.Height - (s[0] - 'A' +1) * C.Height / 26 + C.Height / 52,
                Stroke = Brushes.Aqua,
                StrokeThickness = 3
            };
            C.Children.Add(line);
            for (int i = 0; i < 3; i++)
            {
                C = i == 1 ? Rotor2Canvas : i == 2 ? Rotor3Canvas : Rotor1Canvas;
                NacrtajKvadraticSaSlovom(C, 0, (s[3 + 2 * i] - Main.enigma.Pozicije[i] + 27) % 26 == 0?0: C.Height - ((s[3+2*i] - Main.enigma.Pozicije[i] + 27) %26) * C.Height / 26, s[3 + 2* i].ToString(), Brushes.Aqua);
                NacrtajKvadraticSaSlovom(C, C.Width - C.Height / 26, (s[2 + 2 * i] - Main.enigma.Pozicije[i] + 27) % 26==0?0: C.Height - ((s[2 + 2 * i] - Main.enigma.Pozicije[i] +27)%26) * C.Height / 26,s[2 + 2 * i].ToString(), Brushes.Aqua);
                line = new Line
                {
                    X1 = (C.Height / 26) + 2,
                    Y1 = ((s[3 + 2 * i] - Main.enigma.Pozicije[i] + 27) % 26 == 0 ? 0 : C.Height - ((s[3 + 2 * i] - Main.enigma.Pozicije[i] + 27) % 26) * C.Height / 26) + C.Height / 52,
                    X2 = C.Width - 2 - C.Height / 26,
                    Y2 = ((s[2 + 2 * i] - Main.enigma.Pozicije[i] + 27) % 26 == 0 ? 0 : C.Height - ((s[2 + 2 * i] - Main.enigma.Pozicije[i] + 27) % 26) * C.Height / 26) + C.Height / 52 ,
                    Stroke = Brushes.Aqua,
                    StrokeThickness = 3
                };
                C.Children.Add(line);
            }
            C = ReflectorCanvas;
            NacrtajKvadraticSaSlovom(C, C.Width - C.Height / 26, C.Height - (s[8] - 'A' + 1) * C.Height / 26, s[8].ToString(), Brushes.Aqua);
            NacrtajKvadraticSaSlovom(C, 0, C.Height - (s[8] - 'A' + 1) * C.Height / 26, s[8].ToString(), Brushes.Aqua);
            line = new Line
            {
                X1 = (C.Height / 26) + 2,
                Y1 = C.Height - (s[8] - 'A' + 1) * C.Height / 26 + C.Height / 52,
                X2 = C.Width - 2 - C.Height / 26,
                Y2 = C.Height - (s[8] - 'A' + 1) * C.Height / 26 + C.Height / 52,
                Stroke = Brushes.Aqua,
                StrokeThickness = 3
            };
            C.Children.Add(line);
            line = new Line
            {
                X1 = (C.Height / 26) + 4,
                Y1 = C.Height - (s[8] - 'A' + 1) * C.Height / 26 + C.Height / 52,
                X2 = (C.Height / 26) + 4,
                Y2 = C.Height - (s[9] - 'A' + 1) * C.Height / 26 + C.Height / 52,
                Stroke = Brushes.Navy,
                StrokeThickness = 3
            };
            C.Children.Add(line);
            NacrtajKvadraticSaSlovom(C, C.Width - C.Height / 26, C.Height - (s[9] - 'A' + 1) * C.Height / 26, s[9].ToString(), Brushes.Gold);
            NacrtajKvadraticSaSlovom(C, 0, C.Height - (s[9] - 'A' + 1) * C.Height / 26, s[9].ToString(), Brushes.Gold);
            line = new Line
            {
                X1 = (C.Height / 26) + 2,
                Y1 = C.Height - (s[9] - 'A' + 1) * C.Height / 26 + C.Height / 52,
                X2 = C.Width - 2 - C.Height / 26,
                Y2 = C.Height - (s[9] - 'A' + 1) * C.Height / 26 + C.Height / 52,
                Stroke = Brushes.Gold,
                StrokeThickness = 3
            };
            C.Children.Add(line);
            for (int i = 0; i < 3; i++)
            {
                C = i == 1 ? Rotor2Canvas : i == 2 ? Rotor1Canvas : Rotor3Canvas;
                if ((s[10 + 2 * i] - Main.enigma.Pozicije[2 - i] + 27) % 26 == 0)
                    NacrtajKvadraticSaSlovom(C, 0, 0, s[10 + 2 * i].ToString(), Brushes.Gold);
                else
                    NacrtajKvadraticSaSlovom(C, 0, C.Height - ((s[10 + 2 * i] - Main.enigma.Pozicije[2-i] +27) % 26) * C.Height / 26, s[10 + 2 * i].ToString(), Brushes.Gold);
                if ((s[11 + 2 * i] - Main.enigma.Pozicije[2 - i] + 27) % 26 == 0)
                    NacrtajKvadraticSaSlovom(C, C.Width - C.Height / 26, 0, s[11 + 2 * i].ToString(), Brushes.Gold);
                else
                    NacrtajKvadraticSaSlovom(C, C.Width - C.Height / 26, C.Height - ((s[11 + 2 * i] - Main.enigma.Pozicije[2 - i] + 27) % 26) * C.Height / 26, s[11 + 2 * i].ToString(), Brushes.Gold);
                line = new Line
                {

                    X1 = (C.Height / 26) + 2,
                    Y1 = ((s[10 + 2 * i] - Main.enigma.Pozicije[2 - i] + 27) % 26 == 0?0:C.Height - ((s[10 + 2 * i] - Main.enigma.Pozicije[2 - i] + 27) % 26) * C.Height / 26) + C.Height / 52,
                    X2 = C.Width - 2 - C.Height / 26,
                    Y2 = ((s[11 + 2 * i] - Main.enigma.Pozicije[2 - i] + 27) % 26==0?0:C.Height - ((s[11 + 2 * i] - Main.enigma.Pozicije[2 - i] + 27) % 26) * C.Height / 26) + C.Height/52,
                    Stroke = Brushes.Gold,
                    StrokeThickness = 3
                };
                C.Children.Add(line);
            }
            C = PlugboardCanvas;
            NacrtajKvadraticSaSlovom(C, C.Width - C.Height / 26, C.Height - (s[17] - 'A' + 1) * C.Height / 26, ((char)((s[17] - 'A' + 26) % 26 + 'A')).ToString(), Brushes.Gold);
            NacrtajKvadraticSaSlovom(C, 0, C.Height - (s[16] - 'A' + 1) * C.Height / 26, ((char)((s[16] - 'A' + 26) % 26 + 'A')).ToString(), Brushes.Gold);
            line = new Line
            {
                X1 = (C.Height / 26) + 2,
                Y1 = C.Height - (s[16] - 'A' + 1) * C.Height / 26 + C.Height / 52,
                X2 = C.Width - 2 - C.Height / 26,
                Y2 = C.Height - (s[17] - 'A' + 1) * C.Height / 26 + C.Height / 52,
                Stroke = Brushes.Gold,
                StrokeThickness = 3
            };
            C.Children.Add(line);
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
            if (prethodni != null)
                prethodni.Background = Brushes.LightGray;
            for (int i = 0; i < svetla.Count; i++)
                svetla[i].Background = Brushes.LightGray;
        }
    }
}
