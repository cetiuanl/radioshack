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
    public partial class frmInicioSesion : Form
    {
        public Empleado usuarioActual;
        public frmInicioSesion()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
#if DEBUG
                Empleado usuarioValido = Empleado.buscarPorId(200);
#else
                Empleado usuarioValido = Empleado.iniciarSesion(txtCorreo.Text, txtContrasena.Text);
#endif

                if (usuarioValido != null)
                {
                    this.usuarioActual = usuarioValido;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception)
            {
                this.DialogResult = DialogResult.Retry;
                            
            }
        }

        private void frmInicioSesion_FormClosed(object sender, FormClosedEventArgs e)
        { 
            if (this.usuarioActual == null)
            {
                this.DialogResult = DialogResult.Abort;
            }            
        }
    }
}
