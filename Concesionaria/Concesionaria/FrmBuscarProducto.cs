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
    public partial class FrmBuscarProducto : FrmBase
    {
        public FrmBuscarProducto()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string Codigo = "";
            string Nombre = "";
            if (txtCodigoProducto.Text != "")
                Codigo = txtCodigoProducto.Text;
            if (txtNombre.Text != "")
                Nombre = txtNombre.Text;
            cProducto prod = new Clases.cProducto();
            DataTable trdo = prod.GetProducto(Codigo, Nombre);
            Grilla.DataSource = trdo;                 
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null )
            {
                MessageBox.Show("Debe seleccionar un elemento ");
                return;
            }

            Principal.CodProducto = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value.ToString());
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Principal.CodProducto = null;
            this.Close();
        }
    }
}
