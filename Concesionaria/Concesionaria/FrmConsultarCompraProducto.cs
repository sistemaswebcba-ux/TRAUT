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
    public partial class FrmConsultarCompraProducto : FrmBase
    {
        public FrmConsultarCompraProducto()
        {
            InitializeComponent();
        }

        private void FrmConsultarCompraProducto_Load(object sender, EventArgs e)
        {
            InicializarFechas();
            Buscar();
        }

        private void InicializarFechas()
        {
            DateTime Fecha = DateTime.Now;
            int dia = Fecha.Day;
            int Mes = Fecha.Month;
            Fecha = Fecha.AddDays(-dia);
            Fecha = Fecha.AddDays(1);
            dpFechaDesde.Value = Fecha;
            Fecha = Fecha.AddMonths(1);
            Fecha = Fecha.AddDays(-1);
            dpFechaHasta.Value = Fecha;
        }

        private void Buscar()
        {
            cFunciones fun = new cFunciones();
            cCompraProducto compra = new Clases.cCompraProducto();
            DateTime FechaDesde = dpFechaDesde.Value;
            DateTime FechaHasta = dpFechaHasta.Value;
            string Proveedor = "";
            if (txtProveedor.Text != "")
                Proveedor = txtProveedor.Text;
            DataTable trdo = compra.GetCompraProducto(FechaDesde, FechaHasta, Proveedor);
            trdo = fun.TablaaMiles(trdo, "Total");
            Grilla.DataSource = trdo;
            string Col = "0;40;15;15;15;15";
            fun.AnchoColumnas(Grilla, Col);
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un registro ");
                return;
            }

            int CodCompra = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            Principal.Codigo = CodCompra;
            FrmCompraPrducto frm = new FrmCompraPrducto();
            frm.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}
