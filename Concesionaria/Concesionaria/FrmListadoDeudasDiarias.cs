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
    public partial class FrmListadoDeudasDiarias : FrmBase 
    {
        public FrmListadoDeudasDiarias()
        {
            InitializeComponent();
        }

        private void FrmListadoDeudasDiarias_Load(object sender, EventArgs e)
        {
            InicializarFecha();
            Buscar();
        }

        private void InicializarFecha()
        {
            DateTime hoy = DateTime.Now;
            dpFechaDesde.Value = hoy;
            dpFechaHasta.Value = hoy.AddDays(7);
        }

        private void Buscar ()
        {
            cFunciones fun = new cFunciones();
            cDeudaProveedor deuda = new Clases.cDeudaProveedor();
            DataTable trdo = deuda.GetDeudaDiarias(dpFechaDesde.Value, dpFechaHasta.Value, "", "");
            trdo = fun.TablaaMiles(trdo, "Importe");
            trdo = fun.TablaaMiles(trdo, "Saldo");
            Grilla.DataSource = trdo;
            string col = "0;15;20;20;15;15;15;0;0";
            fun.AnchoColumnas(Grilla, col);
            Grilla.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grilla.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}
