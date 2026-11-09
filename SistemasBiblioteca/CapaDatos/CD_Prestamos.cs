using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemasBiblioteca.CapaDatos
{
    public class CD_Prestamos : CD_Conexion
    {
        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                // Usamos JOIN para traer los nombres en lugar de solo mostrar los IDs
                string consulta = @"SELECT p.IdPrestamo, u.Nombre + ' ' + u.Apellido AS Usuario, 
                                           l.Titulo AS Libro, p.FechaPrestamo, p.FechaDevolucion, p.Estado, p.ISBN 
                                    FROM Prestamos p 
                                    INNER JOIN Usuarios u ON p.IdUsuario = u.IdUsuario 
                                    INNER JOIN Libros l ON p.ISBN = l.ISBN";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        tabla.Load(lector);
                    }
                }
            }
            return tabla;
        }

        public void Prestar(int idUsuario, string isbn)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                // 1. Registra el préstamo con fecha actual (GETDATE) y estado 'Activo'
                // 2. Resta 1 a las existencias del libro
                string consultaSql = "INSERT INTO Prestamos (IdUsuario, ISBN, FechaPrestamo, Estado) VALUES (@IdUsuario, @ISBN, GETDATE(), 'Activo'); " +
                                     "UPDATE Libros SET Existencias = Existencias - 1 WHERE ISBN = @ISBN;";
                using (SqlCommand comando = new SqlCommand(consultaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    comando.Parameters.AddWithValue("@ISBN", isbn);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Devolver(int idPrestamo, string isbn)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                // 1. Marca la fecha de devolución y cambia estado a 'Devuelto'
                // 2. Suma 1 a las existencias del libro devuelto
                string consultaSql = "UPDATE Prestamos SET FechaDevolucion = GETDATE(), Estado = 'Devuelto' WHERE IdPrestamo = @IdPrestamo; " +
                                     "UPDATE Libros SET Existencias = Existencias + 1 WHERE ISBN = @ISBN;";
                using (SqlCommand comando = new SqlCommand(consultaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@IdPrestamo", idPrestamo);
                    comando.Parameters.AddWithValue("@ISBN", isbn);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}