using System;
using System.Data;
using SistemasBiblioteca.CapaDatos;

namespace SistemasBiblioteca.CapaNegocio
{
    public class CN_Libros
    {
        private CD_Libros objetoCD = new CD_Libros();

        public DataTable MostrarLibros()
        {
            return objetoCD.Mostrar();
        }

        public void InsertarLibro(string isbn, string titulo, string idAutor, string idEditorial, string categoria, string anio, string existencias)
        {
            if (string.IsNullOrWhiteSpace(isbn) || string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(existencias))
            {
                throw new ArgumentException("El ISBN, Título y Existencias son campos obligatorios.");
            }

            // Convertimos los tipos numéricos antes de pasarlos a la Capa de Datos
            int idAutorInt = Convert.ToInt32(idAutor);
            int idEditorialInt = Convert.ToInt32(idEditorial);
            int anioInt = string.IsNullOrWhiteSpace(anio) ? 0 : Convert.ToInt32(anio);
            int existenciasInt = Convert.ToInt32(existencias);

            objetoCD.Insertar(isbn, titulo, idAutorInt, idEditorialInt, categoria, anioInt, existenciasInt);
        }

        public void EditarLibro(string isbnAntiguo, string isbnNuevo, string titulo, string idAutor, string idEditorial, string categoria, string anio, string existencias)
        {
            if (string.IsNullOrWhiteSpace(isbnAntiguo) || string.IsNullOrWhiteSpace(isbnNuevo) || string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(existencias))
            {
                throw new ArgumentException("El ISBN, Título y Existencias son campos obligatorios.");
            }

            int idAutorInt = Convert.ToInt32(idAutor);
            int idEditorialInt = Convert.ToInt32(idEditorial);
            int anioInt = string.IsNullOrWhiteSpace(anio) ? 0 : Convert.ToInt32(anio);
            int existenciasInt = Convert.ToInt32(existencias);

            objetoCD.Editar(isbnAntiguo, isbnNuevo, titulo, idAutorInt, idEditorialInt, categoria, anioInt, existenciasInt);
        }
        public void EliminarLibro(string isbn)
        {
            objetoCD.Eliminar(isbn);
        }
    }
}