using System;
using System.Data;
using System.Windows.Forms;
using SistemasBiblioteca.CapaNegocio;

namespace SistemasBiblioteca.CapaPresentacion
{
    public partial class FormReportes : Form
    {
        private CN_Reportes objReportes = new CN_Reportes();
        private CN_Prestamos objPrestamos = new CN_Prestamos(); 

        public FormReportes()
        {
            InitializeComponent();
        }

        private void FormReportes_Load(object sender, EventArgs e)
        {
            CargarEstadisticas();
            CargarHistorial();
        }

        private void CargarEstadisticas()
        {
            try
            {
                DataTable dt = objReportes.ObtenerEstadisticas();
                if (dt.Rows.Count > 0)
                {
                    // Asignamos los resultados de la base de datos a los Labels de la pantalla
                    lblTotalUsuarios.Text = "Total de Usuarios: " + dt.Rows[0]["TotalUsuarios"].ToString();
                    lblTotalTitulos.Text = "Títulos Registrados: " + dt.Rows[0]["TotalTitulos"].ToString();
                    lblDisponibles.Text = "Libros en Inventario: " + dt.Rows[0]["LibrosDisponibles"].ToString();
                    lblPrestamosActivos.Text = "Préstamos Activos: " + dt.Rows[0]["PrestamosActivos"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estadísticas: " + ex.Message);
            }
        }

        private void CargarHistorial()
        {
            try
            {
                
                dgvHistorial.DataSource = objPrestamos.MostrarPrestamos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el historial: " + ex.Message);
            }
        }
    }
}