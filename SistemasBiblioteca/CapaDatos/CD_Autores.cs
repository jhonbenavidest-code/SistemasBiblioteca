using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemasBiblioteca.CapaDatos
{
    public class CD_Autores : CD_Conexion
    {
        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand("SELECT * FROM Autores", conexion))
                {
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        tabla.Load(lector);
                    }
                }
            }
            return tabla;
        }

        public void Insertar(string nombre, string apellido)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                string consultaSql = "INSERT INTO Autores (Nombre, Apellido) VALUES (@Nombre, @Apellido)";
                using (SqlCommand comando = new SqlCommand(consultaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", nombre);
                    comando.Parameters.AddWithValue("@Apellido", apellido);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Editar(int idAutor, string nombre, string apellido)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                string consultaSql = "UPDATE Autores SET Nombre = @Nombre, Apellido = @Apellido WHERE IdAutor = @IdAutor";
                using (SqlCommand comando = new SqlCommand(consultaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@IdAutor", idAutor);
                    comando.Parameters.AddWithValue("@Nombre", nombre);
                    comando.Parameters.AddWithValue("@Apellido", apellido);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Eliminar(int idAutor)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                string consultaSql = "DELETE FROM Autores WHERE IdAutor = @IdAutor";
                using (SqlCommand comando = new SqlCommand(consultaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@IdAutor", idAutor);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}