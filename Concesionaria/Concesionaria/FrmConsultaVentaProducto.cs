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
        int Ocular;
        public FrmConsultaVentaProducto()
        {
            InitializeComponent();
        }

        private void Buscar()
        {
            cVentaProducto venta = new Clases.cVentaProducto();
            cFunciones fun = new cFunciones();
            string Col = "";
            DateTime FechaDesde = dpFechaDesde.Value;
            DateTime FechaHasta = dpFechaHasta.Value;
            string Cliente = "";
            if (txtCliente.Text != "")
                Cliente = txtCliente.Text;
            DataTable trdo = venta.GetVentaProducto(FechaDesde, FechaHasta, Cliente);
            trdo = fun.TablaaMiles(trdo, "Total");
            trdo = fun.TablaaFechas(trdo, "Fecha");
            trdo = fun.TablaaMiles(trdo, "Costo");
            trdo = fun.TablaaMiles(trdo, "Rentabilidad");
            Grilla.DataSource = trdo;
            if (Ocular ==1)
            {
                Col = "0;60;20;20;0;0";
                Ocular = 0;
                lblRentabilidad.Visible = false;
                txtRentabilidad.Visible = false;
            }
            else
            {
                lblRentabilidad.Visible = true;
                txtRentabilidad.Visible = true;
                Col = "0;40;15;15;15;15";
                Ocular = 1;
                Grilla.Columns[4].Visible = true;
                Grilla.Columns[5].Visible = true;
            }
           
            fun.AnchoColumnas(Grilla, Col);
            Double Total = fun.TotalizarColumna(trdo, "Total");
            Double Rentabilidad = fun.TotalizarColumna(trdo, "Rentabilidad");
            txtTotal.Text = fun.SepararDecimales(Total.ToString());
            txtRentabilidad.Text = fun.SepararDecimales(Rentabilidad.ToString()); 
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void FrmConsultaVentaProducto_Load(object sender, EventArgs e)
        {
            Ocular = 1;
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

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un registro");
                return;
            }

            Int32 COdVenta = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            Principal.Codigo = COdVenta;
            FrmVentaProducto frm = new FrmVentaProducto();
            frm.FormClosing += new FormClosingEventHandler(Continuar);
            frm.ShowDialog();
        }

        private void Continuar(object sender, FormClosingEventArgs e)
        {
            Buscar();
        }

        private void BtnVerGanancia_Click(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}
