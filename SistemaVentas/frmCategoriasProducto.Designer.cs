namespace SistemaVentas
{
    partial class frmCategoriasProducto
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
            this.dgvCategoriasProducto = new System.Windows.Forms.DataGridView();
            this.esActivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnDesactivar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtidCategoriasProducto = new System.Windows.Forms.TextBox();
            this.lblidCategoriasProducto = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoriasProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCategoriasProducto
            // 
            this.dgvCategoriasProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategoriasProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.esActivo});
            this.dgvCategoriasProducto.Location = new System.Drawing.Point(46, 45);
            this.dgvCategoriasProducto.Name = "dgvCategoriasProducto";
            this.dgvCategoriasProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategoriasProducto.Size = new System.Drawing.Size(685, 259);
            this.dgvCategoriasProducto.TabIndex = 0;
            this.dgvCategoriasProducto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategoriasProducto_CellClick);
            this.dgvCategoriasProducto.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategoriasProducto_CellContentClick);
            // 
            // esActivo
            // 
            this.esActivo.DataPropertyName = "esActivo";
            this.esActivo.HeaderText = "esActivo";
            this.esActivo.Name = "esActivo";
            this.esActivo.Visible = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(332, 530);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 24);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.Location = new System.Drawing.Point(498, 530);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(75, 24);
            this.btnDesactivar.TabIndex = 3;
            this.btnDesactivar.Text = "Eliminar";
            this.btnDesactivar.UseVisualStyleBackColor = true;
            this.btnDesactivar.Click += new System.EventHandler(this.btnDesactivar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(291, 401);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(221, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(291, 446);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(221, 20);
            this.txtDescripcion.TabIndex = 0;
            // 
            // txtidCategoriasProducto
            // 
            this.txtidCategoriasProducto.Location = new System.Drawing.Point(291, 342);
            this.txtidCategoriasProducto.Name = "txtidCategoriasProducto";
            this.txtidCategoriasProducto.ReadOnly = true;
            this.txtidCategoriasProducto.Size = new System.Drawing.Size(100, 20);
            this.txtidCategoriasProducto.TabIndex = 5;
            this.txtidCategoriasProducto.Text = "0";
            // 
            // lblidCategoriasProducto
            // 
            this.lblidCategoriasProducto.AutoSize = true;
            this.lblidCategoriasProducto.Location = new System.Drawing.Point(211, 345);
            this.lblidCategoriasProducto.Name = "lblidCategoriasProducto";
            this.lblidCategoriasProducto.Size = new System.Drawing.Size(65, 13);
            this.lblidCategoriasProducto.TabIndex = 7;
            this.lblidCategoriasProducto.Text = "id Categoría";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(232, 404);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 8;
            this.lblNombre.Text = "Nombre";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(213, 453);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 9;
            this.lblDescripcion.Text = "Descripción";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(155, 530);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 24);
            this.button1.TabIndex = 10;
            this.button1.Text = "Nuevo registro";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmCategoriasProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(773, 607);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblidCategoriasProducto);
            this.Controls.Add(this.txtidCategoriasProducto);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnDesactivar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dgvCategoriasProducto);
            this.Name = "frmCategoriasProducto";
            this.Text = "                                                                                 " +
    "                                ";
            this.Load += new System.EventHandler(this.frmCategoriasProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoriasProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCategoriasProducto;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnDesactivar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtidCategoriasProducto;
        private System.Windows.Forms.Label lblidCategoriasProducto;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn esActivo;
        private System.Windows.Forms.Button button1;
    }
}