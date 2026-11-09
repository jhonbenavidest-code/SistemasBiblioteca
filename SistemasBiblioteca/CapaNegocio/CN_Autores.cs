using System;
using System.Data;
using SistemasBiblioteca.CapaDatos;

namespace SistemasBiblioteca.CapaNegocio
{
    public class CN_Autores
    {
        private CD_Autores objetoCD = new CD_Autores();

        public DataTable MostrarAutores()
        {
            return objetoCD.Mostrar();
        }

        public void InsertarAutor(string nombre, string apellido)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
            {
                throw new ArgumentException("El nombre y el apellido del autor son obligatorios.");
            }
            objetoCD.Insertar(nombre, apellido);
        }

        public void EditarAutor(string idAutor, string nombre, string apellido)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
            {
                throw new ArgumentException("El nombre y el apellido del autor son obligatorios.");
            }
            objetoCD.Editar(Convert.ToInt32(idAutor), nombre, apellido);
        }

        public void EliminarAutor(string idAutor)
        {
            objetoCD.Eliminar(Convert.ToInt32(idAutor));
        }
    }
}