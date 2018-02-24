using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CN;

namespace SistemaVentas
{
    public partial class frmPrincipal : Form
    {
        public Empleado usuarioActual;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFactura form = new frmFactura();
            form.MdiParent = this;
            form.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes form = new frmClientes();
            form.MdiParent = this;
            form.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductos form = new frmProductos();
            form.MdiParent = this;
            form.Show();
        }

        private void categoriasProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoriasProducto form = new frmCategoriasProducto();
            form.MdiParent = this;
            form.Show();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRoles form = new FrmRoles();
            form.MdiParent = this;
            form.Show();
        }

        private void modoDePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModoPago form = new frmModoPago();
            form.MdiParent = this;
            form.Show();
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpleados form = new frmEmpleados();
            form.MdiParent = this;
            form.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            frmInicioSesion frm = new frmInicioSesion();

            DialogResult result = frm.ShowDialog();


            if (result == DialogResult.Abort)
            {
                this.Close();
            }
            else if (result == DialogResult.OK)
            {
                this.usuarioActual = frm.usuarioActual;
            }
            else if (result == DialogResult.Retry)
            {
                MessageBox.Show("Ha ocurrido un problema. Vuelve a intentar.");
            }

        }
    }
}
