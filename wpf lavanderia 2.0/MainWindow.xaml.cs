using DocumentFormat.OpenXml.Presentation;
using System;
using System.Windows;

namespace wpf_lavanderia_2._0
{
    public partial class MainWindow : Window
    {
        public static Facturar_nuevo ventanaFactura;

         

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NuevaFactura_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ventanaFactura == null || !ventanaFactura.IsVisible)
                {
                    ventanaFactura = new Facturar_nuevo();
                    ventanaFactura.Show();
                }
                else
                {
                    // Solicita confirmación al usuario si la ventana está abierta
                    MessageBoxResult result = MessageBox.Show(
                        "¿Desea continuar?",
                        "Si presionas 'Sí', se eliminará cualquier información que tengas en la factura anterior.",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        ventanaFactura.Close();
                        ventanaFactura = new Facturar_nuevo();
                        ventanaFactura.Show();
                    }
                    // Si el usuario elige 'No', no hacer nada
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar abrir la ventana: " + ex.Message);
            }
        }
    }
}
