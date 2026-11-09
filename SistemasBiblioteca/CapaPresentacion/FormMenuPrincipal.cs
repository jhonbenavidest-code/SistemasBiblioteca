using System;
using System.Windows.Forms;

namespace SistemasBiblioteca.CapaPresentacion
{
    public partial class FormMenuPrincipal : Form
    {
        public FormMenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FormUsuarios frm = new FormUsuarios();
            frm.ShowDialog();
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            FormLibros frm = new FormLibros();
            frm.ShowDialog();
        }

        private void btnAutores_Click(object sender, EventArgs e)
        {
            FormAutores frm = new FormAutores();
            frm.ShowDialog();
        }

        private void btnEditoriales_Click(object sender, EventArgs e)
        {
            FormEditoriales frm = new FormEditoriales();
            frm.ShowDialog();
        }

        private void btnPrestamos_Click(object sender, EventArgs e)
        {
            FormPrestamos frm = new FormPrestamos();
            frm.ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            FormReportes frm = new FormReportes();
            frm.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Instanciamos un Autor y un Usuario tratándolos como la clase base 'Persona'
                SistemasBiblioteca.CapaEntidades.Persona persona1 = new SistemasBiblioteca.CapaEntidades.Autor
                {
                    ID = 1,
                    Nombre = "Gabriel",
                    Apellido = "García Márquez"
                };

                SistemasBiblioteca.CapaEntidades.Persona persona2 = new SistemasBiblioteca.CapaEntidades.Usuario
                {
                    ID = 2,
                    Nombre = "Juan Pérez",
                    Documento = "10203040",
                    Correo = "juan@correo.com"
                };

                // 2. Al llamar al mismo método ObtenerResumen(), cada objeto responde diferente gracias al Polimorfismo
                string resultado = "--- PRUEBA DE POLIMORFISMO ---\n\n" +
                                   "Llamando a Persona 1:\n" + persona1.ObtenerResumen() + "\n\n" +
                                   "Llamando a Persona 2:\n" + persona2.ObtenerResumen();

                MessageBox.Show(resultado, "Bonificación - Polimorfismo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Asegúrate de tener las clases Persona, Autor y Usuario con el método ObtenerResumen configurado. Error: " + ex.Message);
            }
        }
    }
}