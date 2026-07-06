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
namespace Registro_de_clientes
{
    public partial class MainWindow : Window
    {
        List<Cliente> clientes = new List<Cliente>();
        public MainWindow()
        {
            InitializeComponent();

            lvClientes.ItemsSource = clientes;

        }

        private void btnGrabar_Click(object sender, RoutedEventArgs e)
        {
            string nombres = txtNombre.Text;
            string apellidos = txtApellido.Text;
            string dni = txtDNI.Text;
            string direccion = txtDireccion.Text;

            ComboBoxItem seleccionado = (ComboBoxItem)cbEstadoCivil.SelectedItem;
            string estadoCivil = seleccionado.Content.ToString();

            Cliente nuevo = new Cliente();
            nuevo.Apellidos = apellidos;
            nuevo.DNI = dni;
            nuevo.Nombre = nombres;
            nuevo.Direccion = direccion;
            nuevo.EstadoCivil = estadoCivil;

            clientes.Add(nuevo);

            LimpiarFormulario();
            //Limpiar el origen de datos para refrescar la vista, ya sea elimnar, añadir o modificar un registro
            lvClientes.ItemsSource = null;
            lvClientes.ItemsSource = clientes;

        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDNI.Clear();
            txtDireccion.Clear();
            cbEstadoCivil.SelectedIndex = -1;
        }

        private void btnEstadistica_Click(object sender, RoutedEventArgs e)
        {
            int solteros = 0;
            int casados = 0;

            for (int i = 0; i < clientes.Count; i++)
            {
                if (clientes[i].EstadoCivil == "Soltero(a)")
                {
                    solteros++;
                }
                if (clientes[i].EstadoCivil == "Casado(a)")
                {
                    casados++;
                }
            }

            solteros = clientes.Count(c => c.EstadoCivil == "Soltero(a)");
            casados = clientes.Count(c => c.EstadoCivil == "Casado(a)");

            txtContadorCasados.Text = casados.ToString();
            txtContadorSolteros.Text = solteros.ToString();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

}