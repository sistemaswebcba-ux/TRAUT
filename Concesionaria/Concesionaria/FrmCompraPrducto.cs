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
        }

        private void btnAbrirVenta_Click(object sender, EventArgs e)
        {
            FrmBuscarProducto frm = new Concesionaria.FrmBuscarProducto();
            frm.Show();
        }
    }
}
