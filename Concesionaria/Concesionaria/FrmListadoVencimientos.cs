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
    public partial class FrmListadoVencimientos : FrmBase
    {
        public FrmListadoVencimientos()
        {
            InitializeComponent();
        }

        private void FrmListadoVencimientos_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            cFunciones fun = new cFunciones();
            DateTime Hoy = DateTime.Now;
            Hoy = Hoy.AddDays(7);
            cDeudaProveedor Deuda = new cDeudaProveedor();
            DataTable trdo = Deuda.GetVencimientos(Hoy);
            
            trdo = fun.TablaaMiles(trdo, "Importe");
            trdo = fun.TablaaMiles(trdo, "Saldo");
            Grilla.DataSource = trdo;
            string Col = "0;20;20;10;10;10;10;10;10;0";
            fun.AnchoColumnas(Grilla, Col);

            for (int i = 0; i < Grilla.Rows.Count -1; i++)
            {
                if (Grilla.Rows[i].Cells[9].Value.ToString ()=="1")
                {
                    Grilla.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
        }
    }
}
