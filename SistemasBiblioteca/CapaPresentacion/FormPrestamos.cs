using System;
using System.Windows.Forms;
using SistemasBiblioteca.CapaNegocio;

namespace SistemasBiblioteca.CapaPresentacion
{
    public partial class FormPrestamos : Form
    {
        private CN_Prestamos objetoCN = new CN_Prestamos();

        public FormPrestamos()
        {
            InitializeComponent();
        }

        private void FormPrestamos_Load(object sender, EventArgs e)
        {
            MostrarPrestamos();
        }

        private void MostrarPrestamos()
        {
            dgvPrestamos.DataSource = objetoCN.MostrarPrestamos();
        }

        private void btnPrestar_Click(object sender, EventArgs e)
        {
            try
            {
                objetoCN.PrestarLibro(txtIdUsuario.Text, txtIsbn.Text);
                MessageBox.Show("Préstamo registrado correctamente. Las existencias del libro han disminuido.");
                MostrarPrestamos();
                txtIdUsuario.Clear();
                txtIsbn.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el préstamo: " + ex.Message);
            }
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if (dgvPrestamos.SelectedRows.Count > 0)
            {
                // Evitamos que devuelvan un libro que ya está devuelto
                string estado = dgvPrestamos.CurrentRow.Cells["Estado"].Value.ToString();
                if (estado == "Devuelto")
                {
                    MessageBox.Show("Este préstamo ya se encuentra marcado como 'Devuelto'.");
                    return;
                }

                try
                {
                    string idPrestamo = dgvPrestamos.CurrentRow.Cells["IdPrestamo"].Value.ToString();
                    string isbn = dgvPrestamos.CurrentRow.Cells["ISBN"].Value.ToString();

                    objetoCN.DevolverLibro(idPrestamo, isbn);
                    MessageBox.Show("Libro devuelto correctamente. Las existencias han regresado al inventario.");
                    MostrarPrestamos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al devolver el libro: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un préstamo de la tabla para registrar la devolución.");
            }
        }
    }
}