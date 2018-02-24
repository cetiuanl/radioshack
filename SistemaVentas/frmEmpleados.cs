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
            cargarDatos();
        }

        #region Funciones
        private void cargarDatos()
        {
            List<Empleado> Listado = Empleado.traerTodos(true);
            dgvEmpleados.DataSource = Listado;
            dgvEmpleados.Refresh();

            //Agregar categorias de db con descripción
            List<Rol> listadoRoles = Rol.traerTodos();
            cboIdRol.DataSource = listadoRoles;
            cboIdRol.ValueMember = "idRol";
            cboIdRol.DisplayMember = "descripcion";
            cboIdRol.Refresh();
        }

        private void limpiarCampos()
        {
            txtIdEmpleado.Text = "0";
            txtNombreCompleto.Clear();
            txtCorreoElectronico.Clear();
            txtContrasena.Clear();
            dtpFechaIngreso.Value = DateTime.Today;
            dtpFechaNacimiento.Value = DateTime.Today;
        }

        private string datosValidos()
        {
            string resultado = "";
            if (txtNombreCompleto.Text.Trim().Length <3)
            {
                resultado = resultado +  "El nombre es invalido \n";
            }
            if (txtCorreoElectronico.Text.Trim().Length <3)
            {
                resultado = resultado + "El correo es invalido \n";
            }
            if (txtContrasena.Text.Trim().Length<3)
            {
                resultado = resultado +  "Contraseña Invalida \n";
            }
            return resultado;
        }
        #endregion
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string resultadoValidacion = datosValidos();
            if (resultadoValidacion != "")
            {
                MessageBox.Show(resultadoValidacion,
                                "Atención",
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Exclamation);
                return;
            }

            int idEmpleado = IntegerExtensions.ParseInt(txtIdEmpleado.Text);
            DateTime fechaIngreso = Convert.ToDateTime(dtpFechaIngreso.Text);
            DateTime fechaNacimiento = Convert.ToDateTime(dtpFechaNacimiento.Text);
            int RolEmpleado = IntegerExtensions.ParseInt(cboIdRol.SelectedValue.ToString());

            Empleado nuevoEmpleado = new Empleado(idEmpleado, this.txtNombreCompleto.Text, fechaIngreso, RolEmpleado,
             true,fechaNacimiento,this.txtCorreoElectronico.Text,this.txtContrasena.Text);

            try
            {
                nuevoEmpleado.guardar();
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

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <0)
            {
                return;
            }

            DataGridViewRow fila =  dgvEmpleados.Rows[e.RowIndex];
            txtIdEmpleado.Text = fila.Cells["idEmpleado"].Value.ToString();
            txtNombreCompleto.Text = fila.Cells["nombreCompleto"].Value.ToString();
            dtpFechaIngreso.Text = fila.Cells["fechaIngreso"].Value.ToString();
            cboIdRol.Text = fila.Cells["idRol"].Value.ToString();
            dtpFechaNacimiento.Text = fila.Cells["fechaIngreso"].Value.ToString();
            txtCorreoElectronico.Text = fila.Cells["correoElectronico"].Value.ToString();
            txtContrasena.Text = fila.Cells["contrasena"].Value.ToString();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            int idEmpleado = IntegerExtensions.ParseInt(txtIdEmpleado.Text);

            try
            {
                Empleado.desactivar(idEmpleado);
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
