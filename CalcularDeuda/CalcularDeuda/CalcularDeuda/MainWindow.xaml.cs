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

namespace CalcularDeuda
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

        private void bt_calcular_Click(object sender, RoutedEventArgs e)
        {
            double deuda = Double.Parse(txt_deuda.Text);
            double descuento = Double.Parse(txt_descuento.Text);
            int bonus = int.Parse(txt_bonus.Text);

            if (check_descuento.IsChecked==true)
            {
                deuda = Math.Round(deuda - (deuda * descuento));
            }
            if (check_bonus.IsChecked == true)
            {
                deuda = Math.Round(deuda - ((bonus * 3) / 10),2);
            }

            lb_resultado.Content = $"La deuda a pagar es: {deuda}";
        }
    }
}