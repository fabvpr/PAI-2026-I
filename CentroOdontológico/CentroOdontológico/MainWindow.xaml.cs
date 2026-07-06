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

namespace CentroOdontológico
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Calendario.SelectedDate = DateTime.Now;
        }

        private void btCronogramar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPaciente.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del cliente.", "Cliente inválido", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string paciente = txtPaciente.Text;

            if (cbTratamiento.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un tratamiento.");
                return;
            }

            if (cbPieza.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una pieza.");
                return;
            }

            if (!Calendario.SelectedDate.HasValue)
            {
                MessageBox.Show("Seleccione una fecha.");
                return;
            }

            ComboBoxItem tratamiento = (ComboBoxItem)cbTratamiento.SelectedItem;
            ComboBoxItem pieza = (ComboBoxItem)cbPieza.SelectedItem;

            DateTime fecha = Calendario.SelectedDate.Value;

            txtResultado.Text =
                $"Paciente: {paciente}\n" +
                $"Tratamiento: {tratamiento.Content}\n" +
                $"Pieza: {pieza.Content}\n" +
                $"Fecha: {fecha:dd/MM/yyyy}\n"+ 
                $"Proxima fecha:";
        }
    }
}