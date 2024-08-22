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

namespace wpf_lavanderia_2._0
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
    


        private void NuevaFactura_Click(object sender, RoutedEventArgs e)
        {

            // Navegar a la nueva página dentro del Frame
            try
            {
                // Obtén la instancia de Facturar_nuevo
                Facturar_nuevo ventanaFactura = Facturar_nuevo.Instance;

                // Verifica si la ventana ya está abierta
                if (!ventanaFactura.IsVisible)
                {
                    // Si no está visible, muestra la ventana
                    ventanaFactura.Show();
                }
                else
                {
                    // Solicita confirmación al usuario si la ventana está abierta
                    MessageBoxResult result = MessageBox.Show(
                        "¿Desea continuar?",
                        "Si presionas 'SI' se eliminará cualquier información que tengas en la factura anterior",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        // Si el usuario elige 'Sí', crea una nueva instancia
                        ventanaFactura = new Facturar_nuevo();
                        ventanaFactura.Show();
                    }
                    // Si el usuario elige 'No', no hacer nada
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar abrir: " + ex.Message);
            }



        }
    }
}