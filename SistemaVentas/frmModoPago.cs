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
            List<ModoPago> listado = ModoPago.traerTodos(true);

            dgvModoPagos.DataSource = listado;
            dgvModoPagos.Refresh();
        }
    }
}
