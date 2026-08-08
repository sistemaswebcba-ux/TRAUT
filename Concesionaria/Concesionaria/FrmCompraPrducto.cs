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
    public partial class FrmCompraPrducto : FrmBase
    {
        DataTable Tabla;
        public FrmCompraPrducto()
        {
            InitializeComponent();
        }

        private void CargarProveedores()
        {
            cFunciones fun = new Clases.cFunciones();
            fun.LlenarCombo(cmbProveedor, "ProveedorAccesorio", "Nombre", "CodProveedor");
        }

        private void FrmCompraPrducto_Load(object sender, EventArgs e)
        {
            CargarProveedores();
            IniicalizarTabla();
            if (Principal.Codigo != null)
                Buscar(Convert.ToInt32 (Principal.Codigo));
        }

        private void IniicalizarTabla()
        {
            cFunciones fun = new Clases.cFunciones();
            string col = "CodProducto;Codigo;Nombre;Cantidad;Precio;Subtotal";
            Tabla = fun.CrearTabla(col);
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

        private void btnAgregarFinanciacion_Click(object sender, EventArgs e)
        {
            if (Validar()==false)
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
            if (txtCodProducto.Text =="")
            {
                MessageBox.Show("Debe seleccionar un producto ");
                return false;
            }

            if (txtCantidad.Text  == "")
            {
                MessageBox.Show("Debe ingresar una cantidad ");
                return false;
            }

            if (txtPrecio.Text =="")
            {
                MessageBox.Show("Debe ingresar un precio ");
                return false;
            }
            return true;
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            Principal.CodProducto = -1;
            FrmAbmProducto frm = new FrmAbmProducto();
            frm.FormClosing += new FormClosingEventHandler(ContinuarAltaPoducto);
            frm.Show();
        }

        private void ContinuarAltaPoducto(object sender, FormClosingEventArgs e)
        {
            CargarProductoxCodigo();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Clases.cConexion.Cadenacon();
            con.Open();
            SqlTransaction Transaccion;
            Transaccion = con.BeginTransaction();
            Int32 CodCompra = 0;
            cCompraProducto compra = new cCompraProducto();
            try
            {
                CodCompra = GrabarCompra(con, Transaccion);
                GrabarDetalle(con, Transaccion, CodCompra);
                Transaccion.Commit();
                con.Close();
                MessageBox.Show("Datos grabados correctamente", Clases.cMensaje.Mensaje());
                LimpiarTodos();
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

        private void LimpiarTodos ()
        {
            Tabla.Rows.Clear();
            Grilla.DataSource = Tabla;
            txtTotal.Text = "";

        }

        private Int32 GrabarCompra (SqlConnection con, SqlTransaction Transaccion)
        {
            cProducto prod = new cProducto();
            cFunciones fun = new Clases.cFunciones();
            DateTime Fecha = dpFecha.Value;
            Double Total = 0;
            Int32? CodProvedor = null;
            string Numero = "";
            Total = fun.ToDouble(txtTotal.Text);
            if (cmbProveedor.SelectedIndex > 0)
                CodProvedor = Convert.ToInt32(cmbProveedor.SelectedValue);

            cCompraProducto compra = new Clases.cCompraProducto();
            Int32 CodCompra = 0;
            CodCompra = compra.Insertar(con, Transaccion, Fecha, Numero, CodProvedor, Total);
            return CodCompra;
        }

        private void GrabarDetalle(SqlConnection con, SqlTransaction Transaccion, Int32 CodCompra)
        {
            cProducto Prod = new Clases.cProducto();
            cFunciones fun = new cFunciones();
            int Cantidad = 0;
            int CodProducto = 0;
            Double Precio = 0;
            Double Subtotal = 0;
            cCompraProducto compra = new cCompraProducto();
            for (int i = 0; i < Tabla.Rows.Count; i++)
            {
                CodProducto = Convert.ToInt32(Tabla.Rows[i]["CodProducto"].ToString());
                Cantidad = Convert.ToInt32(Tabla.Rows[i]["Cantidad"].ToString());
                Precio = fun.ToDouble(Tabla.Rows[i]["Precio"].ToString());
                Subtotal = fun.ToDouble(Tabla.Rows[i]["Subtotal"].ToString());
                compra.InsertarDetalle(con, Transaccion, CodCompra, CodProducto, Cantidad, Precio, Subtotal);
                Prod.ActualizarStock(con, Transaccion, CodProducto, Cantidad);
            }
        }

        private void Buscar(Int32 CodCompra)
        {
            cFunciones fun = new cFunciones();
            cCompraProducto compra = new cCompraProducto();
            DataTable trdo = compra.GetComrpaxCodigo(CodCompra);
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["CodProveedor"].ToString()!="")
                {
                    Int32 CodProveedor = Convert.ToInt32(trdo.Rows[0]["CodProveedor"].ToString());
                    cmbProveedor.SelectedValue = CodProveedor.ToString();
                }
                txtNumero.Text = trdo.Rows[0]["Numero"].ToString();
                txtTotal.Text = trdo.Rows[0]["Total"].ToString().Replace(",", ".");
                string[] vec = txtTotal.Text.Split('.');
                txtTotal.Text = fun.FormatoEnteroMiles(vec[0]);               
                DateTime Fecha = Convert.ToDateTime(trdo.Rows[0]["Fecha"].ToString());
                dpFecha.Value = Fecha;
            }
            BuscarDetalleCompra(CodCompra);
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void BuscarDetalleCompra (Int32 CodCompra)
        {
            cFunciones fun = new cFunciones();
            cCompraProducto compra = new cCompraProducto();
            DataTable trdo = compra.GetDetalleCompra(CodCompra);
            trdo = fun.TablaaMiles(trdo, "Precio");
            trdo = fun.TablaaMiles(trdo, "Subtotal");
            Grilla.DataSource = trdo;
        }
    }
}
