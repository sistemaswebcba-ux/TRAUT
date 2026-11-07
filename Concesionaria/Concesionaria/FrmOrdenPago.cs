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
    public partial class FrmOrdenPago : FrmBase 
    {
        public FrmOrdenPago()
        {
            InitializeComponent();
        }

        private void FrmOrdenPago_Load(object sender, EventArgs e)
        {
            CargarProveedor(Convert.ToInt32(Principal.CodProveedor));
            CargarDeudas();
        }

        private void CargarProveedor(Int32 CodProveedor)
        {
            cProveedor Prov = new cProveedor();
            DataTable tbProv = Prov.GetProveedor(CodProveedor);
            if (tbProv.Rows.Count > 0)
            {
                txtProveedor.Text = tbProv.Rows[0]["Nombre"].ToString();
            }
        }

        private void CargarDeudas()
        {
            Double Total = 0;
            cFunciones fun = new cFunciones();
            string ListadoDeudas = Principal.ListadoDeuda;
            cDeudaProveedor Deuda = new Clases.cDeudaProveedor();
            DataTable trdo = Deuda.GetDeudasVarias(ListadoDeudas);
            trdo = fun.TablaaMiles(trdo, "Importe");
            trdo = fun.TablaaMiles(trdo, "Saldo");
            Grilla.DataSource = trdo;
            Total = fun.TotalizarColumna(trdo, "Saldo");
            txtTotal.Text = fun.FormatoEnteroMiles(Total.ToString ());
            fun.AnchoColumnas(Grilla, "0;30;40;15;15");
            Grilla.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grilla.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grilla.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grilla.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void btnAbrirCompra_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarCompra_Click(object sender, EventArgs e)
        {

        }
    }
}
