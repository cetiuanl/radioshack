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
            cargarDatos();
        }
        
        private void cargarDatos()
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
            string resultadoValidacion = datosValidos();
            if (resultadoValidacion != "")
            {
                MessageBox.Show(resultadoValidacion, "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int idProducto = IntegerExtensions.ParseInt(txtIdProducto.Text);
            int idCategoriaProducto = IntegerExtensions.ParseInt(cboIdCategoria.SelectedValue.ToString());
            decimal precio = DecimalExtensions.ParseDecimal(txtPrecio.Text);
            decimal inventario = DecimalExtensions.ParseDecimal(txtInventario.Text);

            Producto nuevoProducto = new Producto(idProducto,txtNombre.Text,txtMarca.Text,precio,inventario,idCategoriaProducto,true);

            try
            {
                nuevoProducto.guardar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                cargarDatos();
            }
        }

        private void limpiarCampos()
        {
            txtNombre.Clear();
            txtMarca.Clear();
            txtPrecio.Text = "$0.00";
            txtInventario.Clear();
        }


        private void validaPositivos_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keypress = e.KeyChar;
            if (char.IsDigit(keypress) || e.KeyChar == Convert.ToChar(Keys.Back))
            {

            }
            else
            {
                MessageBox.Show("Solo se aceptan valores numericos positivos");
                e.Handled = true;
            }
        }

        private string datosValidos()
        {
            string resultado = "";
            if (txtNombre.Text.Trim().Length == 0)
            {
                resultado = resultado + "Campo Nombre Invalido. \n";
            }
            if (txtMarca.Text.Trim().Length == 0)
            {
                resultado = resultado + "Campo Marca Invalido. \n";
            }

            return resultado;
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];
            txtIdProducto.Text = fila.Cells["idProducto"].Value.ToString();
            txtNombre.Text = fila.Cells["nombre"].Value.ToString();
            txtMarca.Text = fila.Cells["marca"].Value.ToString();
            txtPrecio.Text = fila.Cells["precio"].Value.ToString();
            txtInventario.Text = fila.Cells["inventario"].Value.ToString();
            cboIdCategoria.Text = fila.Cells["idCategoria"].Value.ToString();
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            int idProducto = IntegerExtensions.ParseInt(txtIdProducto.Text);
            try
            {
                Producto.desactivar(idProducto);
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
    }
}
