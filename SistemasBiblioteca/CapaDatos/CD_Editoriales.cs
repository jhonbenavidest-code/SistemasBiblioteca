using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemasBiblioteca.CapaDatos
{
    public class CD_Editoriales : CD_Conexion
    {
        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand("SELECT * FROM Editoriales", conexion))
                {
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        tabla.Load(lector);
                    }
                }
            }
            return tabla;
        }

        public void Insertar(string nombre)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                string consultaSql = "INSERT INTO Editoriales (Nombre) VALUES (@Nombre)";
                using (SqlCommand comando = new SqlCommand(consultaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", nombre);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Editar(int idEditorial, string nombre)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                string consultaSql = "UPDATE Editoriales SET Nombre = @Nombre WHERE IdEditorial = @IdEditorial";
                using (SqlCommand comando = new SqlCommand(consultaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@IdEditorial", idEditorial);
                    comando.Parameters.AddWithValue("@Nombre", nombre);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Eliminar(int idEditorial)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                string consultaSql = "DELETE FROM Editoriales WHERE IdEditorial = @IdEditorial";
                using (SqlCommand comando = new SqlCommand(consultaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@IdEditorial", idEditorial);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}