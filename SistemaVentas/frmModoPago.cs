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
        private static frmModoPago instancia;

        public static frmModoPago getInstancia
        {
            get
            {
                if( instancia == null || instancia.IsDisposed)
                {
                    instancia = new frmModoPago();
                }
                return instancia;
            }
        }

        public frmModoPago()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmModoPago_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
        
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
                limpiarCampos();
                cargarDatos();
            }            
        }

        #endregion

        #region Funciones

        private void cargarDatos()
        {
            List<ModoPago> listado = ModoPago.traerTodos(true);

            dgvModoPagos.DataSource = listado;
            dgvModoPagos.Refresh();
        }

        private void limpiarCampos()
        {
            txtIdModoPago.Text = "0";
            txtNombre.Clear();
            txtDetalles.Clear();
        }

        private string datosValidos()
        {
            string resultado = "";
            if (txtNombre.Text.Trim().Length < 3)
            {
                resultado = resultado + "Campo Nombre es invalido. \n";
            }

            if (txtDetalles.Text.Trim().Length == 0)
            {
                resultado = resultado + "Campo Detalles es invalido. \n";
            }

            if (IntegerExtensions.ParseInt(txtIdModoPago.Text) < 0)
            {

            }
            
            return resultado;
        }

        #endregion

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keypress = e.KeyChar;
            if (char.IsDigit(keypress) || e.KeyChar==Convert.ToChar(Keys.Back))
            {
            

            }
            else
            {
                MessageBox.Show("You Can Only Enter A Number!");
                e.Handled = true;
            }

            //if (Char.IsNumber(e.KeyChar) || Char.IsSymbol(e.KeyChar))
            //{
            //    MessageBox.Show("Only Char are allowed");
            //    e.Handled = true;
            //}
        }

        private void dgvModoPagos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow fila = dgvModoPagos.Rows[e.RowIndex];

            txtIdModoPago.Text = fila.Cells["idModoPago"].Value.ToString();

            txtNombre.Text = fila.Cells["nombre"].Value.ToString();

            if (fila.Cells["detalles"].Value != null)
            {
                txtDetalles.Text = fila.Cells["detalles"].Value.ToString();
            }            

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            int idModoPago = IntegerExtensions.ParseInt(txtIdModoPago.Text);

            try
            {
                ModoPago.desactivar(idModoPago);
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
