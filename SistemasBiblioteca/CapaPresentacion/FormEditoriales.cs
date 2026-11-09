using System;
using System.Windows.Forms;
using SistemasBiblioteca.CapaNegocio;

namespace SistemasBiblioteca.CapaPresentacion
{
    public partial class FormEditoriales : Form
    {
        private CN_Editoriales objetoCN = new CN_Editoriales();
        private string idEditorial = null;
        private bool editar = false;

        public FormEditoriales()
        {
            InitializeComponent();
        }

        private void FormEditoriales_Load(object sender, EventArgs e)
        {
            MostrarEditoriales();
        }

        private void MostrarEditoriales()
        {
            dgvEditoriales.DataSource = objetoCN.MostrarEditoriales();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!editar)
                {
                    objetoCN.InsertarEditorial(txtNombre.Text);
                    MessageBox.Show("Editorial registrada correctamente.");
                }
                else
                {
                    objetoCN.EditarEditorial(idEditorial, txtNombre.Text);
                    MessageBox.Show("Editorial editada correctamente.");
                    editar = false;
                }
                MostrarEditoriales();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEditoriales.SelectedRows.Count > 0)
            {
                editar = true;
                txtNombre.Text = dgvEditoriales.CurrentRow.Cells["Nombre"].Value.ToString();
                idEditorial = dgvEditoriales.CurrentRow.Cells["IdEditorial"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para editar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEditoriales.SelectedRows.Count > 0)
            {
                idEditorial = dgvEditoriales.CurrentRow.Cells["IdEditorial"].Value.ToString();
                objetoCN.EliminarEditorial(idEditorial);
                MessageBox.Show("Editorial eliminada exitosamente.");
                MostrarEditoriales();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar.");
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}