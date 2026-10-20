using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Concesionaria.Clases;

namespace Concesionaria
{
    public partial class FrmDeudaAgrupada : FrmBase
    {
        public FrmDeudaAgrupada()
        {
            InitializeComponent();
        }

        private void FrmDeudaAgrupada_Load(object sender, EventArgs e)
        {
            BuscarDeuda();
        }

        private void BuscarDeuda( )
        {
            DateTime FechaaDesde = dpFechaDesde.Value;
            DateTime FechaHasta = dpFechaHasta.Value;
            cDeudaProveedor deuda = new Clases.cDeudaProveedor();
            DataTable trdo = deuda.GetDeudaResumida(FechaaDesde, FechaHasta);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarDeuda();
        }
    }
}
