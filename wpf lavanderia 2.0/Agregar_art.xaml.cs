using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace wpf_lavanderia_2._0
{
    public partial class Agregar_art : Window
    {
        public ObservableCollection<Articulo> Articulos { get; set; }
        public static string nombre { get; set; }
        public static string tipo_servicio2 { get; set; }

        public static decimal cantidad_art { get; set; }

        public static decimal sub_total { get; set; }



    public Agregar_art(ObservableCollection<Articulo> articulos)
        {
            InitializeComponent();
            Articulos = articulos;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Captura de valores de los controles en la ventana.
            string cantidad = textBoxQuantity.Text;
            cantidad_art = decimal.Parse(cantidad); 
            string articulo = (comboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            nombre = articulo;// variablas para la base de datos bucar los precios
            string descripcion = textBoxDescription.Text;
            string tipo_servicio = (tipo_Servicio.SelectedItem as ComboBoxItem)?.Content.ToString();
            tipo_servicio2 = tipo_servicio;// variablas para la base de datos bucar los precios
            string Monto = textBoxQuantity.Text;
            Facturar_nuevo.Calcular_precio();


            // Agregar el nuevo Articulo a la colección ObservableCollection.
            Articulos.Add(new Articulo
            {
                Cantidad = cantidad,
                articulo = articulo,
                Descripcion = descripcion,
                Tipo_servicio = tipo_servicio, // Asegúrate de que esta propiedad exista en la clase Articulo.
                Monto = Calcular_prec.precio.ToString(),  // Convierte el decimal a string

            });

            // Limpiar los controles para el siguiente ingreso de datos.
            textBoxQuantity.Clear();
            comboBox.SelectedIndex = -1;
            tipo_Servicio.SelectedIndex = -1; // Limpiar la selección de tipo de servicio.
            textBoxDescription.Clear();
        }

    }
}
