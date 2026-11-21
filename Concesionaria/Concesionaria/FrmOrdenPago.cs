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
            
            if (Principal.CodOrden !=null)
            {
                BuscarOrden(Convert.ToInt32 (Principal.CodOrden));
            }
            else
            {
                CargarProveedor(Convert.ToInt32(Principal.CodProveedor));
                CargarDeudas();
            }
           
           
        }

        private void BuscarOrden (Int32 CodOrden)
        {
            cFunciones fun = new cFunciones();
            cOrdenPago Orden = new cOrdenPago();
            DataTable trdo = Orden.GetOrdenxCodigo(CodOrden);
            Double Efectivo = 0;
            Double Tranferencia = 0;
            Double Total = 0;
            if (trdo.Rows.Count >0)
            {
                Efectivo = Convert.ToDouble(trdo.Rows[0]["Efectivo"]);
                Tranferencia = Convert.ToDouble(trdo.Rows[0]["Tranferencia"]);
                Total = Convert.ToDouble(trdo.Rows[0]["Total"]);
                if (Efectivo > 0)
                    txtEfectivo.Text = fun.SepararDecimales(Efectivo.ToString ());
                if (Tranferencia>0)
                    txtTranferencia.Text = fun.SepararDecimales(Tranferencia.ToString());
                if (Total >0)
                    txtTotal.Text = fun.SepararDecimales(Total.ToString());
            }

            DataTable tbDetalle = Orden.GetDetalleOrdenxCodigo(CodOrden);
            Grilla.DataSource = tbDetalle;
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
            cCuentaProveedor Cuenta = new cCuentaProveedor();
            cMovimientoProveedor movProv = new cMovimientoProveedor();
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
                Double ImporteTotalPagado = 0;
                Int32 CodCuentaProveedor = 0;
                Double Importe = 0;
                if (Grilla.Rows.Count > 1)
                    CodCuentaProveedor = GetCodCuentaProveedorxCodDeuda(Convert.ToInt32(Grilla.Rows[0].Cells[0].Value));
                cOrdenPago Orden = new cOrdenPago();
                try
                {
                    //inserto el pago 
                    //averiguar si el pago es solo x una cuenta
                    //de proveedor, ya que si pago dos cuentas distantas
                    ImporteTotalPagado = Efectivo + Tranferencia;
                    CodPago = pago.Insertar(con, Transaccion, dpFecha.Value, ImporteTotalPagado, Concepto, 0, null, CodCuentaProveedor);
                    double SaldoAnterior = Cuenta.GetSaldo(CodCuentaProveedor);
                    Double SaldoCuentaProv = movProv.GetSaldo(CodCuentaProveedor);
                    SaldoCuentaProv = SaldoCuentaProv - ImporteTotalPagado;
                    movProv.InsertarTran(con, Transaccion, CodCuentaProveedor, dpFecha.Value , Concepto, 0, ImporteTotalPagado, SaldoCuentaProv, 0, CodPago, SaldoAnterior);
                    Cuenta.ActuaizarSaldoTran(con, Transaccion, CodCuentaProveedor, SaldoCuentaProv);
                  
                    //Cuenta.ActuaizarSaldoRestandoTran(con, Transaccion, CodCuentaProveedor, -1 * ImporteTotalPagado);
                   
                    CodPago = pago.Insertar(con, Transaccion, dpFecha.Value, Efectivo, Concepto, 0, null, CodCuentaProveedor);
                    //grabo la orden
                    CodOrden = Orden.Insertar(con, Transaccion, dpFecha.Value, Efectivo, Tranferencia, Total, CodCuentaProveedor);
                    //grabo el detalle 
                    for (int i = 0; i < Grilla.Rows.Count -1; i++)
                    {
                        CodDeuda = Convert.ToInt32(Grilla.Rows[i].Cells[0].Value);
                        Importe = fun.ToDouble(Grilla.Rows[i].Cells[3].Value.ToString());
                        Orden.InsertarDetalle(con, Transaccion, CodOrden, CodDeuda,Importe);
                        SaldoDeuda = fun.ToDouble(Grilla.Rows[i].Cells[4].Value.ToString());
                        Deuda.ActualizarSaldo(con, Transaccion, CodDeuda, SaldoDeuda, CodPago);
                    }
                    Transaccion.Commit();
                    con.Close();
                    MessageBox.Show("Datos grabados corectamente");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un error en el proceso de grabacion");
                    MessageBox.Show(ex.Message.ToString()); 
                    Transaccion.Rollback();
                    con.Close();
                   
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

        private Int32 GetCodCuentaProveedorxCodDeuda(Int32 CodDeuda)
        {
            Int32 CodCuentaProveedor = 0;
            cDeudaProveedor Deuda = new Clases.cDeudaProveedor();
            DataTable trdo = Deuda.GetDeudaxCodigo(CodDeuda);
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["CodCuentaProveedor"].ToString ()!="")
                {
                    CodCuentaProveedor = Convert.ToInt32(trdo.Rows[0]["CodCuentaProveedor"].ToString());
                }
            }
            return CodCuentaProveedor;

        }
    }
}
