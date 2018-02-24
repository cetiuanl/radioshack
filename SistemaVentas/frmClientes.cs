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
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            cargarDatos();
            dtpFechaNacimiento.MaxDate = DateTime.Today;
        }

        #region Funciones

        private void cargarDatos()
        {
            List<Cliente> listado = Cliente.traerTodos(true);
            dgvClientes.DataSource = listado;
            dgvClientes.Refresh();
        }

        private void limpiarCampo()
        {
            txtIdCliente.Text = "0";
            txtNombre.Clear();
            txtApellidos.Clear();
            txtDomicilio.Clear();
            dtpFechaNacimiento.Value = DateTime.Today;
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtRFC.Clear();
        }

        private string datosValidos()
        {
            string resultado = "";
            if (txtNombre.Text.Trim().Length == 0)
                resultado = resultado + "Campos nombre no es valido \n";
            if (txtApellidos.Text.Trim().Length == 0)
                resultado = resultado + "Campos apellidos no es valido \n";
            if (txtDomicilio.Text.Trim().Length == 0)
                resultado = resultado + "Campos domicilio no es valido \n";
            if (txtTelefono.Text.Trim().Length == 0 )
                resultado = resultado + "Campos telefono no es valido \n";
            if (txtCorreo.Text.Trim().Length == 0)
                resultado = resultado + "Campos correo no es valido \n";
            if (txtRFC.Text.Trim().Length == 0)
                resultado = resultado + "Campos RFC no es valido ";
            return resultado;
        }

        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string resultadoValidacion = datosValidos();
            if (resultadoValidacion != "")
            {
                MessageBox.Show(resultadoValidacion, 
                    "Atencion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            int idCliente = IntegerExtensions.ParseInt(txtIdCliente.Text);
            DateTime fechaNacimiento = Convert.ToDateTime(dtpFechaNacimiento.Text);

            Cliente nuevoCliente = new Cliente(idCliente, this.txtNombre.Text, this.txtApellidos.Text,
                this.txtDomicilio.Text, fechaNacimiento, this.txtTelefono.Text,
                this.txtCorreo.Text, this.txtRFC.Text, true);
               
            try
            {
               nuevoCliente.guardar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                limpiarCampo();
                cargarDatos();
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keypress = e.KeyChar;
            if(char.IsDigit(keypress) || e.KeyChar == Convert.ToChar(Keys.Back))
            {
                
            }
            else
            {
                MessageBox.Show("Solo se aceptan numeros");
                e.Handled = true;
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];
            txtIdCliente.Text = fila.Cells["idCliente"].Value.ToString();
            txtNombre.Text = fila.Cells["nombre"].Value.ToString();
            txtApellidos.Text = fila.Cells["apellidos"].Value.ToString();
            txtDomicilio.Text = fila.Cells["domicilio"].Value.ToString();
            dtpFechaNacimiento.Text = fila.Cells["fechaNacimiento"].Value.ToString();
            txtTelefono.Text = fila.Cells["telefono"].Value.ToString();
            txtCorreo.Text = fila.Cells["Correo"].Value.ToString();
            txtRFC.Text = fila.Cells["RFC"].Value.ToString();
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            int idCliente = IntegerExtensions.ParseInt(txtIdCliente.Text);

            try
            {
                Cliente.desactivar(idCliente);
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

        private void NuevoRegistro_Click(object sender, EventArgs e)
        {

        }
    }
}
