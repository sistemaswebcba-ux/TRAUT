using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Concesionaria.Clases;
using System.Data.SqlClient;

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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Double Efectivo = 0, Tranferencia = 0;
            Double Total = 0, TotalEntrega = 0;
            Double Saldo = 0;
            Double SaldoDeuda = 0;
            string Concepto = "";
            cFunciones fun = new cFunciones();
            cPagoProveedor pago = new Clases.cPagoProveedor();
            cDeudaProveedor Deuda = new cDeudaProveedor();
            if (txtEfectivo.Text !="")
            {
                Efectivo = fun.ToDouble(txtEfectivo.Text);
            }
            
            if (txtTranferencia.Text != "")
            {
                Tranferencia = fun.ToDouble(txtTranferencia.Text);
            }

            if (txtTotal.Text !="")
            {
                Total = fun.ToDouble(txtTotal.Text);
            }
            Concepto = "Pago Proveedor " + txtProveedor.Text;
            TotalEntrega = Efectivo + Tranferencia;
            Saldo = Total - TotalEntrega;
            if (Saldo ==0)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Clases.cConexion.Cadenacon();
                con.Open();
                SqlTransaction Transaccion;
                Transaccion = con.BeginTransaction();
                Int32 CodOrden = 0;
                Int32 CodDeuda = 0;
                Int32 CodPago = 0;
                cOrdenPago Orden = new cOrdenPago();
                try
                {
                    //inserto el pago 
                    //averiguar si el pago es solo x una cuenta
                    //de proveedor, ya que si pago dos cuentas distantas
                    CodPago = pago.Insertar(con, Transaccion, dpFecha.Value, Efectivo, Concepto, 0, null, CodCuentaProveedor);
                    //grabo la orden
                    CodOrden = Orden.Insertar(con, Transaccion, dpFecha.Value, Efectivo, Tranferencia, Total);
                    //grabo el detalle 
                    for (int i = 0; i < Grilla.Rows.Count -1; i++)
                    {
                        CodDeuda = Convert.ToInt32(Grilla.Rows[i].Cells[0].Value);
                        Orden.InsertarDetalle(con, Transaccion, CodOrden, CodDeuda);
                        SaldoDeuda = fun.ToDouble(Grilla.Rows[i].Cells[4].Value.ToString());
                        Deuda.ActualizarSaldo(con, Transaccion, CodDeuda, SaldoDeuda, CodPago);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }


        }

        private void txtEfectivo_Leave(object sender, EventArgs e)
        {
            cFunciones fun = new Clases.cFunciones();
            if (txtEfectivo.Text != "")
                txtEfectivo.Text = fun.SepararDecimales(txtEfectivo.Text);

        }

        private void txtTranferencia_Leave(object sender, EventArgs e)
        {   
            cFunciones fun = new Clases.cFunciones();
            if (txtTranferencia.Text != "")
                txtTranferencia.Text = fun.SepararDecimales(txtTranferencia.Text);
        }
    }
}
