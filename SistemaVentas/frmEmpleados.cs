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
            //Data consulta tblEmpleados
            List<Empleado> listado = Empleado.traerTodos(true);
            dgvEmpleados.DataSource = listado;
            dgvEmpleados.Refresh();

            //Agregar categorias de db con descripción
            List<Rol> listadoRoles = Rol.traerTodos();
            cboIdRol.DataSource = listadoRoles;
            cboIdRol.ValueMember = "idRol";
            cboIdRol.DisplayMember = "descripcion";
            cboIdRol.Refresh();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //int idEmpleado = IntegerExtensions.ParseInt(txtIdEmpleado.Text);
           // DateTime fechaIngreso
            //Empleado nuevoEmpleado = new Empleado(idEmpleado,this.txtIdEmpleado, nombreCompleto,this.txtNombreCompleto, 
                //dtpFechaIngreso.Text,this.dtpFechaIngreso);
        }
    }
}
