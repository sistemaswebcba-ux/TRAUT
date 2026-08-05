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
            Int32 CodProducto = Convert.ToInt32(Principal.CodProducto);
            cProducto prod = new Clases.cProducto();
            DataTable trdo = prod.GetProductoxCodigo(CodProducto);
            if (trdo.Rows.Count >0)
            {
                txtCodigoProducto.Text = trdo.Rows[0]["Codigo"].ToString();
                txtCodProducto.Text = trdo.Rows[0]["CodProducto"].ToString();
                txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
            }
        }

        private void btnAgregarFinanciacion_Click(object sender, EventArgs e)
        {
            cFunciones fun = new cFunciones();
            string CodProducto = txtCodProducto.Text;
            string Codigo = txtCodigoProducto.Text;
            string Nombre = txtNombre.Text;
            string Cantidad = txtCantidad.Text;
            string Precio = txtPrecio.Text;
            string Subtotal = (Convert.ToDouble(Cantidad) * Convert.ToDouble(Precio)).ToString();
            string Val = "";
            Val = CodProducto + ";" + Codigo;
            Val = Val + ";" + Nombre;
            Val = Val + ";" + Cantidad;
            Val = Val + ";" + Precio;
            Val = Val + ";" + Subtotal;
            Tabla = fun.AgregarFilas(Tabla, Val);
            Grilla.DataSource = Tabla;
            
        }
    }
}
