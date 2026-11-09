using System;
using System.Windows.Forms;
using SistemasBiblioteca.CapaNegocio;

namespace SistemasBiblioteca.CapaPresentacion
{
    public partial class FormUsuarios : Form
    {
        private CN_Usuarios objetoCN = new CN_Usuarios();
        private string idUsuario = null;
        private bool editar = false;

        public FormUsuarios()
        {
            InitializeComponent();
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            MostrarUsuarios();
        }

        private void MostrarUsuarios()
        {
            dgvUsuarios.DataSource = objetoCN.MostrarUsuarios();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (editar == false)
                {
                    objetoCN.InsertarUsuario(txtNombre.Text, txtApellido.Text, txtDocumento.Text, txtTelefono.Text, txtCorreo.Text);
                    MessageBox.Show("Se insertó el registro correctamente.");
                    MostrarUsuarios();
                    LimpiarFormulario();
                }
                else
                {
                    objetoCN.EditarUsuario(idUsuario, txtNombre.Text, txtApellido.Text, txtDocumento.Text, txtTelefono.Text, txtCorreo.Text);
                    MessageBox.Show("Se editó el registro correctamente.");
                    MostrarUsuarios();
                    LimpiarFormulario();
                    editar = false;
                }
            }
            catch (Exception ex)
            {
                // Si el usuario deja campos vacíos, el mensaje de error de CN_Usuarios aparecerá aquí
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                editar = true;
                txtNombre.Text = dgvUsuarios.CurrentRow.Cells["Nombre"].Value.ToString();
                txtApellido.Text = dgvUsuarios.CurrentRow.Cells["Apellido"].Value.ToString();
                txtDocumento.Text = dgvUsuarios.CurrentRow.Cells["Documento"].Value.ToString();
                txtTelefono.Text = dgvUsuarios.CurrentRow.Cells["Telefono"].Value.ToString();
                txtCorreo.Text = dgvUsuarios.CurrentRow.Cells["Correo"].Value.ToString();
                idUsuario = dgvUsuarios.CurrentRow.Cells["IdUsuario"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para editar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                idUsuario = dgvUsuarios.CurrentRow.Cells["IdUsuario"].Value.ToString();
                objetoCN.EliminarUsuario(idUsuario);
                MessageBox.Show("Registro eliminado exitosamente.");
                MostrarUsuarios();
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
            txtDocumento.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}