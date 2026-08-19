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
    public partial class FrmConsultarCompraProducto : FrmBase
    {
        public FrmConsultarCompraProducto()
        {
            InitializeComponent();
        }

        private void FrmConsultarCompraProducto_Load(object sender, EventArgs e)
        {
            InicializarFechas();
            Buscar();
        }

        private void InicializarFechas()
        {
            DateTime Fecha = DateTime.Now;
            int dia = Fecha.Day;
            int Mes = Fecha.Month;
            Fecha = Fecha.AddDays(-dia);
            Fecha = Fecha.AddDays(1);
            dpFechaDesde.Value = Fecha;
            Fecha = Fecha.AddMonths(1);
            Fecha = Fecha.AddDays(-1);
            dpFechaHasta.Value = Fecha;
        }

        private void Buscar()
        {
            cFunciones fun = new cFunciones();
            cCompraProducto compra = new Clases.cCompraProducto();
            DateTime FechaDesde = dpFechaDesde.Value;
            DateTime FechaHasta = dpFechaHasta.Value;
            string Proveedor = "";
            if (txtProveedor.Text != "")
                Proveedor = txtProveedor.Text;
            DataTable trdo = compra.GetCompraProducto(FechaDesde, FechaHasta, Proveedor);
            trdo = fun.TablaaMiles(trdo, "Total");
            Grilla.DataSource = trdo;
            string Col = "0;40;15;15;15;15";
            fun.AnchoColumnas(Grilla, Col);
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un registro ");
                return;
            }

            int CodCompra = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            Principal.Codigo = CodCompra;
            FrmCompraPrducto frm = new FrmCompraPrducto();
            frm.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if(Grilla.CurrentRow ==null )
            {
                MessageBox.Show("Debe seleccionar un elemento ");
                return; 
            }

            int CodCompra = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            cCompraProducto  compra = new Clases.cCompraProducto();
            DataTable trdo = compra.GetReporteCompra(CodCompra);
            string Fecha = "";
            string FechaFactura = "";
            string Numero = "";
            string CodigoProducto = "";
            string Cantidad = "";
            string Precio = "";
            string Subtotal = "";
            string Proveedor = "";
            string Total = "";
            string Producto = "";
            int Orden = 0;
            cFunciones fun = new cFunciones();
            cReporte reporte = new cReporte();
            
            reporte.Borrar();
            if (trdo.Rows.Count >0)
            {
                for (int i = 0; i < trdo.Rows.Count ; i++)
                {
                    Orden = Orden + 1;
                    Fecha = "Fecha " + trdo.Rows[i]["Fecha"].ToString().Substring(0, 10);
                    if (trdo.Rows[i]["FechaFactura"].ToString() != "")
                    {
                        FechaFactura = "Fecha de Factura " + trdo.Rows[i]["FechaFactura"].ToString().Substring(0, 10);
                    }

                    if (trdo.Rows[i]["Numero"].ToString() != "")
                    {
                        Numero  = "Número " + trdo.Rows[i]["Numero"].ToString();
                    }

                    
                    if (trdo.Rows[i]["Proveedor"].ToString()!="")
                    {
                        Proveedor ="Proveedor " + trdo.Rows[i]["Proveedor"].ToString();
                    }
                    
                    CodigoProducto = trdo.Rows[i]["Codigo"].ToString();
                    Cantidad = trdo.Rows[i]["Cantidad"].ToString();
                    Precio = trdo.Rows[i]["Precio"].ToString();
                  //  Precio = Precio.Replace(",", ".");
                    Precio = fun.SepararDecimales (Precio);
                    Subtotal = trdo.Rows[i]["Subtotal"].ToString();
                    Subtotal = fun.SepararDecimales(Subtotal);
                    Total = trdo.Rows[i]["Total"].ToString();
                    Total = fun.SepararDecimales(Total);
                    Producto = trdo.Rows[i]["Producto"].ToString();
                    reporte.Insertar(Orden, Fecha, FechaFactura, Numero, Proveedor, CodigoProducto, Cantidad, Precio, Subtotal, "",Producto ,"","","","");
                }
                int b = 0;
                for (int i = Orden; i < 10; i++)
                {
                    b = 1;
                    Orden = Orden + 1;
                    if (i==9)
                        reporte.Insertar(Orden, "", "", "", "", "", "", "Total", Total, "", "", "", "","","");
                    else
                        reporte.Insertar(Orden, "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                }
                if (b ==0)
                    reporte.Insertar(Orden, "", "", "", "", "", "", "Total", Total, "", "", "", "", "", "");

                //inserto filas en blanco para el total


                FrmReporteCompraProducto frm = new FrmReporteCompraProducto();
                frm.Show();
            }
        }
    }
}
