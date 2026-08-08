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
    public partial class FrmListadoProductos : FrmBase
    {
        public FrmListadoProductos()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cFunciones fun = new cFunciones();
            string Nombre = "";
            string Version = "";
            if (txtDescripcion.Text != "")
                Nombre = txtDescripcion.Text;
            if (txtVersion.Text != "")
                Version = txtVersion.Text;
            cProducto prod = new cProducto();
            DataTable trdo = prod.GetProductos(Nombre, Version);
            Grilla.DataSource = trdo;
            string Col = "0;10;30;20;20;10;10";
            fun.AnchoColumnas(Grilla, Col);
        }

        private void Buscar()
        {
            cProducto prod = new Clases.cProducto();
        }
    }
}
