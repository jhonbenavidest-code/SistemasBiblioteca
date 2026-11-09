using System;
using System.Data;
using SistemasBiblioteca.CapaDatos;

namespace SistemasBiblioteca.CapaNegocio
{
    public class CN_Prestamos
    {
        private CD_Prestamos objetoCD = new CD_Prestamos();

        public DataTable MostrarPrestamos()
        {
            return objetoCD.Mostrar();
        }

        public void PrestarLibro(string idUsuario, string isbn)
        {
            if (string.IsNullOrWhiteSpace(idUsuario) || string.IsNullOrWhiteSpace(isbn))
            {
                throw new ArgumentException("Debe ingresar el ID del Usuario y el ISBN del Libro para realizar el préstamo.");
            }

            objetoCD.Prestar(Convert.ToInt32(idUsuario), isbn);
        }

        public void DevolverLibro(string idPrestamo, string isbn)
        {
            if (string.IsNullOrWhiteSpace(idPrestamo) || string.IsNullOrWhiteSpace(isbn))
            {
                throw new ArgumentException("Debe seleccionar un préstamo válido para realizar la devolución.");
            }

            objetoCD.Devolver(Convert.ToInt32(idPrestamo), isbn);
        }
    }
}