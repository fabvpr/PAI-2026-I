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
        // Colección que se conecta al ListView utilizando tu clase Cliente
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
            ComboBoxItem estadoCivilItem = (ComboBoxItem)cbEstadoCivil.SelectedItem;
            string estadoCivil = estadoCivilItem.Content.ToString();

            Cliente nuevoCliente = new Cliente();
            nuevoCliente.Nombre = nombres;
            nuevoCliente.Apellidos = apellidos;
            nuevoCliente.DNI = dni;
            nuevoCliente.Direccion = direccion;
            nuevoCliente.EstadoCivil = estadoCivil;

            clientes.Add(nuevoCliente);

            lvClientes.ItemsSource = null;
            lvClientes.ItemsSource = clientes;

            LimpiarCampos();

        }

        // Botón Nuevo
        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
        }

        // Botón Estadística
        private void btnEstadistica_Click(object sender, RoutedEventArgs e)
        {
            int solteros = 0;
            int casados = 0;

            for (int i= 0; i<clientes.Count; i++)
            {
                if (clientes[i]EstadoCivil == "Soltero(a)") solteros++;
                if (clientes[i]EstadoCivil =="Casado(a)") casados++;
            }

            txtContadorSolteros.Text = solteros.ToString();
            txtContadorCasados.Text = casados.ToString();
        }

        // Botón Salir
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LimpiarCampos()
        {
            txtApellido.Clear();
            txtNombre.Clear();
            txtDNI.Clear();
            txtDireccion.Clear();
            cbEstadoCivil.SelectedIndex = -1;
            txtApellido.Focus();
        }
    }
}