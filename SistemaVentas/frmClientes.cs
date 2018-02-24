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
        }

        private void cargarDatos()
        {
            List<Cliente> listado = Cliente.traerTodos();
            dgvClientes.DataSource = listado;
            dgvClientes.Refresh();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
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
                cargarDatos();
            }
        }
    }
}
