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
            Naziv.Text = "Rotori";
            Opis.Text = "U rotorima se mešaju slova. \nEnigma ima 3 rotora, svaki ima \nbrojeve od 1 do 26 za svako \nslovo adecede i svaki ima 26 \nmetalnih šiljaka sa kojima se \npovezuju. Unutar rotora su \nizmešane žice koje povezuju 2 \nkraja, tako da ne izadje isto \nslovo koje je ušlo u rotor. Slovo \nse promeni 3 puta prolazeći \nkroz 3 rotora.";
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
            Opis.Text = "Pomoću plugboard-a možemo \ndodatno da zamenimo neka 2 \nslova povezujući ih kablovima u \nplugboard-u.";
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
            Opis.Text = "Tastatura se koristi za unos \nslova, svaki put kada se unese \nslovo rotor se okrene. I kada \nprvi rotor napravi ceo krug \ntada se sledeći pomeri za jedno \nmesto.";
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
            Opis.Text = "Na lampboard-u se prikazuje \nslovo koje dobijemo nakon \nšifrovanja, tako što zasvetli \nlampica koja predstavlja to \nslovo.";
        }

        private void Lampboard_MouseLeave(object sender, MouseEventArgs e)
        {
            Lampboard.Opacity = 0;
            Naziv.Text = "";
            Opis.Text = "";
        }
        private void Reflektor_MouseEnter(object sender, MouseEventArgs e)
        {
            Reflektor.Opacity = 1;
            Naziv.Text = "Reflektor";
            Opis.Text = "Nakon što slovo, koje menjamo, \nprođe kroz rotore ono dolazi do \nreflektora, koji ga menja još \njedanput i šalje nazad da \nponovo prođe kroz sva 3 \nrotora.";
        }

        private void Reflektor_MouseLeave(object sender, MouseEventArgs e)
        {
            Reflektor.Opacity = 0;
            Naziv.Text = "";
            Opis.Text = "";
        }
    }
}
