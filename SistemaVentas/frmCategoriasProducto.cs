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
            cargarDatos();
        }

        private void dgvCategoriasProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void cargarDatos()
        {
            List<CategoriasProducto> listado = CategoriasProducto.traerTodos(true);
            dgvCategoriasProducto.DataSource = listado;
            dgvCategoriasProducto.Refresh();

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int idCategoria = IntegerExtensions.ParseInt(txtidCategoriasProducto.Text);
            CategoriasProducto nuevaCategoria = new CategoriasProducto(idCategoria, this.txtNombre.Text, txtDescripcion.Text, true);


            try
            {
                nuevaCategoria.guardar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cargarDatos();
            }
        }
    }
}
