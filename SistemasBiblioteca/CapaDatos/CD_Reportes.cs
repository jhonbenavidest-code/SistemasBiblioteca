using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemasBiblioteca.CapaDatos
{
    public class CD_Reportes : CD_Conexion
    {
        public DataTable ResumenEstadisticas()
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                // Subconsultas para traer todos los totales en una sola fila
                string consulta = @"
                    SELECT 
                        (SELECT COUNT(*) FROM Usuarios) AS TotalUsuarios,
                        (SELECT COUNT(*) FROM Libros) AS TotalTitulos,
                        (SELECT ISNULL(SUM(Existencias), 0) FROM Libros) AS LibrosDisponibles,
                        (SELECT COUNT(*) FROM Prestamos WHERE Estado = 'Activo') AS PrestamosActivos";

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
    }
}