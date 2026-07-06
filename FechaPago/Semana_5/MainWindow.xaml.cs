using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Semana_5
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

        private void btCalcular_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCliente.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del cliente.", "Cliente inválido", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string cliente = txtCliente.Text;

            if (!double.TryParse(txtMonto.Text, out double monto))
            {
                MessageBox.Show("Por favor, ingrese un monto adecuado.", "Monto incorrecto", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            monto = Double.Parse(txtMonto.Text);

            DateTime fechaVen = dpFchVenc.SelectedDate.Value;
            DateTime fechaPag = dpFchPago.SelectedDate.Value;

            int diasMora = 0;
            if (fechaPag > fechaVen)
            {
                TimeSpan diferencia = fechaPag.Subtract(fechaVen);
                diasMora = (int)diferencia.TotalDays;
            }

            double moraPorc = diasMora * 0.5;

            double moraSoles = monto * moraPorc / 100;

            double totalMonto = moraSoles + monto;

            txtDíasMora.Text = diasMora.ToString();
            txtMoraPorce.Text=moraPorc.ToString();
            txtMorasol.Text = moraSoles.ToString();
            txtMontoPagar.Text = totalMonto.ToString();
        }

        private void btNuevo_Click(object sender, RoutedEventArgs e)
        {
            txtCliente.Text = "";
            txtMonto.Text = "";
            dpFchVenc.SelectedDate = null;
            dpFchPago.SelectedDate = null;
            txtDíasMora.Text = "";
            txtMoraPorce.Text = "";
            txtMorasol.Text = "";
            txtMontoPagar.Text = "";
        }
        private void btFinalizar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}