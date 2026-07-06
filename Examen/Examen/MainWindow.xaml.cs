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

namespace Examen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Registro> registros = new List<Registro>();
        public MainWindow()
        {
            InitializeComponent();
            lv_registro.ItemsSource = registros;

            int contadorGeneral = 0;
            int contadorEstudiante = 0;
            int contadorAdulto = 0;

            int acumular2D = 0;
            int acumular3D = 0;

            DateTime fecha = DateTime.Now;
            lb_fecha.Content = fecha.ToString("dd/MM/yyyy");
        }
        
        
        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            
            string cliente = txt_cliente.Text;
            ComboBox seleccionar = (ComboBox)cmbCategoria;
            string categoria = seleccionar.SelectedItem.ToString();
            ComboBox seleccionar2 = (ComboBox)cmbFormato;
            string formato = seleccionar2.SelectedItem.ToString();
            int total = 0;
            int acumular2d = 0;
            int acumular3d = 0;
            int contadorGeneral = 0;
            int contadorEstudiante = 0;
            int contadorAdulto = 0;

            if (categoria == "General")
            {
                if (formato == "2D")
                {
                    total = total + 20;
                    acumular2d =acumular2d + total;
                }
                if (formato == "3D")
                {
                    total = total + 30;
                    acumular3d = acumular3d + total;
                }
                contadorGeneral = +1;
            }
            if (categoria == "Estudiante")
            {
                if (formato == "2D")
                {
                    total = total + 15;
                    acumular2d = acumular2d + total;
                }
                if (formato == "3D")
                {
                    total = total + 25;
                    acumular3d = acumular3d + total;
                }
                contadorEstudiante = +1;
            }
            if (categoria == "Estudiante")
            {
                if (formato == "2D")
                {
                    total = total + 12;
                    acumular2d = acumular2d + total;
                }
                if (formato == "3D")
                {
                    total = total + 20;
                    acumular3d = acumular3d + total;
                }
                contadorAdulto = +1;
            }
            registros.Add(new Registro
            {
                Cliente = cliente,
                Categoria = categoria,
                Formato = formato,
                Precio = total
            });

            lv_registro.ItemsSource = null;
            lv_registro.ItemsSource = registros;

            lbGeneral.Content = contadorGeneral; 
            lbEstudiante.Content = contadorEstudiante;
            lbAdulto.Content = contadorAdulto;
            lb_2d.Content = acumular2d;
            lb_3d.Content = acumular3d;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            

        }
    }

    internal record struct NewStruct(object Item1, object Item2)
    {
        public static implicit operator (object, object)(NewStruct value)
        {
            return (value.Item1, value.Item2);
        }

        public static implicit operator NewStruct((object, object) value)
        {
            return new NewStruct(value.Item1, value.Item2);
        }
    }
}