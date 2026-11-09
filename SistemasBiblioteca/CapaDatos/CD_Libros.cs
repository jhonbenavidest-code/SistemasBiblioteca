using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemasBiblioteca.CapaDatos
{
    public class CD_Libros : CD_Conexion
    {
        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand("SELECT * FROM Libros", conexion))
                {
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        tabla.Load(lector);
                    }
                }
            }
            return tabla;
        }

        public void Insertar(string isbn, string titulo, int idAutor, int idEditorial, string categoria, int anio, int existencias)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                string consultaSql = "INSERT INTO Libros (ISBN, Titulo, IdAutor, IdEditorial, Categoria, Anio, Existencias) " +
                                     "VALUES (@ISBN, @Titulo, @IdAutor, @IdEditorial, @Categoria, @Anio, @Existencias)";

                using (SqlCommand comando = new SqlCommand(consultaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@ISBN", isbn);
                    comando.Parameters.AddWithValue("@Titulo", titulo);
                    comando.Parameters.AddWithValue("@IdAutor", idAutor);
                    comando.Parameters.AddWithValue("@IdEditorial", idEditorial);
                    comando.Parameters.AddWithValue("@Categoria", categoria);
                    comando.Parameters.AddWithValue("@Anio", anio);
                    comando.Parameters.AddWithValue("@Existencias", existencias);

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Editar(string isbnAntiguo, string isbnNuevo, string titulo, int idAutor, int idEditorial, string categoria, int anio, int existencias)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                string consultaSql = "UPDATE Libros SET ISBN = @isbnNuevo, Titulo = @titulo, IdAutor = @idAutor, IdEditorial = @idEditorial, Categoria = @categoria, Anio = @anio, Existencias = @existencias WHERE ISBN = @isbnAntiguo";

                using (SqlCommand comando = new SqlCommand(consultaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@isbnNuevo", isbnNuevo);
                    comando.Parameters.AddWithValue("@titulo", titulo);
                    comando.Parameters.AddWithValue("@idAutor", idAutor);
                    comando.Parameters.AddWithValue("@idEditorial", idEditorial);
                    comando.Parameters.AddWithValue("@categoria", categoria);
                    comando.Parameters.AddWithValue("@anio", anio);
                    comando.Parameters.AddWithValue("@existencias", existencias);
                    comando.Parameters.AddWithValue("@isbnAntiguo", isbnAntiguo);

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Eliminar(string isbn)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                
                string consultaSql = "DELETE FROM Prestamos WHERE ISBN = @isbn; " +
                                     "DELETE FROM Libros WHERE ISBN = @isbn;";

                using (SqlCommand comando = new SqlCommand(consultaSql, conexion))
                {
                    try
                    {
                        comando.Parameters.AddWithValue("@isbn", isbn);
                        comando.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error al intentar eliminar el libro y su historial de préstamos: " + ex.Message);
                    }
                }
            }
        }
    }
}