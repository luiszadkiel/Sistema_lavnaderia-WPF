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

        // Instancia única de la conexión
        private static MySqlConnection instancia;

        // Constructor para inicializar la cadena de conexión
        public Conexion_DB() { 
     
        }


        // Método público estático para obtener la instancia de la conexión
        public static MySqlConnection ObtenerConexion()
        {
            if (instancia == null)
            {
                try
                {
                    // Actualiza con tus credenciales de conexión
                    string connectionString = "Server=127.0.0.1;Port=3306;Database=lavanderia_verano;Uid=root;Pwd=admin;";
                    instancia = new MySqlConnection(connectionString);
                    instancia.Open();
                    MessageBox.Show("Conexión a MySQL establecida.");
                }
                catch (MySqlException e)
                {
                    MessageBox.Show("Error al conectar a la base de datos: " + e.Message);
                }
            }
            return instancia; // Retorna la instancia de la conexión existente
        }






        // Método para abrir la conexión
        public void AbrirConexion()
        {
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                {
                    conexion.Open();
                    MessageBox.Show("Conexión abierta exitosamente.");
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
                    MessageBox.Show("Conexión cerrada exitosamente.");
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
                MessageBox.Show("Consulta ejecutada correctamente.");
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
