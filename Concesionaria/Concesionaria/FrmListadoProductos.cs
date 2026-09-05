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
            Buscar();
        }

        private void Buscar()
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (Grilla.Rows.Count <1)
            {
                MessageBox.Show("Debe buscar productos ");
                return;
            }
            int Orden = 0;
            string Codigo = "";
            string Nombre = "";
            string Marca = "";
            string Version = "";
            string Estado = "";
            string Stock = "";
            string Costo = "";
            string PrecioVenta = "";
            string Fecha = "Feccha: " + DateTime.Now.ToShortDateString();
            cReporte reporte = new Clases.cReporte();
            reporte.Borrar();
            for (int i = 0; i <Grilla.Rows.Count -1; i++)
            {
                Orden = Orden + 1;
                Codigo = Grilla.Rows[i].Cells[1].Value.ToString();
                Nombre = Grilla.Rows[i].Cells[2].Value.ToString();
                Marca = Grilla.Rows[i].Cells[3].Value.ToString();
                Version = Grilla.Rows[i].Cells[4].Value.ToString();
                Estado = Grilla.Rows[i].Cells[5].Value.ToString();
                Stock = Grilla.Rows[i].Cells[6].Value.ToString();
                Costo  = Grilla.Rows[i].Cells[7].Value.ToString();
                PrecioVenta = Grilla.Rows[i].Cells[8].Value.ToString();
                reporte.Insertar(Orden, Codigo, Nombre, Marca, Version, Estado, Stock, Costo, PrecioVenta,Fecha,"","","","","");
            }

            FrmReporteProductos frm = new FrmReporteProductos();
            frm.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un registro ");
                return;
            }

            int CodProducto = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            Principal.CodProducto = CodProducto;
            FrmActualizarPrecioProducto frm = new FrmActualizarPrecioProducto();
            frm.FormClosing += new FormClosingEventHandler(Continuar);
            frm.ShowDialog();
        }

        private void Continuar(object sender, FormClosingEventArgs e)
        {
            Buscar();
        }
    }
}
