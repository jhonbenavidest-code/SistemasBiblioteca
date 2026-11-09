using System.Data.SqlClient;

namespace SistemasBiblioteca.CapaDatos
{
    public abstract class CD_Conexion
    {
        private static string cadenaConexion = "Server=(local);Database=AcaBiblioteca;Integrated Security=True;";
        protected SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}