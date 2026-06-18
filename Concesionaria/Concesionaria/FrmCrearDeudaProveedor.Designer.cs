namespace Concesionaria
{
    partial class FrmCrearDeudaProveedor
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dpFecha = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dpFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.txtCuentaProveedor = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnBuscarCuenta = new System.Windows.Forms.Button();
            this.txtCodCuenta = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioNegocio = new System.Windows.Forms.RadioButton();
            this.radioPersonal = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RadioVariable = new System.Windows.Forms.RadioButton();
            this.RadioFijo = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            this.txtCodAuto = new System.Windows.Forms.TextBox();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.txtCodStock = new System.Windows.Forms.TextBox();
            this.btnAbrirStock = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtVehiculo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = " Monto";
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(119, 66);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(100, 23);
            this.txtImporte.TabIndex = 1;
            this.txtImporte.Leave += new System.EventHandler(this.txtImporte_Leave);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(119, 452);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 37);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha";
            // 
            // txtProveedor
            // 
            this.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProveedor.Location = new System.Drawing.Point(119, 95);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(305, 23);
            this.txtProveedor.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "Proveedor";
            // 
            // dpFecha
            // 
            this.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFecha.Location = new System.Drawing.Point(119, 37);
            this.dpFecha.Name = "dpFecha";
            this.dpFecha.Size = new System.Drawing.Size(87, 23);
            this.dpFecha.TabIndex = 71;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 17);
            this.label8.TabIndex = 72;
            this.label8.Text = "Fecha Vto";
            // 
            // dpFechaVencimiento
            // 
            this.dpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaVencimiento.Location = new System.Drawing.Point(121, 153);
            this.dpFechaVencimiento.Name = "dpFechaVencimiento";
            this.dpFechaVencimiento.Size = new System.Drawing.Size(87, 23);
            this.dpFechaVencimiento.TabIndex = 73;
            // 
            // txtCuentaProveedor
            // 
            this.txtCuentaProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCuentaProveedor.Location = new System.Drawing.Point(121, 124);
            this.txtCuentaProveedor.Name = "txtCuentaProveedor";
            this.txtCuentaProveedor.Size = new System.Drawing.Size(305, 23);
            this.txtCuentaProveedor.TabIndex = 76;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 17);
            this.label10.TabIndex = 77;
            this.label10.Text = "Cuenta";
            // 
            // btnBuscarCuenta
            // 
            this.btnBuscarCuenta.Image = global::Concesionaria.Properties.Resources.carpeta;
            this.btnBuscarCuenta.Location = new System.Drawing.Point(212, 37);
            this.btnBuscarCuenta.Name = "btnBuscarCuenta";
            this.btnBuscarCuenta.Size = new System.Drawing.Size(40, 27);
            this.btnBuscarCuenta.TabIndex = 78;
            this.btnBuscarCuenta.UseVisualStyleBackColor = true;
            this.btnBuscarCuenta.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // txtCodCuenta
            // 
            this.txtCodCuenta.BackColor = System.Drawing.Color.Red;
            this.txtCodCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodCuenta.Location = new System.Drawing.Point(6, 66);
            this.txtCodCuenta.Name = "txtCodCuenta";
            this.txtCodCuenta.Size = new System.Drawing.Size(23, 23);
            this.txtCodCuenta.TabIndex = 79;
            this.txtCodCuenta.Visible = false;
            // 
            // button1
            // 
            this.button1.Image = global::Concesionaria.Properties.Resources.email;
            this.button1.Location = new System.Drawing.Point(225, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 29);
            this.button1.TabIndex = 82;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cmbEmpleado);
            this.groupBox1.Controls.Add(this.txtCodAuto);
            this.groupBox1.Controls.Add(this.txtPatente);
            this.groupBox1.Controls.Add(this.txtCodStock);
            this.groupBox1.Controls.Add(this.btnAbrirStock);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtVehiculo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtConcepto);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtCodCuenta);
            this.groupBox1.Controls.Add(this.btnBuscarCuenta);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtCuentaProveedor);
            this.groupBox1.Controls.Add(this.dpFechaVencimiento);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dpFecha);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtProveedor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.txtImporte);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(25, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(477, 495);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RegistrarDeuda Proveedor";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioNegocio);
            this.groupBox3.Controls.Add(this.radioPersonal);
            this.groupBox3.Location = new System.Drawing.Point(239, 182);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(194, 43);
            this.groupBox3.TabIndex = 100;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Caracter";
            // 
            // radioNegocio
            // 
            this.radioNegocio.AutoSize = true;
            this.radioNegocio.Checked = true;
            this.radioNegocio.Location = new System.Drawing.Point(6, 22);
            this.radioNegocio.Name = "radioNegocio";
            this.radioNegocio.Size = new System.Drawing.Size(78, 21);
            this.radioNegocio.TabIndex = 100;
            this.radioNegocio.TabStop = true;
            this.radioNegocio.Text = "Negocio";
            this.radioNegocio.UseVisualStyleBackColor = true;
            // 
            // radioPersonal
            // 
            this.radioPersonal.AutoSize = true;
            this.radioPersonal.Location = new System.Drawing.Point(90, 22);
            this.radioPersonal.Name = "radioPersonal";
            this.radioPersonal.Size = new System.Drawing.Size(82, 21);
            this.radioPersonal.TabIndex = 99;
            this.radioPersonal.Text = "Personal";
            this.radioPersonal.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RadioVariable);
            this.groupBox2.Controls.Add(this.RadioFijo);
            this.groupBox2.Location = new System.Drawing.Point(30, 182);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(164, 55);
            this.groupBox2.TabIndex = 99;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo De Costo";
            // 
            // RadioVariable
            // 
            this.RadioVariable.AutoSize = true;
            this.RadioVariable.Location = new System.Drawing.Point(64, 22);
            this.RadioVariable.Name = "RadioVariable";
            this.RadioVariable.Size = new System.Drawing.Size(78, 21);
            this.RadioVariable.TabIndex = 100;
            this.RadioVariable.Text = "Variable";
            this.RadioVariable.UseVisualStyleBackColor = true;
            // 
            // RadioFijo
            // 
            this.RadioFijo.AutoSize = true;
            this.RadioFijo.Checked = true;
            this.RadioFijo.Location = new System.Drawing.Point(10, 22);
            this.RadioFijo.Name = "RadioFijo";
            this.RadioFijo.Size = new System.Drawing.Size(48, 21);
            this.RadioFijo.TabIndex = 99;
            this.RadioFijo.TabStop = true;
            this.RadioFijo.Text = "Fijo";
            this.RadioFijo.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(39, 235);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 17);
            this.label11.TabIndex = 96;
            this.label11.Text = "Empleado";
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpleado.FormattingEnabled = true;
            this.cmbEmpleado.Location = new System.Drawing.Point(119, 235);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(305, 24);
            this.cmbEmpleado.TabIndex = 95;
            // 
            // txtCodAuto
            // 
            this.txtCodAuto.BackColor = System.Drawing.Color.Red;
            this.txtCodAuto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodAuto.Location = new System.Drawing.Point(351, 159);
            this.txtCodAuto.Name = "txtCodAuto";
            this.txtCodAuto.Size = new System.Drawing.Size(71, 23);
            this.txtCodAuto.TabIndex = 90;
            this.txtCodAuto.Visible = false;
            // 
            // txtPatente
            // 
            this.txtPatente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPatente.Enabled = false;
            this.txtPatente.Location = new System.Drawing.Point(331, 41);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.ReadOnly = true;
            this.txtPatente.Size = new System.Drawing.Size(93, 23);
            this.txtPatente.TabIndex = 89;
            // 
            // txtCodStock
            // 
            this.txtCodStock.BackColor = System.Drawing.Color.Red;
            this.txtCodStock.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodStock.Location = new System.Drawing.Point(271, 159);
            this.txtCodStock.Name = "txtCodStock";
            this.txtCodStock.Size = new System.Drawing.Size(71, 23);
            this.txtCodStock.TabIndex = 88;
            this.txtCodStock.Visible = false;
            // 
            // btnAbrirStock
            // 
            this.btnAbrirStock.Image = global::Concesionaria.Properties.Resources.carpeta;
            this.btnAbrirStock.Location = new System.Drawing.Point(430, 37);
            this.btnAbrirStock.Name = "btnAbrirStock";
            this.btnAbrirStock.Size = new System.Drawing.Size(40, 27);
            this.btnAbrirStock.TabIndex = 87;
            this.btnAbrirStock.UseVisualStyleBackColor = true;
            this.btnAbrirStock.Click += new System.EventHandler(this.btnAbrirStock_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(268, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 17);
            this.label6.TabIndex = 86;
            this.label6.Text = "Patente";
            // 
            // txtVehiculo
            // 
            this.txtVehiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVehiculo.Enabled = false;
            this.txtVehiculo.Location = new System.Drawing.Point(225, 66);
            this.txtVehiculo.Name = "txtVehiculo";
            this.txtVehiculo.ReadOnly = true;
            this.txtVehiculo.Size = new System.Drawing.Size(197, 23);
            this.txtVehiculo.TabIndex = 85;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 84;
            this.label5.Text = "Concepto";
            // 
            // txtConcepto
            // 
            this.txtConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConcepto.Location = new System.Drawing.Point(119, 261);
            this.txtConcepto.Multiline = true;
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(305, 173);
            this.txtConcepto.TabIndex = 83;
            // 
            // FrmCrearDeudaProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 519);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCrearDeudaProveedor";
            this.Text = "";
            this.Load += new System.EventHandler(this.FrmCrearDeudaProveedor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dpFecha;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dpFechaVencimiento;
        private System.Windows.Forms.TextBox txtCuentaProveedor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnBuscarCuenta;
        private System.Windows.Forms.TextBox txtCodCuenta;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Button btnAbrirStock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtVehiculo;
        private System.Windows.Forms.TextBox txtCodStock;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.TextBox txtCodAuto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbEmpleado;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioNegocio;
        private System.Windows.Forms.RadioButton radioPersonal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RadioVariable;
        private System.Windows.Forms.RadioButton RadioFijo;
    }
}