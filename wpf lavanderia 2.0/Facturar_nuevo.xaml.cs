using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace wpf_lavanderia_2._0
{
    /// <summary>
    /// Lógica de interacción para Facturar_nuevo.xaml
    /// </summary>
    /// 


    public partial class Facturar_nuevo : Window
    {
        private static Facturar_nuevo _instance;
        public static decimal LabelText3 { get; set; }  // Variable que controlará el texto del Label 
        public static String des { get; set; }


        ventana_desc ventana = new ventana_desc();



        public ObservableCollection<Articulo> Articulos { get; set; }


        // Constructor público para permitir la creación de instancias fuera de la clase
        public Facturar_nuevo()
        {
            InitializeComponent();

            // Establecer el DataContext
            Cl_Factura factura = new Cl_Factura();
            DataContext = factura;
            Articulos = new ObservableCollection<Articulo>();
            hi.ItemsSource = Articulos;
            descuentolabel = descuentolabel;

         




        }

        // Propiedad estática para acceder a la instancia única
        public static Facturar_nuevo Instance
        {
            get
            {
                // Si la instancia no existe o no está visible, créala
                if (_instance == null || !_instance.IsVisible)
                {
                    _instance = new Facturar_nuevo();
                }
                return _instance;
            }
        }

    

        private void AddNewComboBox(object sender, RoutedEventArgs e)
        {

                var agregarArtWindow = new Agregar_art(Articulos);
                agregarArtWindow.Show();
            

        }
        private void Eliminar_Click(object sender, RoutedEventArgs e)
{
           var menuItem = sender as MenuItem;
           var contextMenu = menuItem?.Parent as ContextMenu;
           var dataGrid2 = contextMenu?.PlacementTarget as DataGrid;

          if (dataGrid2 != null)
    {
            var selectedItem = dataGrid2.SelectedItem as Articulo;

             if (selectedItem != null)
              {
               if (decimal.TryParse(selectedItem.Monto, out decimal monto))
            {
                // Restar el monto del artículo del subtotal
                Agregar_art.sub_total -= monto;

                // Actualizar la propiedad estática LabelText3
                LabelText3 = Agregar_art.sub_total;

                // Eliminar el artículo de la colección
                Articulos.Remove(selectedItem);

                // Llamar al método estático
                mostar_precioClick(null, null);
                }
                else
                {
                 MessageBox.Show("El monto del artículo no es un valor decimal válido.");
                 }
        }
    }
}



        public static void Calcular_precio()
        {
            Calcular_prec cal = new Calcular_prec(Agregar_art.tipo_servicio2, Agregar_art.nombre);

        }

        public void mostar_precioClick(object sender, RoutedEventArgs e)
        {
            subtotallabel.Content = LabelText3 - ventana_desc.texto;
            descuentolabel.Content = ventana_desc.texto;
            des = string.Format(descuentolabel.Content.ToString());
        }


        private void DESCUENTOButton_Click(object sender, RoutedEventArgs e)
        {

            ventana_desc ventana = new ventana_desc();
            ventana.Show(); // Abre la ventana secundaria sin bloquear la principal



        }
    }

}
