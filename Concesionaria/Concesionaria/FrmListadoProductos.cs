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
        private int  Estado ;
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
            trdo = fun.TablaaMiles(trdo, "Costo");
            trdo = fun.TablaaMiles(trdo, "PrecioVenta");
            Grilla.DataSource = trdo;
            string Col = "0;10;20;15;15;10;10;10;10";
            fun.AnchoColumnas(Grilla, Col);
            OcultarColumna();
        }

        private void Buscar()
        {
            cProducto prod = new Clases.cProducto();
        }

        private void FrmListadoProductos_Load(object sender, EventArgs e)
        {
            Estado = 0;
          
        }

        private void OcultarColumna ()
        {
            cFunciones fun = new Clases.cFunciones();
            if (Estado ==1)
            {
                Grilla.Columns[7].Visible = true; 
                string Col = "0;10;20;15;15;10;10;10;10";
                fun.AnchoColumnas(Grilla, Col);
            }

            if (Estado ==0)
            {
                string Col = "0;10;30;15;15;10;10;0;10";
                fun.AnchoColumnas(Grilla, Col);
            }
        }

        private void BtnVerGanancia_Click(object sender, EventArgs e)
        {
            if (Estado ==0)
            {
                Estado = 1;
                OcultarColumna();
            }
            else
            {
                Estado = 0;
                OcultarColumna();
            }
        }
    }
}
