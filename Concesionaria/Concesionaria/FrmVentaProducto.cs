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
    public partial class FrmVentaProducto : FrmBase 
    {
        DataTable Tabla;
        public FrmVentaProducto()
        {
            InitializeComponent();
        }

        private void FrmVentaProducto_Load(object sender, EventArgs e)
        {
            IniicalizarTabla();
        }

        private void CargarProductoxCodigo()
        {
            Int32 CodProducto = Convert.ToInt32(Principal.CodProducto);
            cProducto prod = new Clases.cProducto();
            DataTable trdo = prod.GetProductoxCodigo(CodProducto);
            if (trdo.Rows.Count > 0)
            {
                txtCodigoProducto.Text = trdo.Rows[0]["Codigo"].ToString();
                txtCodProducto.Text = trdo.Rows[0]["CodProducto"].ToString();
                txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
            }
        }

        private void btnAbrirVenta_Click(object sender, EventArgs e)
        {
            FrmBuscarProducto frm = new Concesionaria.FrmBuscarProducto();
            frm.FormClosing += new FormClosingEventHandler(ContinuarProducto);
            frm.Show();
        }

        private void ContinuarProducto(object sender, FormClosingEventArgs e)
        {
            CargarProductoxCodigo();
        }

        private void IniicalizarTabla()
        {
            cFunciones fun = new Clases.cFunciones();
            string col = "CodProducto;Codigo;Nombre;Cantidad;Precio;Subtotal";
            Tabla = fun.CrearTabla(col);
        }

        private void btnAgregarFinanciacion_Click(object sender, EventArgs e)
        {
            if (Validar() == false)
            {
                return;
            }
            cFunciones fun = new cFunciones();
            string CodProducto = txtCodProducto.Text;
            string Codigo = txtCodigoProducto.Text;
            string Nombre = txtNombre.Text;
            string Cantidad = txtCantidad.Text;
            string Precio = txtPrecio.Text;
            string Subtotal = (Convert.ToDouble(Cantidad) * Convert.ToDouble(Precio)).ToString();

            Precio = fun.FormatoEnteroMiles(Precio);
            Subtotal = fun.FormatoEnteroMiles(Subtotal);

            string Val = "";
            Val = CodProducto + ";" + Codigo;
            Val = Val + ";" + Nombre;
            Val = Val + ";" + Cantidad;
            Val = Val + ";" + Precio;
            Val = Val + ";" + Subtotal;
            Tabla = fun.AgregarFilas(Tabla, Val);

            Grilla.DataSource = Tabla;
            txtCodProducto.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            txtNombre.Text = "";
            txtCodigoProducto.Text = "";
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            cFunciones fun = new cFunciones();
            Double total = 0;
            total = fun.TotalizarColumna(Tabla, "Subtotal");
            txtTotal.Text = fun.FormatoEnteroMiles(total.ToString());
        }

        private Boolean Validar()
        {
            if (txtCodProducto.Text == "")
            {
                MessageBox.Show("Debe seleccionar un producto ");
                return false;
            }

            if (txtCantidad.Text == "")
            {
                MessageBox.Show("Debe ingresar una cantidad ");
                return false;
            }

            if (txtPrecio.Text == "")
            {
                MessageBox.Show("Debe ingresar un precio ");
                return false;
            }
            return true;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmBuscadorCliente frm = new FrmBuscadorCliente();
            frm.FormClosing += new FormClosingEventHandler(FrmBuscarCliente);
            frm.Show();
        }

        private void FrmBuscarCliente(object sender, FormClosingEventArgs e)
        {
            Int32 CodCliente = Convert.ToInt32(Principal.CodigoPrincipalAbm);
            BuscarClientexCodigo(CodCliente);          
        }

        private void BuscarClientexCodigo(Int32 CodCliente)
        {
            string Cliente = "";
            cCliente cli = new Clases.cCliente();
            DataTable trdo = cli.GetClientesxCodigo(CodCliente);
            if (trdo.Rows.Count >0)
            {
                Cliente = trdo.Rows[0]["Nombre"].ToString();
                Cliente = Cliente + " " + trdo.Rows[0]["Apellido"].ToString();
                txtCliente.Text = Cliente;
                txtCodCliente.Text = CodCliente.ToString();
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarVenta ()==false)
            {
                return;
            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = Clases.cConexion.Cadenacon();
            con.Open();
            SqlTransaction Transaccion;
            Transaccion = con.BeginTransaction();
            Int32 CodCompra = 0;
            cVentaProducto Venta = new cVentaProducto();
            try
            {
                CodCompra = GrabarVenta(con, Transaccion);
              //  GrabarDetalle(con, Transaccion, CodCompra);
                Transaccion.Commit();
                con.Close();
                MessageBox.Show("Datos grabados correctamente", Clases.cMensaje.Mensaje());
            //    LimpiarTodos();
            }
            catch (Exception ex)
            {
                string msj = "Hubo un error en el proceso " + ex.Message.ToString();
                MessageBox.Show(msj, Clases.cMensaje.Mensaje());
                Transaccion.Rollback();
                con.Close();
                MessageBox.Show(msj);
            }
        }

        private Int32 GrabarVenta(SqlConnection con, SqlTransaction Transaccion)
        {
            cProducto prod = new cProducto();
            cFunciones fun = new Clases.cFunciones();
            DateTime Fecha = dpFecha.Value;
            Double Total = 0;
            Int32? CodCliente = null;

            if (txtCodCliente.Text != "")
                CodCliente = Convert.ToInt32(txtCodCliente.Text);
           
           
            Total = fun.ToDouble(txtTotal.Text);

            cVentaProducto venta = new cVentaProducto();
            Int32 CodVenta = 0;
            CodVenta = venta.Insertar(con, Transaccion, Fecha,CodCliente  , Total);
            return CodVenta;
        }

        private Boolean ValidarVenta ()
        {
            Boolean op = true;
            if (txtCodCliente.Text =="")
            {
                MessageBox.Show("Debe seleccionar un cliente ");
                return false;
            }

            if (Grilla.Rows.Count ==0)
            {
                MessageBox.Show("Debe ingresar un producto  ");
                return false;
            }
            return op;
        }
    }
}
