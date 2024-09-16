using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using MySql.Data.MySqlClient;
using System;
using System.Windows;

namespace wpf_lavanderia_2._0
{
    internal class Calcular_prec
    {
        string nombre_tabl { get; set; }
        string nombre_Artic { get; set; }
        public static decimal precio { get; set; }
      
        public Calcular_prec(string nombre_tabl, string nombre_Artic)
        {
            this.nombre_tabl = nombre_tabl;
            this.nombre_Artic = nombre_Artic;

            // Consulta SQL con parámetros (sin parámetro para la tabla)
            string query = $"SELECT precio FROM {nombre_tabl} WHERE nombre = @nomb_art";

            try
            {
                using (MySqlConnection conexion = Conexion_DB.ObtenerConexion())
                {
                    if (conexion.State != System.Data.ConnectionState.Open)
                    {
                        conexion.Open();
                    }

                    // Crear un comando SQL
                    using (MySqlCommand command = new MySqlCommand(query, conexion))
                    {
                        // Agregar parámetros al comando
                        command.Parameters.AddWithValue("@nomb_art", nombre_Artic); // Valor del parámetro Nombre

                        // Ejecutar el comando y leer el resultado
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                precio = reader.GetDecimal(0);
                                precio = precio * Agregar_art.cantidad_art;
                                Agregar_art.sub_total += precio;


                                Facturar_nuevo.LabelText3 = Agregar_art.sub_total;
                                
                            }
                            else
                            {
                                MessageBox.Show("No se encontró el artículo especificado.");
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Manejo específico de errores de MySQL
                MessageBox.Show($"Error de MySQL: {ex.Message}", "Error SQL", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                // Manejo general de excepciones
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
