namespace SistemaVentas
{
    partial class frmFactura
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
            this.dgvFactura = new System.Windows.Forms.DataGridView();
            this.Guardar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cboModoPago = new System.Windows.Forms.ComboBox();
            this.cboModoCliente = new System.Windows.Forms.ComboBox();
            this.Pago = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFactura
            // 
            this.dgvFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFactura.Location = new System.Drawing.Point(26, 36);
            this.dgvFactura.Name = "dgvFactura";
            this.dgvFactura.Size = new System.Drawing.Size(680, 102);
            this.dgvFactura.TabIndex = 0;
            // 
            // Guardar
            // 
            this.Guardar.Location = new System.Drawing.Point(278, 365);
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(75, 23);
            this.Guardar.TabIndex = 1;
            this.Guardar.Text = "Guardar";
            this.Guardar.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(476, 368);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "Eliminar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(486, 229);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // cboModoPago
            // 
            this.cboModoPago.FormattingEnabled = true;
            this.cboModoPago.Location = new System.Drawing.Point(94, 212);
            this.cboModoPago.Name = "cboModoPago";
            this.cboModoPago.Size = new System.Drawing.Size(154, 21);
            this.cboModoPago.TabIndex = 4;
            // 
            // cboModoCliente
            // 
            this.cboModoCliente.FormattingEnabled = true;
            this.cboModoCliente.Location = new System.Drawing.Point(93, 259);
            this.cboModoCliente.Name = "cboModoCliente";
            this.cboModoCliente.Size = new System.Drawing.Size(155, 21);
            this.cboModoCliente.TabIndex = 5;
            // 
            // Pago
            // 
            this.Pago.AutoSize = true;
            this.Pago.Location = new System.Drawing.Point(25, 211);
            this.Pago.Name = "Pago";
            this.Pago.Size = new System.Drawing.Size(62, 13);
            this.Pago.TabIndex = 6;
            this.Pago.Text = "Modo Pago";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tipo Client";
            // 
            // frmFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 444);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Pago);
            this.Controls.Add(this.cboModoCliente);
            this.Controls.Add(this.cboModoPago);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Guardar);
            this.Controls.Add(this.dgvFactura);
            this.Name = "frmFactura";
            this.Text = "Factura";
            this.Load += new System.EventHandler(this.frmModoPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFactura;
        private System.Windows.Forms.Button Guardar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cboModoPago;
        private System.Windows.Forms.ComboBox cboModoCliente;
        private System.Windows.Forms.Label Pago;
        private System.Windows.Forms.Label label1;
    }
}