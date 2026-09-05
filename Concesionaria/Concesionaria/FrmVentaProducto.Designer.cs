namespace Concesionaria
{
    partial class FrmVentaProducto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Grupo = new System.Windows.Forms.GroupBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCodCliente = new System.Windows.Forms.TextBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnAnular = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.txtCodigoProducto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnQuitarFinanciacion = new System.Windows.Forms.Button();
            this.btnAgregarFinanciacion = new System.Windows.Forms.Button();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAbrirVenta = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodProducto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dpFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Grupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // Grupo
            // 
            this.Grupo.Controls.Add(this.txtCosto);
            this.Grupo.Controls.Add(this.label10);
            this.Grupo.Controls.Add(this.txtStock);
            this.Grupo.Controls.Add(this.label8);
            this.Grupo.Controls.Add(this.txtCodCliente);
            this.Grupo.Controls.Add(this.btnBuscarCliente);
            this.Grupo.Controls.Add(this.label1);
            this.Grupo.Controls.Add(this.txtCliente);
            this.Grupo.Controls.Add(this.btnAnular);
            this.Grupo.Controls.Add(this.txtTotal);
            this.Grupo.Controls.Add(this.label9);
            this.Grupo.Controls.Add(this.btnCancelar);
            this.Grupo.Controls.Add(this.btnGrabar);
            this.Grupo.Controls.Add(this.txtCodigoProducto);
            this.Grupo.Controls.Add(this.label7);
            this.Grupo.Controls.Add(this.txtPrecio);
            this.Grupo.Controls.Add(this.label6);
            this.Grupo.Controls.Add(this.btnQuitarFinanciacion);
            this.Grupo.Controls.Add(this.btnAgregarFinanciacion);
            this.Grupo.Controls.Add(this.Grilla);
            this.Grupo.Controls.Add(this.txtCantidad);
            this.Grupo.Controls.Add(this.label5);
            this.Grupo.Controls.Add(this.btnAbrirVenta);
            this.Grupo.Controls.Add(this.txtNombre);
            this.Grupo.Controls.Add(this.label4);
            this.Grupo.Controls.Add(this.txtCodProducto);
            this.Grupo.Controls.Add(this.label3);
            this.Grupo.Controls.Add(this.dpFecha);
            this.Grupo.Controls.Add(this.label2);
            this.Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grupo.Location = new System.Drawing.Point(22, 12);
            this.Grupo.Name = "Grupo";
            this.Grupo.Size = new System.Drawing.Size(806, 468);
            this.Grupo.TabIndex = 17;
            this.Grupo.TabStop = false;
            this.Grupo.Text = "Información del Producto";
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(420, 129);
            this.txtStock.Name = "txtStock";
            this.txtStock.ReadOnly = true;
            this.txtStock.Size = new System.Drawing.Size(71, 23);
            this.txtStock.TabIndex = 104;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(371, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 17);
            this.label8.TabIndex = 103;
            this.label8.Text = "Stock";
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtCodCliente.Location = new System.Drawing.Point(207, 1);
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.ReadOnly = true;
            this.txtCodCliente.Size = new System.Drawing.Size(46, 23);
            this.txtCodCliente.TabIndex = 102;
            this.txtCodCliente.Visible = false;
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Image = global::Concesionaria.Properties.Resources.carpeta;
            this.btnBuscarCliente.Location = new System.Drawing.Point(451, 28);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(40, 27);
            this.btnBuscarCliente.TabIndex = 101;
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 100;
            this.label1.Text = "Cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(207, 30);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(238, 23);
            this.txtCliente.TabIndex = 99;
            // 
            // btnAnular
            // 
            this.btnAnular.Location = new System.Drawing.Point(558, 418);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(75, 36);
            this.btnAnular.TabIndex = 98;
            this.btnAnular.Text = "Anular";
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(671, 391);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(124, 23);
            this.txtTotal.TabIndex = 94;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(625, 391);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 17);
            this.label9.TabIndex = 93;
            this.label9.Text = "Total";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(639, 420);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 36);
            this.btnCancelar.TabIndex = 92;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(720, 420);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 36);
            this.btnGrabar.TabIndex = 91;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // txtCodigoProducto
            // 
            this.txtCodigoProducto.Location = new System.Drawing.Point(76, 99);
            this.txtCodigoProducto.Name = "txtCodigoProducto";
            this.txtCodigoProducto.ReadOnly = true;
            this.txtCodigoProducto.Size = new System.Drawing.Size(100, 23);
            this.txtCodigoProducto.TabIndex = 87;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Silver;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(6, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(793, 31);
            this.label7.TabIndex = 86;
            this.label7.Text = "Información Del Producto";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(265, 127);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 23);
            this.txtPrecio.TabIndex = 85;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(180, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 84;
            this.label6.Text = "Precio";
            // 
            // btnQuitarFinanciacion
            // 
            this.btnQuitarFinanciacion.Image = global::Concesionaria.Properties.Resources.cancel;
            this.btnQuitarFinanciacion.Location = new System.Drawing.Point(695, 126);
            this.btnQuitarFinanciacion.Name = "btnQuitarFinanciacion";
            this.btnQuitarFinanciacion.Size = new System.Drawing.Size(40, 27);
            this.btnQuitarFinanciacion.TabIndex = 83;
            this.btnQuitarFinanciacion.UseVisualStyleBackColor = true;
            this.btnQuitarFinanciacion.Click += new System.EventHandler(this.btnQuitarFinanciacion_Click);
            // 
            // btnAgregarFinanciacion
            // 
            this.btnAgregarFinanciacion.Image = global::Concesionaria.Properties.Resources.add;
            this.btnAgregarFinanciacion.Location = new System.Drawing.Point(649, 126);
            this.btnAgregarFinanciacion.Name = "btnAgregarFinanciacion";
            this.btnAgregarFinanciacion.Size = new System.Drawing.Size(40, 27);
            this.btnAgregarFinanciacion.TabIndex = 82;
            this.btnAgregarFinanciacion.UseVisualStyleBackColor = true;
            this.btnAgregarFinanciacion.Click += new System.EventHandler(this.btnAgregarFinanciacion_Click);
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(6, 154);
            this.Grilla.Name = "Grilla";
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(793, 225);
            this.Grilla.TabIndex = 81;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(76, 125);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 23);
            this.txtCantidad.TabIndex = 80;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 79;
            this.label5.Text = "Cantidad";
            // 
            // btnAbrirVenta
            // 
            this.btnAbrirVenta.Image = global::Concesionaria.Properties.Resources.carpeta;
            this.btnAbrirVenta.Location = new System.Drawing.Point(649, 99);
            this.btnAbrirVenta.Name = "btnAbrirVenta";
            this.btnAbrirVenta.Size = new System.Drawing.Size(40, 27);
            this.btnAbrirVenta.TabIndex = 78;
            this.btnAbrirVenta.UseVisualStyleBackColor = true;
            this.btnAbrirVenta.Click += new System.EventHandler(this.btnAbrirVenta_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(265, 99);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(379, 23);
            this.txtNombre.TabIndex = 77;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(176, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 76;
            this.label4.Text = "Descripcion";
            // 
            // txtCodProducto
            // 
            this.txtCodProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtCodProducto.Location = new System.Drawing.Point(729, 99);
            this.txtCodProducto.Name = "txtCodProducto";
            this.txtCodProducto.ReadOnly = true;
            this.txtCodProducto.Size = new System.Drawing.Size(46, 23);
            this.txtCodProducto.TabIndex = 75;
            this.txtCodProducto.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 74;
            this.label3.Text = "Código";
            // 
            // dpFecha
            // 
            this.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFecha.Location = new System.Drawing.Point(59, 28);
            this.dpFecha.Name = "dpFecha";
            this.dpFecha.Size = new System.Drawing.Size(85, 23);
            this.dpFecha.TabIndex = 71;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha";
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(544, 128);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.ReadOnly = true;
            this.txtCosto.Size = new System.Drawing.Size(100, 23);
            this.txtCosto.TabIndex = 106;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(494, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 17);
            this.label10.TabIndex = 105;
            this.label10.Text = "Costo";
            // 
            // FrmVentaProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 492);
            this.Controls.Add(this.Grupo);
            this.Name = "FrmVentaProducto";
            this.Text = "Venta De Productos";
            this.Load += new System.EventHandler(this.FrmVentaProducto_Load);
            this.Grupo.ResumeLayout(false);
            this.Grupo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Grupo;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.TextBox txtCodigoProducto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnQuitarFinanciacion;
        private System.Windows.Forms.Button btnAgregarFinanciacion;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAbrirVenta;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodProducto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dpFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodCliente;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label label10;
    }
}