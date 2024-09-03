﻿using System;
using System.Windows;
using MySql.Data.MySqlClient; // Asegúrate de tener el paquete NuGet MySql.Data instalado

namespace wpf_lavanderia_2._0
{
    public class Conexion_DB
    {
        // Cadena de conexión
        private string connectionString;

        // Objeto de conexión
        private MySqlConnection conexion;

      

        // Constructor para inicializar la cadena de conexión
        public Conexion_DB() { 
     
        }


        // Método público estático para obtener la instancia de la conexión
        public static MySqlConnection ObtenerConexion()
        {
         
      
                    string connectionString = "Server=127.0.0.1;Port=3306;Database=lavanderia_verano;Uid=root;Pwd=admin;";
   
            
            return new MySqlConnection(connectionString);
        }






        // Método para abrir la conexión
        public void AbrirConexion()
        {
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                {
                    conexion.Open();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al abrir la conexión: " + ex.Message);
            }
        }

        // Método para cerrar la conexión
        public void CerrarConexion()
        {
            try
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cerrar la conexión: " + ex.Message);
            }
        }

        // Método para ejecutar consultas SQL (por ejemplo, INSERT, UPDATE, DELETE)
        public void EjecutarConsulta(string query)
        {
            try
            {
                AbrirConexion();
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }

        // Método para obtener la conexión (por si es necesario en otras partes del programa)
       
    }
}
