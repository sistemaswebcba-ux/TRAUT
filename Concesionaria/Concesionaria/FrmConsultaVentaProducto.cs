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
    public partial class FrmConsultaVentaProducto : FrmBase
    {
        public FrmConsultaVentaProducto()
        {
            InitializeComponent();
        }

        private void Buscar()
        {
            cVentaProducto venta = new Clases.cVentaProducto();
            cFunciones fun = new cFunciones();
           
            DateTime FechaDesde = dpFechaDesde.Value;
            DateTime FechaHasta = dpFechaHasta.Value;
            string Cliente = "";
            if (txtCliente.Text != "")
                Cliente = txtCliente.Text;
            DataTable trdo = venta.GetVentaProducto(FechaDesde, FechaHasta, Cliente);
            trdo = fun.TablaaMiles(trdo, "Total");
            trdo = fun.TablaaFechas(trdo, "Fecha");
            Grilla.DataSource = trdo;
            string Col = "0;60;20;20";
            fun.AnchoColumnas(Grilla, Col);
            Double Total = fun.TotalizarColumna(trdo, "Total");
            txtTotal.Text = fun.SepararDecimales(Total.ToString());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void FrmConsultaVentaProducto_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un registro");
                return;
            }

            Int32 COdVenta = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            Principal.Codigo = COdVenta;
        }
    }
}
