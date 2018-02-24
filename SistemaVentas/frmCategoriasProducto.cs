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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string resultadoValidacion = datosValidos();
            if (resultadoValidacion != "")
            {
                MessageBox.Show(resultadoValidacion, "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int idCategoria = IntegerExtensions.ParseInt(txtidCategoriasProducto.Text);
            CategoriasProducto nuevaCategoria = new CategoriasProducto(idCategoria, this.txtNombre.Text, txtDescripcion.Text, true);


            try
            {
                nuevaCategoria.guardar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                limpiarCampos();
                cargarDatos();
            }
        }

        private void dgvCategoriasProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow fila = dgvCategoriasProducto.Rows[e.RowIndex];
            txtidCategoriasProducto.Text = fila.Cells["idCategoria"].Value.ToString();
            txtNombre.Text = fila.Cells["nombre"].Value.ToString();
            if (fila.Cells["descripcion"].Value != null)
            {
                txtDescripcion.Text = fila.Cells["descripcion"].Value.ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            int idCategoria = IntegerExtensions.ParseInt(txtidCategoriasProducto.Text);
            try
            {
                CategoriasProducto.desactivar(idCategoria);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
            finally
            {
                cargarDatos();
            }
        }
        #region Funciones
        private void cargarDatos()
        {
            List<CategoriasProducto> listado = CategoriasProducto.traerTodos(true);
            dgvCategoriasProducto.DataSource = listado;
            dgvCategoriasProducto.Refresh();

        }
        private void limpiarCampos()
        {
            txtidCategoriasProducto.Text = "0";
            txtNombre.Clear();
            txtDescripcion.Clear();

        }
        private string datosValidos()
        {
            string resultado = "";
            if(txtNombre.Text.Trim().Length < 3)
            {
                resultado = resultado + "El nombre ingresado es invalido. Intenta de nuevo.\n";
            }
            if(txtDescripcion.Text.Trim().Length == 0)
            {
                resultado = resultado + "Descripcion ingresada es invalida. Intenta de nuevo.";
            }
            return resultado;
        }
        #endregion
       
    }
}
