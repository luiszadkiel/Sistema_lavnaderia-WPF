using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Windows;

namespace wpf_lavanderia_2._0
{
    class Cl_Factura : INotifyPropertyChanged
    {  
        
        // Propiedades
        public event PropertyChangedEventHandler? PropertyChanged;
     
        private int noFactura;
        public int NoFactura
        {
            get => noFactura;
            set
            {
                if (noFactura != value)
                {
                    noFactura = value;
                    OnPropertyChanged(nameof(NoFactura));
                }
            }
        }

        public DateOnly FechaFactura { get; set; }
        public DateOnly FechaEntrega { get; set; }
        public string NombreEmpresa { get; set; }
        public string AcuerdoFactura { get; set; }
        public string RecibidoPor { get; set; }
        public int Descuento { get; set; }
        public int SubTotal { get; set; }
        public int TotalFactura { get; set; }
        public string MetodoPago { get; set; }

        // Constructor
        public Cl_Factura()
        {
            NoFactura = 1; // Inicializa NoFactura

            // Consulta SQL con parámetros
            string query = "SELECT ID_Factura FROM Factura ORDER BY ID_Factura DESC LIMIT 1 ";

            using (MySqlConnection conexion = Conexion_DB.ObtenerConexion())
            {
                try
                {

                    // Crear el comando SQL
                    using (MySqlCommand command = new MySqlCommand(query, conexion))
                    {
                        // Ejecutar el comando y leer el resultado
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            // Convertir el resultado a int
                            NoFactura += Convert.ToInt32(result);
                        }
                        else
                        {
                            // Maneja el caso en que no se obtienen resultados
                            MessageBox.Show("No se encontraron facturas.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error 2: " + ex.Message);
                }
            }
        }

        // Métodos
        // Implementación de INotifyPropertyChanged

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

       
    }
}
