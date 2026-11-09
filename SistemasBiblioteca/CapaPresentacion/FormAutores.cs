using System;
using System.Windows.Forms;
using SistemasBiblioteca.CapaNegocio;

namespace SistemasBiblioteca.CapaPresentacion
{
    public partial class FormAutores : Form
    {
        private CN_Autores objetoCN = new CN_Autores();
        private string idAutor = null;
        private bool editar = false;

        public FormAutores()
        {
            InitializeComponent();
        }

        private void FormAutores_Load(object sender, EventArgs e)
        {
            MostrarAutores();
        }

        private void MostrarAutores()
        {
            dgvAutores.DataSource = objetoCN.MostrarAutores();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!editar)
                {
                    objetoCN.InsertarAutor(txtNombre.Text, txtApellido.Text);
                    MessageBox.Show("Autor registrado correctamente.");
                }
                else
                {
                    objetoCN.EditarAutor(idAutor, txtNombre.Text, txtApellido.Text);
                    MessageBox.Show("Autor editado correctamente.");
                    editar = false;
                }
                MostrarAutores();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvAutores.SelectedRows.Count > 0)
            {
                editar = true;
                txtNombre.Text = dgvAutores.CurrentRow.Cells["Nombre"].Value.ToString();
                txtApellido.Text = dgvAutores.CurrentRow.Cells["Apellido"].Value.ToString();
                idAutor = dgvAutores.CurrentRow.Cells["IdAutor"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para editar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAutores.SelectedRows.Count > 0)
            {
                idAutor = dgvAutores.CurrentRow.Cells["IdAutor"].Value.ToString();
                objetoCN.EliminarAutor(idAutor);
                MessageBox.Show("Autor eliminado exitosamente.");
                MostrarAutores();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar.");
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellido.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}