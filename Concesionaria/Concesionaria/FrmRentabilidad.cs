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
    public partial class FrmRentabilidad : FrmBase
    {
        public FrmRentabilidad()
        {
            InitializeComponent();
        }

        private void FrmRentabilidad_Load(object sender, EventArgs e)
        {
            InicializarFecha();
            Buscar();
        }

        private void InicializarFecha()
        {
            DateTime Hoy = DateTime.Now;
            dpFechaHasta.Value = Hoy;
            dpFechaDesde.Value = Hoy.AddMonths(-1);
            cFunciones fun = new cFunciones();
            fun.LlenarCombo(cmbMarca, "Marca", "Nombre", "CodMarca");
        }

        private void Buscar()
        {
            string PatenteBuscar = "";
            string cliente = "";
            Int32? CodMarcaBuscar = null;

            if (txtNombre.Text !="")
                cliente = txtNombre.Text;
            if (txtPatente.Text != "")
                PatenteBuscar = txtPatente.Text;
            if (cmbMarca.SelectedIndex > 0)
                CodMarcaBuscar = Convert.ToInt32(cmbMarca.SelectedValue);
            cFunciones fun = new cFunciones();
            string Col = "Nombre;Patente;Marca;Venta;Gasto;Rentabilidad";
            string Val = "";
            DataTable tbRenta;
            tbRenta = fun.CrearTabla(Col);
            DateTime Desde = dpFechaDesde.Value;
            DateTime Hasta = dpFechaHasta.Value;
            cVenta venta = new cVenta();
            DataTable trdo = venta.GetVentaRentabilidadxFecha(Desde, Hasta, PatenteBuscar , cliente, cliente,CodMarcaBuscar, "", 1);
         //   trdo = fun.TablaaMiles(trdo, "Ganancia");
            string Apellido = "";
            string Nombre = "";
            string NomApe = "";
            string Patente = "";
            string Marca = "";
            Double  Ganancia = 0;
            Int32 CodVenta = 0;
            Double GananciaGastos = 0;
            Double Rentabilidad = 0;
            cGastosPagar gastos = new cGastosPagar();
          

            for (int i = 0; i < trdo.Rows.Count ; i++)
            {
                CodVenta = Convert.ToInt32(trdo.Rows[i]["CodVenta"].ToString());
                Apellido = trdo.Rows[i]["Apellido"].ToString();
                Nombre = trdo.Rows[i]["Nombre"].ToString();
                Patente = trdo.Rows[i]["Patente"].ToString();
                Marca = trdo.Rows[i]["Marca"].ToString();
                Ganancia = Convert.ToDouble(trdo.Rows[i]["GananciaBruta"].ToString());
                NomApe = Nombre + " " + Apellido;
                GananciaGastos = gastos.GetGastosPagarRealizadosxCodVenta(CodVenta);
                Rentabilidad = Ganancia + GananciaGastos;
                Val = NomApe + ";" + Patente + ";" + Marca +";" + Ganancia + ";" + GananciaGastos.ToString() + ";" + Rentabilidad.ToString();
                tbRenta = fun.AgregarFilas(tbRenta, Val);
            }
          
            tbRenta = fun.TablaaMiles(tbRenta, "Venta");
            tbRenta = fun.TablaaMiles(tbRenta, "Gasto");
            tbRenta = fun.TablaaMiles(tbRenta, "Rentabilidad");
            Grilla.DataSource = tbRenta;
            Double TotalVentas = 0;
            Double TotalGastos = 0;
            Double TotalRentabilidad = 0;
            txtCantidad.Text = tbRenta.Rows.Count.ToString();

            TotalVentas = fun.TotalizarColumna(tbRenta, "Venta");
            txtTotalVentas.Text =fun.SepararDecimales (TotalVentas.ToString());
            TotalGastos = fun.TotalizarColumna(tbRenta, "Gasto");
            txtTotalGastos.Text =fun.SepararDecimales (TotalGastos.ToString());
            TotalRentabilidad = fun.TotalizarColumna(tbRenta, "Rentabilidad");
            txtTotalRentabilidad.Text = fun.SepararDecimales(TotalRentabilidad.ToString());
            fun.AnchoColumnas(Grilla, "30;20;20;10;10;10");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        public Double GetGastoxCodVenta(Int32 CodVenta)
        {
            cGastosPagar gasto = new cGastosPagar();
            Double ImportePagado = 0;
            Double Importe = 0;
            Double Ganacia = 0;
            int b = 0;
            DataTable trdo = gasto.GetGastosPagarxCodVenta(CodVenta);
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["Importe"].ToString()!="")
                {
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
                    if (trdo.Rows[0]["ImportePagado"].ToString() != "")
                    {
                        b = 1;
                        ImportePagado = Convert.ToDouble(trdo.Rows[0]["ImportePagado"].ToString());
                    }
                    else
                    {
                        b = 0;
                    }
                    if (b ==1)
                    {
                        Ganacia = Importe - ImportePagado;
                    }
                    else
                    {
                        Ganacia = 0;
                    }
                    
                }         
            }
            return Ganacia;
        }

    }
}
