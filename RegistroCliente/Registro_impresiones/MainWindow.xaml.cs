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

namespace Registro_impresiones
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

        private void txt_cliente_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (rb_escolar.IsChecked == true)
                tarifa = "Escolar";
            else if (rb_universitario.IsChecked == true)
                tarifa = "Universitario";
            else if (rb_organizacion.IsChecked == true)
                tarifa = "Organización";

            double cantidad = Convert.ToDouble(txt_cantidad.Text);
            double importe = 0;

            switch (tarifa)
            {
                case "Escolar":
                    importe = cantidad * 0.05;
                    break;
                case "Universitario":
                    importe = cantidad * 0.08;
                    break;
                case "Organización":
                    importe = cantidad * 0.10;
                    break;
            }

            lbox_cliente.Items.Add(txt_cliente.Text);
            lbox_celular.Items.Add(txt_celular.Text);
            lbox_cantidad.Items.Add(txt_cantidad.Text);
            lbox_tarifa.Items.Add(tarifa);
            lbox_importe.Items.Add(importe);

            txt_cliente.Clear();
            txt_celular.Clear();
            txt_cantidad.Clear();

            txt_cliente.Focus();
        }
    }
    }
}