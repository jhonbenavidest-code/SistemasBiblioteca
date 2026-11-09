using System;
using System.Data;
using SistemasBiblioteca.CapaDatos;

namespace SistemasBiblioteca.CapaNegocio
{
    public class CN_Editoriales
    {
        private CD_Editoriales objetoCD = new CD_Editoriales();

        public DataTable MostrarEditoriales()
        {
            return objetoCD.Mostrar();
        }

        public void InsertarEditorial(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre de la editorial es obligatorio.");
            }
            objetoCD.Insertar(nombre);
        }

        public void EditarEditorial(string idEditorial, string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre de la editorial es obligatorio.");
            }
            objetoCD.Editar(Convert.ToInt32(idEditorial), nombre);
        }

        public void EliminarEditorial(string idEditorial)
        {
            objetoCD.Eliminar(Convert.ToInt32(idEditorial));
        }
    }
}