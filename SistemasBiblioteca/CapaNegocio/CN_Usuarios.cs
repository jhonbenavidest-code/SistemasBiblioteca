using System;
using System.Data;
using SistemasBiblioteca.CapaDatos; 

namespace SistemasBiblioteca.CapaNegocio
{
    public class CN_Usuarios
    {
        
        private CD_Usuarios objetoCD = new CD_Usuarios();

        public DataTable MostrarUsuarios()
        {
            return objetoCD.Mostrar();
        }

        public void InsertarUsuario(string nombre, string apellido, string documento, string telefono, string correo)
        {
            
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(documento))
            {
                throw new ArgumentException("Los campos Nombre, Apellido y Documento son obligatorios y no pueden estar vacíos.");
            }

            objetoCD.Insertar(nombre, apellido, documento, telefono, correo);
        }

        public void EditarUsuario(string idUsuario, string nombre, string apellido, string documento, string telefono, string correo)
        {
            
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(documento))
            {
                throw new ArgumentException("Los campos Nombre, Apellido y Documento son obligatorios y no pueden estar vacíos.");
            }

           
            objetoCD.Editar(Convert.ToInt32(idUsuario), nombre, apellido, documento, telefono, correo);
        }

        public void EliminarUsuario(string idUsuario)
        {
            objetoCD.Eliminar(Convert.ToInt32(idUsuario));
        }
    }
}