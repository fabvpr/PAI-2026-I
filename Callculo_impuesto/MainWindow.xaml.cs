using System.Diagnostics;
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

namespace Callculo_impuesto
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
            double ingresos =Double.Parse(txt_ingresos.Text);
            double resultado_fonavi=0;
            double resultado_impor = 0;
            double resultado_afp = 0;

            if (Check_fonavi.IsChecked == true)
            {
                resultado_fonavi = (ingresos * (0.08));
                lb_fonavi.Content = $"Fonavi: {resultado_fonavi}";
            }
            if (Check_importe.IsChecked == true)
            {
                resultado_impor = (ingresos * (0.05));
                lb_impuesto.Content = $"Imp-renta: {resultado_impor}";
            }
            if (Check_afp.IsChecked == true)
            {
                resultado_afp = (ingresos * (0.12));
                lb_afp.Content = $"A.F.P: {resultado_afp}";
            }
            double resultadototal = resultado_fonavi + resultado_impor+ resultado_afp;
            lb_resultado.Content = $"El impuesto a pagar es: {ingresos - resultadototal}";
        }
    }
}