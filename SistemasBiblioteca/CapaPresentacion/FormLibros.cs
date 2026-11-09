using SistemasBiblioteca.CapaNegocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemasBiblioteca.CapaPresentacion
{
    public partial class FormLibros : Form
    {
        private CN_Libros objetoCN = new CN_Libros();
        private string isbnAntiguo = null;
        private bool editar = false;

        public FormLibros()
        {
            InitializeComponent();
        }

        private void FormLibros_Load(object sender, EventArgs e)
        {
            MostrarLibros();
        }

        private void MostrarLibros()
        {
            dgvLibros.DataSource = objetoCN.MostrarLibros();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!editar)
                {
                    objetoCN.InsertarLibro(txtIsbn.Text, txtTitulo.Text, txtIdAutor.Text, txtIdEditorial.Text, txtCategoria.Text, txtAnio.Text, txtExistencias.Text);
                    MessageBox.Show("Libro registrado correctamente.");
                }
                else
                {
                    // Enviamos el isbnAntiguo y el nuevo (txtIsbn.Text)
                    objetoCN.EditarLibro(isbnAntiguo, txtIsbn.Text, txtTitulo.Text, txtIdAutor.Text, txtIdEditorial.Text, txtCategoria.Text, txtAnio.Text, txtExistencias.Text);
                    MessageBox.Show("Libro editado correctamente.");
                    editar = false;
                }
                MostrarLibros();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvLibros.SelectedRows.Count > 0)
            {
                editar = true;

                isbnAntiguo = dgvLibros.CurrentRow.Cells["ISBN"].Value.ToString();

                txtIsbn.Text = dgvLibros.CurrentRow.Cells["ISBN"].Value.ToString();
                txtTitulo.Text = dgvLibros.CurrentRow.Cells["Titulo"].Value.ToString();
                txtIdAutor.Text = dgvLibros.CurrentRow.Cells["IdAutor"].Value.ToString();
                txtIdEditorial.Text = dgvLibros.CurrentRow.Cells["IdEditorial"].Value.ToString();
                txtCategoria.Text = dgvLibros.CurrentRow.Cells["Categoria"].Value.ToString();
                txtAnio.Text = dgvLibros.CurrentRow.Cells["Anio"].Value.ToString();
                txtExistencias.Text = dgvLibros.CurrentRow.Cells["Existencias"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para editar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvLibros.SelectedRows.Count > 0)
            {
                try
                {
                    string isbn = dgvLibros.CurrentRow.Cells["ISBN"].Value.ToString();
                    objetoCN.EliminarLibro(isbn);
                    MessageBox.Show("Libro eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarLibros();
                }
                catch (Exception ex)
                {
                    // Aquí atrapamos la excepción que manda CD_Libros
                    MessageBox.Show(ex.Message, "Advertencia del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar.");
            }
        }

        private void LimpiarFormulario()
        {
            txtIsbn.Clear();
            txtTitulo.Clear();
            txtIdAutor.Clear();
            txtIdEditorial.Clear();
            txtCategoria.Clear();
            txtAnio.Clear();
            txtExistencias.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();

            
            if (dgvLibros.DataSource is DataTable dt)
            {
                if (string.IsNullOrEmpty(filtro))
                {
                    // Si el buscador está vacío, mostramos todos los libros
                    dt.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    // Filtramos por Título, ISBN o Año (puedes ajustar los nombres de las columnas según tu BD)
                    dt.DefaultView.RowFilter = string.Format(
                        "Titulo LIKE '%{0}%' OR ISBN LIKE '%{0}%' OR Convert(Anio, 'System.String') LIKE '%{0}%'", filtro);
                }
            }
        }
    }
}
      
     




