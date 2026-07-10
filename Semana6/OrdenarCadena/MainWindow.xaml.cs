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

namespace OrdenarCadena
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string [] ListaNombres;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btListar_Click(object sender, RoutedEventArgs e)
        {
            string nombres = txtNombres.Text;
            if (string.IsNullOrEmpty(nombres))
            {
                MessageBox.Show("Por favor, ingrese nombres separados por espaios.", "Validación", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            ListaNombres = nombres.Split(' ');

            //por cada nombre en la caja de texto se va a ir agregnadno uno por uso sin considerar espacios con split y se guarda en lso arreglos
            foreach(string nombre in ListaNombres)
            {
                lbNombres.Items.Add(nombre);
            }

            txtTotalNombre.Text = lbNombres.Items.Count.ToString();
        }

        private void btPasar_Click(object sender, RoutedEventArgs e)
        {
            string letra = txtLetraNombreFiltrado.Text;

            if (string.IsNullOrWhiteSpace(letra))
            { 
                MessageBox.Show("Ingresar la letra a filtrar", 
                    "Validación", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            foreach(string nombre in ListaNombres)
            {
                if (nombre.StartsWith(letra,StringComparison.OrdinalIgnoreCase))
                {
                    lbNombresFiltrados.Items.Add(nombre);
                }
            }
            txtTotalNombreFiltrados.Text = lbNombresFiltrados.Items.Count.ToString();
        }
    }
}