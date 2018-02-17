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
    public partial class frmEmpleados : Form
    {
        public frmEmpleados()
        {
            InitializeComponent();
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            List<Empleado> listado = Empleado.traerTodos(true);
            dgvEmpleados.DataSource = listado;
            dgvEmpleados.Refresh();

            List<Empleado> listado = Empleado.traerTodos(true);
            dgvEmpleados.DataSource = listado;
            dgvEmpleados.Refresh();

        }
    }
}
