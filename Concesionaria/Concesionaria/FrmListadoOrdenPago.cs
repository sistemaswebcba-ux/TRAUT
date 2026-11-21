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
    public partial class FrmListadoOrdenPago : FrmBase
    {
        public FrmListadoOrdenPago()
        {
            InitializeComponent();
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar ()
        {
            cFunciones fun = new cFunciones();
            cOrdenPago Orden = new cOrdenPago();
            DataTable trdo = Orden.GetOrdenesxFecha(dpFechaDesde.Value, dpFechaHasta.Value);
            trdo = fun.TablaaMiles(trdo, "Efectivo");
            trdo = fun.TablaaMiles(trdo, "Tranferencia");
            trdo = fun.TablaaMiles(trdo, "Total");
            Grilla.DataSource = trdo;
            string Col = "0;23;23;12;12;15;15";
            fun.AnchoColumnas(Grilla, Col);
        }

        private void FrmListadoOrdenPago_Load(object sender, EventArgs e)
        {
            DateTime HOy = DateTime.Now;
            dpFechaHasta.Value = HOy;
            HOy = HOy.AddMonths(-1);
            dpFechaDesde.Value = HOy;
            Buscar();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un registro ");
                return;
            }

            Int32 CodOrden = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            Principal.CodOrden = Convert.ToInt32(CodOrden);
            FrmOrdenPago frm = new Concesionaria.FrmOrdenPago();
            frm.Show();
        }
    }
}
