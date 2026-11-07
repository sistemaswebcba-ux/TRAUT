namespace Concesionaria
{
    partial class FrmResumenProveedor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAbrirCompra = new System.Windows.Forms.Button();
            this.btnBuscarCompra = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtProveedor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dpFecha);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.btnAbrirCompra);
            this.groupBox1.Controls.Add(this.btnBuscarCompra);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Controls.Add(this.Grilla);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(784, 447);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de Resumen Proveedor";
            // 
            // txtProveedor
            // 
            this.txtProveedor.Location = new System.Drawing.Point(278, 27);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(152, 23);
            this.txtProveedor.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(197, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 73;
            this.label1.Text = "Proveedor";
            // 
            // dpFecha
            // 
            this.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFecha.Location = new System.Drawing.Point(104, 28);
            this.dpFecha.Name = "dpFecha";
            this.dpFecha.Size = new System.Drawing.Size(87, 23);
            this.dpFecha.TabIndex = 72;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::Concesionaria.Properties.Resources.cancel;
            this.btnEliminar.Location = new System.Drawing.Point(516, 18);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(34, 30);
            this.btnEliminar.TabIndex = 53;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Visible = false;
            // 
            // btnAbrirCompra
            // 
            this.btnAbrirCompra.Image = global::Concesionaria.Properties.Resources.carpeta;
            this.btnAbrirCompra.Location = new System.Drawing.Point(476, 20);
            this.btnAbrirCompra.Name = "btnAbrirCompra";
            this.btnAbrirCompra.Size = new System.Drawing.Size(34, 30);
            this.btnAbrirCompra.TabIndex = 52;
            this.btnAbrirCompra.UseVisualStyleBackColor = true;
            this.btnAbrirCompra.Click += new System.EventHandler(this.btnAbrirCompra_Click);
            // 
            // btnBuscarCompra
            // 
            this.btnBuscarCompra.Image = global::Concesionaria.Properties.Resources.zoom;
            this.btnBuscarCompra.Location = new System.Drawing.Point(436, 20);
            this.btnBuscarCompra.Name = "btnBuscarCompra";
            this.btnBuscarCompra.Size = new System.Drawing.Size(34, 30);
            this.btnBuscarCompra.TabIndex = 51;
            this.btnBuscarCompra.UseVisualStyleBackColor = true;
            this.btnBuscarCompra.Click += new System.EventHandler(this.btnBuscarCompra_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(619, 414);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 47;
            this.label4.Text = "Total";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(665, 414);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotal.Size = new System.Drawing.Size(100, 23);
            this.txtTotal.TabIndex = 48;
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(17, 67);
            this.Grilla.Name = "Grilla";
            this.Grilla.ReadOnly = true;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(748, 330);
            this.Grilla.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 40;
            this.label2.Text = "Fecha Hasta";
            // 
            // FrmResumenProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 463);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmResumenProveedor";
            this.Text = "Resumen de deuda de Proveedores";
            this.Load += new System.EventHandler(this.FrmResumenProveedor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dpFecha;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAbrirCompra;
        private System.Windows.Forms.Button btnBuscarCompra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Label label1;
    }
}