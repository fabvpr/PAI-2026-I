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

namespace AdivinarEdad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int PrimerIntervalo;
        private int SegundoIntervalo;
        private int edadPropuesta;
        private int contadorIntentos;
        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btIntento_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtPrimerIntervalo.Text, out PrimerIntervalo))
            {
                MessageBox.Show("El primer intervalo debe ser un número entero válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(txtSegundoIntervalo.Text, out SegundoIntervalo))
            {
                MessageBox.Show("El segundo intervalo debe ser un número entero válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (PrimerIntervalo >= SegundoIntervalo)
            {
                MessageBox.Show("El primer intervalo debe ser menor que el segundo intervalo.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            edadPropuesta = random.Next(PrimerIntervalo, SegundoIntervalo+1);
            contadorIntentos++;
            txtResultado.Text=edadPropuesta.ToString();
        }

        private void btCorrecto_Click(object sender, RoutedEventArgs e)
        {
            if (contadorIntentos == 0)
            {
                MessageBox.Show("Debe hacer click en el botón 'Intento'", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show($"El número de intentos fue: {contadorIntentos}");
        }

        private void btIncorrecto_Click(object sender, RoutedEventArgs e)
        {
            if (contadorIntentos == 0)
            {
                MessageBox.Show("Debe hacer click en el botón 'Intento'", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            edadPropuesta = random.Next(PrimerIntervalo, SegundoIntervalo + 1);
            contadorIntentos++;
            txtResultado.Text = edadPropuesta.ToString();
        }
    }
}