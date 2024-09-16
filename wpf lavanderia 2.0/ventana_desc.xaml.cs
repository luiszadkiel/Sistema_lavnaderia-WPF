using System;
using System.Windows;

namespace wpf_lavanderia_2._0
{
  
    public partial class ventana_desc : Window
    {
        // Crear una instancia de los parámetros requeridos
        object sender = null; // Si no tienes un control específico como 'sender'
        RoutedEventArgs e = new RoutedEventArgs(); // Crear una instancia de RoutedEventArgs
        // Propiedad pública para almacenar el valor de descuento
        public static decimal texto { get; private set; }

        public ventana_desc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Maneja el clic del botón y actualiza el valor de descuento en Facturar_nuevo
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Intenta convertir el texto del TextBox a decimal
            if (decimal.TryParse(textBoxDescuento.Text, out decimal valorDescuento))
            {
                // Asigna el valor actualizado a la propiedad estática en la clase Facturar_nuevo
                texto = valorDescuento;
                Facturar_nuevo ventanaFactura = MainWindow.ventanaFactura;

                // Llamar al método mostar_precioClick en la instancia de ventanaFactura
                ventanaFactura.mostar_precioClick(sender, e);


                // Cierra la ventana
                this.Close();
            }
            else
            {
                MessageBox.Show("El valor ingresado no es un número válido");
            }
        }

     
      
    }
}
