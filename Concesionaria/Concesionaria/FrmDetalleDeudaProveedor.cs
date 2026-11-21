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
    public partial class FrmDetalleDeudaProveedor : FrmBase 
    {
        public FrmDetalleDeudaProveedor()
        {
            InitializeComponent();
        }

        private void FrmDetalleDeudaProveedor_Load(object sender, EventArgs e)
        {
            Int32 CodProveedor = Convert.ToInt32(Principal.CodProveedor);
            CargarProveedor(CodProveedor);
            CararCuentasxProveedor(CodProveedor);
        }

        private void Buscar()
        {
            Int32 CodProveedor = Convert.ToInt32(Principal.CodProveedor);
            CargarProveedor(CodProveedor);
            CararCuentasxProveedor(CodProveedor);
        }

        private void CararCuentasxProveedor(Int32 CodProveedor)
        {
            cCuentaProveedor cuenta = new Clases.cCuentaProveedor();
            DataTable trdo = cuenta.GetCuentas(CodProveedor);
            cFunciones fun = new Clases.cFunciones();
            fun.LlenarComboDatatable(cmbCuenta, trdo, "Nombre", "CodCuenta");
        }

        private void CargarProveedor(Int32 CodProveedor)
        {
            cProveedor Prov = new cProveedor();
            DataTable tbProv = Prov.GetProveedor(CodProveedor);
            if (tbProv.Rows.Count >0)
            {
                txtProveedor.Text = tbProv.Rows[0]["Nombre"].ToString(); 
            }

            Int32? CodCuenta = null;
            if (cmbCuenta.SelectedIndex > 0)
                CodCuenta = Convert.ToInt32(cmbCuenta.SelectedValue);

            cFunciones fun = new cFunciones();
            cDeudaProveedor Deuda = new Clases.cDeudaProveedor();
            DataTable trdo = Deuda.GetDeudaxCodProveedor(CodProveedor,CodCuenta);
            Double Total = fun.TotalizarColumna(trdo, "Saldo");
            txtTotal.Text = fun.SepararDecimales(Total.ToString());
            trdo = fun.TablaaMiles(trdo, "Importe");
            trdo = fun.TablaaMiles(trdo, "Saldo");
            Grilla.DataSource = trdo;
            Grilla.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft ;
            Grilla.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grilla.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grilla.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grilla.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopRight ;

            Grilla.Columns[0].HeaderText = "Pagar";
            fun.AnchoColumnas(Grilla, "8;0;20;42;15;15");
        }

        private void btnBuscarCompra_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            Principal.CodOrden = null;
            int i = 0, b = 0;  
            int Filas = Grilla.Rows.Count;
            string Deudas = "";
            Int32 CodDeuda = 0;
            foreach (DataGridViewRow r in Grilla.Rows)
            {
                if (i < Filas)
                {
                    if (Convert.ToBoolean(r.Cells["Pagar"].Value) == true)
                    {
                        CodDeuda = Convert.ToInt32(r.Cells[1].Value.ToString());
                        if (b == 0)
                        {
                            Deudas = "(" + CodDeuda.ToString();
                            b = 1;
                        }
                        else
                        {
                            Deudas = Deudas + "," + CodDeuda.ToString();
                        }
                            
                    }
                }
                i++;
            }

            if (b ==0)
            {
                MessageBox.Show("Debe seleccionar los registros a pagar ");
            }
            else
            {
                Deudas = Deudas + ")";
                Principal.ListadoDeuda = Deudas;
                FrmOrdenPago frm = new Concesionaria.FrmOrdenPago();
                frm.FormClosing += new FormClosingEventHandler(form_FormClosing);
                frm.ShowDialog();
            }
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Buscar();
        }
    }
}
