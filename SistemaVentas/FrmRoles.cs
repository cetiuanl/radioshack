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
    public partial class FrmRoles : Form
    {
        public FrmRoles()
        {
            InitializeComponent();
        }

       
        private void FrmRoles_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            List<Rol> Listado = Rol.traerActivos();

            dgvRoles.DataSource = Listado;
            dgvRoles.Refresh();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int idRol = IntegerExtensions.ParseInt(txtIdRol.Text);

            Rol nuevoRol = new Rol(idRol, this.txtDescripcion.Text);

            try
            {
                nuevoRol.guardar();
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
