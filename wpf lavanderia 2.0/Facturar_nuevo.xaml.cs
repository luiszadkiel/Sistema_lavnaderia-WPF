using System;
using System.Collections.Generic;
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

        // Constructor público para permitir la creación de instancias fuera de la clase
        public Facturar_nuevo()
        {
            InitializeComponent();
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

    }
