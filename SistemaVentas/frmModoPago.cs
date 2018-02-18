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
    public partial class frmModoPago : Form
    {
        public frmModoPago()
        {
            InitializeComponent();
        }

        private void frmModoPago_Load(object sender, EventArgs e)
        {
#if DEBUG
            MessageBox.Show("Estas en pruebas");
#else
            MessageBox.Show("Estas en Release");
#endif
            cargarDatos();
        }

        private void cargarDatos()
        {
            List<ModoPago> listado = ModoPago.traerTodos(true);

            dgvModoPagos.DataSource = listado;
            dgvModoPagos.Refresh();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int idModoPago = IntegerExtensions.ParseInt(txtIdModoPago.Text);

            ModoPago nuevoPago = new ModoPago(idModoPago, 
                                           this.txtNombre.Text, 
                                           txtDetalles.Text,
                                            true);

            try
            {
                nuevoPago.guardar();
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
