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
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            List<Producto> listado = Producto.traerTodos(true);
            dgvProductos.DataSource = listado;
            dgvProductos.Refresh();

            List<CategoriasProducto> Categorias = CategoriasProducto.traerTodos(true);
            cboIdCategoria.DataSource = Categorias;
            cboIdCategoria.ValueMember = "idCategoria";
            cboIdCategoria.DisplayMember = "nombre";
            cboIdCategoria.Refresh();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
