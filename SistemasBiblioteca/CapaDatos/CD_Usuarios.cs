using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemasBiblioteca.CapaDatos
{
    public class CD_Usuarios : CD_Conexion
    {
        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand("SELECT * FROM Usuarios", conexion))
                {
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        tabla.Load(lector);
                    }
                }
            }
            return tabla;
        }

        public void Insertar(string nombre, string apellido, string documento, string telefono, string correo)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                string consultaSql = "INSERT INTO Usuarios (Nombre, Apellido, Documento, Telefono, Correo) " +
                                     "VALUES (@Nombre, @Apellido, @Documento, @Telefono, @Correo)";

                using (SqlCommand comando = new SqlCommand(consultaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", nombre);
                    comando.Parameters.AddWithValue("@Apellido", apellido);
                    comando.Parameters.AddWithValue("@Documento", documento);
                    comando.Parameters.AddWithValue("@Telefono", telefono);
                    comando.Parameters.AddWithValue("@Correo", correo);

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Editar(int idUsuario, string nombre, string apellido, string documento, string telefono, string correo)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                string consultaSql = "UPDATE Usuarios SET Nombre = @Nombre, Apellido = @Apellido, Documento = @Documento, Telefono = @Telefono, Correo = @Correo WHERE IdUsuario = @IdUsuario";

                using (SqlCommand comando = new SqlCommand(consultaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    comando.Parameters.AddWithValue("@Nombre", nombre);
                    comando.Parameters.AddWithValue("@Apellido", apellido);
                    comando.Parameters.AddWithValue("@Documento", documento);
                    comando.Parameters.AddWithValue("@Telefono", telefono);
                    comando.Parameters.AddWithValue("@Correo", correo);

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Eliminar(int idUsuario)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                string consultaSql = "DELETE FROM Usuarios WHERE IdUsuario = @IdUsuario";

                using (SqlCommand comando = new SqlCommand(consultaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}