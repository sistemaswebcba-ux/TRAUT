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
            int Obligatorio = 0;
            if (chkObligatorio.Checked == true)
                Obligatorio = 1;
            string Proveedor = "";
            string Concepto = "";
            string Cuenta = "";
            if (txtProveedor.Text != "")
                Proveedor = txtProveedor.Text;
            if (txtConcepto.Text != "")
                Concepto = txtConcepto.Text;
            if (txtCuenta.Text != "")
                Cuenta = txtCuenta.Text;
            Double Total = 0;
            Double Saldo = 0;
            DataTable trdo = deuda.GetDeudaDiarias(dpFechaDesde.Value, dpFechaHasta.Value, Proveedor, Concepto, Obligatorio,Cuenta);
            Total = fun.TotalizarColumna(trdo, "Importe");
            Saldo = fun.TotalizarColumna(trdo, "Saldo");
            trdo = fun.TablaaMiles(trdo, "Importe");
            trdo = fun.TablaaMiles(trdo, "Saldo");
            trdo = fun.TablaaFechas(trdo, "FechaVto");
            Grilla.DataSource = trdo;
            string col = "0;15;20;20;15;15;15;0;0";
            fun.AnchoColumnas(Grilla, col);
            Grilla.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grilla.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            txtTotalDeuda.Text = fun.SepararDecimales(Total.ToString());
            txtTotalSaldo.Text = fun.SepararDecimales(Saldo.ToString());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (Grilla.Rows.Count <1)
            {
                MessageBox.Show("No hay registros ");
                return;
            }
            cReporte reporte = new cReporte();
            reporte.Borrar();
            string FechaVto = "";
            string Proveedor = "";
            string Cuenta = "";
            string COncepto = "";
            string Importe = "";
            string Saldo = "";
            int Orden = 1;
            string Fecha ="Fecha: " + DateTime.Now.ToShortDateString();
            for (int i = 0; i < Grilla.Rows.Count -1; i++)
            {
                FechaVto = Grilla.Rows[i].Cells[1].Value.ToString();
                Proveedor = Grilla.Rows[i].Cells[2].Value.ToString();
                Cuenta = Grilla.Rows[i].Cells[3].Value.ToString();
                COncepto = Grilla.Rows[i].Cells[4].Value.ToString();
                Importe = Grilla.Rows[i].Cells[5].Value.ToString();
                Saldo = Grilla.Rows[i].Cells[6].Value.ToString();
                reporte.Insertar(Orden, FechaVto, Proveedor, Cuenta, COncepto, Importe, Saldo, Fecha, "", "", "", "", "", "", "");
                Orden = Orden + 1;
            }

            FrmReporteVencimientos frm = new FrmReporteVencimientos();
            frm.Show();
        }
    }
}
