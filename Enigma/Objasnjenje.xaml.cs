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
    /// Interaction logic for Objasnjenje.xaml
    /// </summary>
    public partial class Objasnjenje : Window
    {
        public Objasnjenje()
        {
            InitializeComponent();
        }
        private void Rotor_MouseEnter(object sender, MouseEventArgs e)
        {
            Rotor.Opacity = 1;
            Naziv.Text = "Rotor";
            Opis.Text = "Idu vrm vrm u krug";
        }

        private void Rotor_MouseLeave(object sender, MouseEventArgs e)
        {
            Rotor.Opacity = 0;
            Naziv.Text = "";
            Opis.Text = "";
        }

        private void Plugboard_MouseEnter(object sender, MouseEventArgs e)
        {
            Plugboard.Opacity = 1;
            Naziv.Text = "Plugboard";
            Opis.Text = "povezujes stvari";
        }

        private void Plugboard_MouseLeave(object sender, MouseEventArgs e)
        {
            Plugboard.Opacity = 0;
            Naziv.Text = "";
            Opis.Text = "";
        }

        private void Keyboard_MouseEnter(object sender, MouseEventArgs e)
        {
            Keyboard.Opacity = 1;
            Naziv.Text = "Keyboard";
            Opis.Text = "kucas ovde";
        }

        private void Keyboard_MouseLeave(object sender, MouseEventArgs e)
        {
            Keyboard.Opacity = 0;
            Naziv.Text = "";
            Opis.Text = "";
        }

        private void Lampboard_MouseEnter(object sender, MouseEventArgs e)
        {
            Lampboard.Opacity = 1;
            Naziv.Text = "Lampboard";
            Opis.Text = "svetle";
        }

        private void Lampboard_MouseLeave(object sender, MouseEventArgs e)
        {
            Lampboard.Opacity = 0;
            Naziv.Text = "";
            Opis.Text = "";
        }
    }
}
