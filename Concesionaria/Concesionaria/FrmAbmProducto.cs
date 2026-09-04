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
    public partial class FrmAbmProducto : FrmBase
    {
        public FrmAbmProducto()
        {
            InitializeComponent();
        }

        private void Botonera(int Jugada)
        {
            switch (Jugada)
            {
                //estado inicial
                case 1:
                    btnNuevo.Enabled = true;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnAceptar.Enabled = false;
                    btnCancelar.Enabled = false;

                    break;
                case 2:
                    btnNuevo.Enabled = false;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = true;
                    btnAceptar.Enabled = true;
                    btnCancelar.Enabled = true;

                    break;
                case 3:
                    //viene del buscador
                    btnNuevo.Enabled = true;
                    btnEditar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnAceptar.Enabled = false;
                    btnCancelar.Enabled = false;
                    break;
            }

        }

        private void FrmAbmProducto_Load(object sender, EventArgs e)
        {
            cFunciones fun = new Clases.cFunciones();
            Botonera(1);
            Grupo.Enabled = false;
            fun.LlenarCombo(cmb_CodMarca, "MarcaProducto", "Nombre", "CodMarca");
            CargarEstado();
            if (Principal.CodProducto ==-1)
            {
                Botonera(2);
                Grupo.Enabled = true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Botonera(2);
            Clases.cFunciones fun = new Clases.cFunciones();
            fun.LimpiarGenerico(this);
            txtCodigo.Text = "";
            Grupo.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Botonera(2);
            Grupo.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txt_Codigo.Text =="")
            {
                MessageBox.Show("Debe ingresar un código ");
                return; 
            }

            if (cmb_CodEstado.SelectedIndex < 1)
            {
                MessageBox.Show("Debe seleccionar un estado  ");
                return;
            }
              
            if (txt_PrecioVenta.Text != "")
            {
                txt_PrecioVenta.Text = txt_PrecioVenta.Text.Replace(".", "");
            }

            if (txt_Costo.Text !="")
            {
                txt_Costo.Text = txt_Costo.Text.Replace(".", "");
            }

            txt_Estado.Text = cmb_CodEstado.Text;
            //antes de guardar busco el producto x codigo y estado
          //  BuscarProductoxCodigo();
            Clases.cFunciones fun = new Clases.cFunciones();
            if (txtCodigo.Text == "")
            {
                fun.GuardarNuevoGenerico(this, "Producto");
                if (Principal.CodProducto ==-1)
                {
                    cProducto pro = new Clases.cProducto();
                    Int32 CodProducto = pro.GetMaxProducto();
                    Principal.CodProducto = CodProducto;
                    this.Close();
                }
                
            }
               
            else
                fun.ModificarGenerico(this, "Producto", "CodProducto", txtCodigo.Text);
            MessageBox.Show("Datos grabados Correctamente", Clases.cMensaje.Mensaje());
            Botonera(1);
            fun.LimpiarGenerico(this);
            txtCodigo.Text = "";
            Grupo.Enabled = false;
        }

        private void BuscarProductoxCodigo()
        {
            cProducto prod = new cProducto();
            string Codigo = txt_Codigo.Text;
            int CodEstado = Convert.ToInt32(cmb_CodEstado.SelectedValue);
            DataTable tb = prod.GetProductoxCodigoEstado(Codigo, CodEstado);
            if (tb.Rows.Count >0)
            {
                if (tb.Rows[0]["CodProducto"].ToString ()!="")
                {
                    txt_Codigo.Text = tb.Rows[0]["CodProducto"].ToString();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            Botonera(1);
            Grupo.Enabled = false;
            fun.LimpiarGenerico(this);
            txtCodigo.Text = "";
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            //nombre de los camposa buscar, se llaman igual que en la base de datos
            Principal.OpcionesdeBusqueda = "Codigo;Nombre;Estado";
            //nombre de la tabla, 
            Principal.TablaPrincipal = "Producto";
            Principal.OpcionesColumnasGrilla = "CodProducto;Codigo; Nombre;Estado";
            Principal.ColumnasVisibles = "0;1";
            Principal.ColumnasAncho = "0;100;380;100";
            FrmBuscadorGenerico form = new FrmBuscadorGenerico();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            //CargarJugador(Convert.ToInt32(PRINCIPAL.CDOGIO_JUGADOR));
            if (Principal.CodigoPrincipalAbm != null)
            {
                if (Principal.CodigoPrincipalAbm != "")
                {
                    Botonera(3);
                    txtCodigo.Text = Principal.CodigoPrincipalAbm.ToString();
                  
                    if (Principal.CodigoPrincipalAbm != "")
                    {
                        
                        fun.CargarControles(this, "Producto", "CodProducto", txtCodigo.Text);
                        if (txt_Costo.Text != "")
                        {
                            txt_Costo.Text = txt_Costo.Text.Replace(",", ".");
                            string[] vec = txt_Costo.Text.Split('.');
                            txt_Costo.Text = fun.FormatoEnteroMiles(vec[0]);
                        }
                         
                        if (txt_PrecioVenta.Text != "")
                        {
                            txt_PrecioVenta.Text = txt_PrecioVenta.Text.Replace(",", ".");
                            string[] vec = txt_PrecioVenta.Text.Split('.');
                            txt_PrecioVenta.Text = fun.FormatoEnteroMiles(vec[0]);
                        }
                    }
                       
                    Grupo.Enabled = false;
                    return;
                }
            }
            
         
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarProvincia2_Click(object sender, EventArgs e)
        {
            Principal.CampoIdSecundario = "CodMarca";
            Principal.CampoNombreSecundario = "Nombre";
            Principal.NombreTablaSecundario = "MarcaProducto";
            Principal.CodigoPrincipalAbm = null;
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(ContinuarMarca);
            form.ShowDialog();
        }

        private void ContinuarMarca(object sender, FormClosingEventArgs e)
        { 
            cFunciones fun = new Clases.cFunciones();
            if (Principal.CampoIdSecundarioGenerado != "")
            { 
                fun.LlenarCombo(cmb_CodMarca, "MarcaProducto", "Nombre", "CodMarca");
                cmb_CodMarca.SelectedValue = Principal.CampoIdSecundarioGenerado;
            }
        }

        private void CargarEstado()
        {
            cFunciones fun = new Clases.cFunciones();
            DataTable tb = fun.CrearTabla("CodEstado;Nombre");
            string Val = "1;Nuevo";
            tb = fun.AgregarFilas(tb, Val);
            Val = "2;Usado";
            tb = fun.AgregarFilas(tb, Val);
            fun.LlenarComboDatatable(cmb_CodEstado, tb, "Nombre", "CodEstado");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            cFunciones fun = new Clases.cFunciones();
            string msj = "Confirma Eliminar el registro ";
            var result = MessageBox.Show(msj, "Información",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return;
            }
            try
            {
                fun.EliminarGenerico("Producto", "CodProducto", txtCodigo.Text);
                MessageBox.Show("Datos Borrados");
                fun.LimpiarGenerico(this);
                Botonera(1);
                Grupo.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede eliminar el registro, tien datos asociados");
            }
        }
    }
}
