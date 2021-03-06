﻿namespace SistemaVentas
{
    partial class FrmRoles
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
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.esActivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnDesactivar = new System.Windows.Forms.Button();
            this.lblIdRol = new System.Windows.Forms.Label();
            this.txtIdRol = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescRol = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRoles
            // 
            this.dgvRoles.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.esActivo});
            this.dgvRoles.Location = new System.Drawing.Point(23, 12);
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.Size = new System.Drawing.Size(363, 167);
            this.dgvRoles.TabIndex = 0;
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
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(250, 261);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(65, 23);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesactivar.Location = new System.Drawing.Point(321, 261);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(65, 23);
            this.btnDesactivar.TabIndex = 2;
            this.btnDesactivar.Text = "Eliminar";
            this.btnDesactivar.UseVisualStyleBackColor = true;
            // 
            // lblIdRol
            // 
            this.lblIdRol.AutoSize = true;
            this.lblIdRol.Location = new System.Drawing.Point(29, 228);
            this.lblIdRol.Name = "lblIdRol";
            this.lblIdRol.Size = new System.Drawing.Size(37, 13);
            this.lblIdRol.TabIndex = 3;
            this.lblIdRol.Text = "ID Rol";
            // 
            // txtIdRol
            // 
            this.txtIdRol.Location = new System.Drawing.Point(81, 225);
            this.txtIdRol.Name = "txtIdRol";
            this.txtIdRol.ReadOnly = true;
            this.txtIdRol.Size = new System.Drawing.Size(82, 20);
            this.txtIdRol.TabIndex = 6;
            this.txtIdRol.Text = "0";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(81, 195);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(305, 20);
            this.txtDescripcion.TabIndex = 8;
            // 
            // lblDescRol
            // 
            this.lblDescRol.AutoSize = true;
            this.lblDescRol.Location = new System.Drawing.Point(20, 199);
            this.lblDescRol.Name = "lblDescRol";
            this.lblDescRol.Size = new System.Drawing.Size(58, 13);
            this.lblDescRol.TabIndex = 9;
            this.lblDescRol.Text = "Nuevo Rol";
            // 
            // FrmRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(415, 297);
            this.Controls.Add(this.lblDescRol);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtIdRol);
            this.Controls.Add(this.lblIdRol);
            this.Controls.Add(this.btnDesactivar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dgvRoles);
            this.Name = "FrmRoles";
            this.Text = "Roles";
            this.Load += new System.EventHandler(this.FrmRoles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnDesactivar;
        private System.Windows.Forms.Label lblIdRol;
        private System.Windows.Forms.TextBox txtIdRol;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescRol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn esActivo;
    }
}