using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System.Xml.Linq;

namespace Enigma
{
    internal abstract class ElementEnigme
    {
        protected abstract void NacrtajElement(Canvas C);

        protected void NacrtajKvadratice(Canvas C, char TrSlovo = 'A')
        {
            for (int i = 0; i < 26; i++)
            {
                NacrtajKvadraticSaSlovom(C, 0, C.Height - (i + 1) * C.Height / 26, ((char)((i + TrSlovo - 'A' + 26) % 26 + 'A')).ToString());//leva strana
                NacrtajKvadraticSaSlovom(C, C.Width - C.Height / 26, C.Height - (i + 1) * C.Height / 26, ((char)((i + TrSlovo - 'A' + 26) % 26 + 'A')).ToString());//desna strana
            }
        }
        protected void NacrtajKvadraticSaSlovom(Canvas c, double x, double y, string slovo)
        {
            Rectangle rect = new Rectangle
            {
                Width = c.Height / 26,
                Height = c.Height / 26,
                Fill = Brushes.White,
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
        protected void NacrtajLinijeIzmedjuKvadratica(Canvas c, char[] slova, char TrSlovo='A')
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
                    Stroke = Brushes.Black,
                    StrokeThickness = 1
                };
                c.Children.Add(line);
            }
        }
    }
}
