using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EncriptarClave
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btEncriptar_Click(object sender, RoutedEventArgs e)
        {
            string clave =txtClave.Text;

            if (string.IsNullOrWhiteSpace(clave))
            { 
                MessageBox.Show("Por favor, ingrese una clave para encriptar.");
                return;
            }

            string claveEncriptada = "";
            int dezplazamiento = 3;

            foreach (char caracter in clave)
            {
                if (char.IsLetter(caracter))
                {
                    char nuevoCaracter = (char)(caracter + dezplazamiento);

                    claveEncriptada =claveEncriptada + nuevoCaracter.ToString();
                }
                txtClaveEncriptada.Text = claveEncriptada;
            }
        }

        private void btDesencriptar_Click(object sender, RoutedEventArgs e)
        {
            string clave = txtClave.Text;

            if (string.IsNullOrWhiteSpace(clave))
            {
                MessageBox.Show("Por favor, ingrese una clave para encriptar.");
                return;
            }

            string claveEncriptada = "";
            int dezplazamiento = 3;

            foreach (char caracter in clave)
            {
                if (char.IsLetter(caracter))
                {
                    char nuevoCaracter = (char)(caracter - dezplazamiento);

                    claveEncriptada = claveEncriptada + nuevoCaracter.ToString();
                }
                txtClaveEncriptada.Text = claveEncriptada;
            }
        }
    }
}