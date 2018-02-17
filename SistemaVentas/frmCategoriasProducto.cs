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
    public partial class frmCategoriasProducto : Form
    {
        public frmCategoriasProducto()
        {
            InitializeComponent();
        }

        private void frmCategoriasProducto_Load(object sender, EventArgs e)
        {
            List<CategoriasProducto> listado = CategoriasProducto.traerTodos(true);
        }
    }
}
