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
    public partial class frmFactura : Form
    {
        public frmFactura()
        {
            InitializeComponent();
        }

        private void frmModoPago_Load(object sender, EventArgs e)
        {
            List<Factura> listado = Factura.traerTodos(true);

            dgvFactura.DataSource = listado;
            dgvFactura.Refresh();

            //Agregar Modo de Pago
            List<ModoPago> listadoModoPago = ModoPago.traerTodos();
            cboModoPago.DataSource = listadoModoPago;
            cboModoPago.ValueMember = "idModoPago";
            cboModoPago.DisplayMember = "nombre";
            cboModoPago.Refresh();


        }
    }
}
