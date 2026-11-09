using System;
using System.Data;
using SistemasBiblioteca.CapaDatos;

namespace SistemasBiblioteca.CapaNegocio
{
    public class CN_Reportes
    {
        private CD_Reportes objetoCD = new CD_Reportes();

        public DataTable ObtenerEstadisticas()
        {
            return objetoCD.ResumenEstadisticas();
        }
    }
}