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
    public partial class FrmActualizarPrecioProducto : FrmBase
    {
        public FrmActualizarPrecioProducto()
        {
            InitializeComponent();
        }

        private void FrmActualizarPrecioProducto_Load(object sender, EventArgs e)
        {
            CargarEstado();
            CargarMarcas(); 
            Buscar(Convert.ToInt32 (Principal.CodProducto));
        }

        private void CargarEstado()
        {
            cFunciones fun = new Clases.cFunciones();
            DataTable tb = fun.CrearTabla("CodEstado;Nombre");
            string Val = "1;Nuevo";
            tb = fun.AgregarFilas(tb, Val);
            Val = "2;Usado";
            tb = fun.AgregarFilas(tb, Val);
            fun.LlenarComboDatatable(cmbEstado, tb, "Nombre", "CodEstado");
        }

        private void CargarMarcas()
        {
            cFunciones fun = new Clases.cFunciones();
            fun.LlenarCombo(cmbMarca, "MarcaProducto", "Nombre", "CodMarca");
        }

        private void Buscar(Int32 CodProducto)
        {
            cFunciones fun = new cFunciones();
            cProducto prod = new cProducto();
            DataTable trdo = prod.GetProductoxCodigo(CodProducto);
            if (trdo.Rows.Count >0)
            {
                txtCodigo.Text = trdo.Rows[0]["Codigo"].ToString();
                txtCodProducto.Text = trdo.Rows[0]["CodProducto"].ToString();
                txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
                txtStock.Text = trdo.Rows[0]["Stock"].ToString();
                txtCosto.Text = trdo.Rows[0]["Costo"].ToString();
                txtVersion.Text = trdo.Rows[0]["Version"].ToString();
                txtPrecioVenta.Text = trdo.Rows[0]["PrecioVenta"].ToString();
                if (txtCosto.Text !="")
                {
                    txtCosto.Text = fun.SepararDecimales(txtCosto.Text);
                }
                if (txtPrecioVenta.Text !="")
                {
                    txtPrecioVenta.Text = fun.SepararDecimales(txtPrecioVenta.Text);
                }

                if (trdo.Rows[0]["CodEstado"].ToString()!="")
                {
                    cmbEstado.SelectedValue = trdo.Rows[0]["CodEstado"].ToString();
                }
                
                if (trdo.Rows[0]["CodMarca"].ToString() != "")
                {
                    cmbMarca.SelectedValue = trdo.Rows[0]["CodMarca"].ToString();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            cProducto prod = new Clases.cProducto();
            cFunciones fun = new cFunciones();
            Double PrecioVenta = 0;
            Double Costo = 0;
            Int32 CodProducto = Convert.ToInt32(txtCodProducto.Text);
            if (txtPrecioVenta.Text != "")
            {
                PrecioVenta = fun.ToDouble(txtPrecioVenta.Text);
            }

            if (txtCosto.Text != "")
            {
                Costo = fun.ToDouble(txtCosto.Text);
            }

            prod.ActualilzarPrecio(CodProducto, PrecioVenta, Costo);
            MessageBox.Show("Datos actualilados correctamente ");
            this.Close();
        }
    }
}
