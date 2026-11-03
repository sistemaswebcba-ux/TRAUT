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
    public partial class FrmResumenProveedor : FrmBase 
    {
        public FrmResumenProveedor()
        {
            InitializeComponent();
        }

        private void FrmResumenProveedor_Load(object sender, EventArgs e)
        {
            DateTime Hoy = DateTime.Now;
            dpFecha.Value = Hoy.AddDays(7);
            Buscar();
        }

        private void Buscar ()
        {
            cFunciones fun = new cFunciones();
            Double Total = 0;
            string Proveedor = "";
            if (txtProveedor.Text != "")
                Proveedor = txtProveedor.Text;
            cDeudaProveedor Deuda = new Clases.cDeudaProveedor();
            DataTable trdo = Deuda.GetResumenDeudaProveedor(dpFecha.Value, Proveedor);
            Total = fun.TotalizarColumna(trdo, "Saldo");
            trdo = fun.TablaaMiles(trdo, "Saldo");
            trdo = fun.TablaaFechas(trdo, "Vto");
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "0;50;25;25");
            Grilla.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grilla.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            txtTotal.Text = fun.SepararDecimales(Total.ToString());
        }

        private void btnBuscarCompra_Click(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}
