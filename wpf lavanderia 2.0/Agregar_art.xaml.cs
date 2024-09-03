using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace wpf_lavanderia_2._0
{
    public partial class Agregar_art : Window
    {
        public ObservableCollection<Articulo> Articulos { get; set; }

        public Agregar_art(ObservableCollection<Articulo> articulos)
        {
            InitializeComponent();
            Articulos = articulos;
        }

     
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string cantidad = textBoxQuantity.Text;
            string articulo = (comboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string descripcion = textBoxDescription.Text;

            Articulos.Add(new Articulo
            {
                Cantidad = cantidad,
                articulo = articulo,
                Descripcion = descripcion
            });

            textBoxQuantity.Clear();
            comboBox.SelectedIndex = -1;
            textBoxDescription.Clear();
        }
    }
}
