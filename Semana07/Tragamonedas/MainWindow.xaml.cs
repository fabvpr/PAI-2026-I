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
using System.Windows.Threading;

namespace Tragamonedas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timerReloj;
        private DispatcherTimer timerJuego;
        private Random random = new Random();
        //total de intentos en este caso 60 intentos, cada intento es un tick del timerJuego
        private const int Tiempo_total_ticks = 60;
        private int contadorTicks=0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerReloj = new DispatcherTimer();
            timerReloj.Interval = TimeSpan.FromSeconds(1);
            //+= para agregar nuevos métodos en este caso
            timerReloj.Tick += TimerReloj_Tick;
            timerReloj.Start();

            timerJuego = new DispatcherTimer();
            timerJuego.Interval = TimeSpan.FromMilliseconds(100);
            timerJuego.Tick += TimerJuego_Tick;
        }
        private void TimerReloj_Tick(object sender, EventArgs e)
        {
            lbReloj.Content = DateTime.Now.ToString("HH:mm:ss");
        }
        private void TimerJuego_Tick(object sender, EventArgs e)
        {
            int numero1 = random.Next(10, 30);
            int numero2 = random.Next(10, 30);
            int numero3 = random.Next(10, 30);
            txtJugada1.Text = numero1.ToString();
            txtJugada2.Text = numero2.ToString();
            txtJugada3.Text = numero3.ToString();

            contadorTicks++;
            if (contadorTicks >= Tiempo_total_ticks)
            {
                timerJuego.Stop();
                validarJugada(numero1, numero2, numero3);
            }
        }
        private void validarJugada(int numero1, int numero2, int numero3)
        {
            
            if (numero1 == numero2 && numero2 == numero3 && numero1 == numero3)
            {
                lbResultado.Content = "¡Ganaste!";
                lbResultado.Background = Brushes.Green;
            }
            else 
            {
                lbResultado.Content = "Perdiste :(";
                lbResultado.Background= Brushes.IndianRed;
            }
            lbResultado.Visibility= Visibility.Visible;
            btIniciarJuego.IsEnabled = true;
        }
        private void btIniciarJuego_Click(object sender, RoutedEventArgs e)
        {
            timerJuego.Start();
            contadorTicks = 0;
            lbResultado.Visibility = Visibility.Hidden;
            btIniciarJuego.IsEnabled = false;
        }
    }
}