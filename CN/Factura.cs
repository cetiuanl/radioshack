using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CD;
using CN.Excepciones;
using System.Data;

namespace CN
{
   public class Factura
    {
        #region Propiedades
        private int _folio;

        public int folio
        {
            get { return _folio; }
            set { _folio = value; }
        }

        private int _idCliente;

        public int idCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }

        private DateTime _fecha;

        public DateTime fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private int _idModoPago;

        public int idModoPago
        {
            get { return _idModoPago; }
            set { _idModoPago = value; }
        }

        private int _porcientoIVA;

        public int porcientoIVA
        {
            get { return _porcientoIVA; }
            set { _porcientoIVA = value; }
        }

        private int _estatus;

        public int estatus
        {
            get { return _estatus; }
            set { _estatus = value; }
        }

        private int _idEmpleado;

        public int idEmpleado
        {
            get { return _idEmpleado; }
            set { _idEmpleado = value; }
        }
        #endregion

        #region Constructores
        public Factura(int folio, int idCliente, DateTime fecha, int idModoPago, int porcientoIVA, int estatus, int idEmpleado)
        {
            this.folio = folio;
            this.idCliente = idCliente;
            this.fecha = fecha;
            this.idModoPago = idModoPago;
            this.porcientoIVA = porcientoIVA;
            this.estatus = estatus;
            this.idEmpleado = idEmpleado;
        }

        public Factura(DataRow fila)
        {
            _folio = fila.Field<int>("folio");
            _idCliente = fila.Field<int>("idCliente");
            _fecha = fila.Field<DateTime>("fecha");
            _idModoPago = fila.Field<int>("idModoPago");
            _porcientoIVA = fila.Field<int>("porcientoIVA");
            _estatus = fila.Field<int>("estatus");
            _idEmpleado = fila.Field<int>("idEmpleado");
        }
        #endregion

        #region  Funciones
        public void guardar()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            parametros.Add("@folio", this._folio);
            parametros.Add("@idCliente", this._idCliente);
            parametros.Add("@fecha", this._fecha);
            parametros.Add("@idModoPago", this._idModoPago);
            parametros.Add("@porcientoIVA", this._porcientoIVA);
            parametros.Add("@estatus", this._estatus);
            parametros.Add("@idEmpleado", this._idEmpleado);

         try {
                if (_idModoPago > 0)
                {
                    parametros.Add("@idModoPago", this._idModoPago);

                    if (DataBaseHelper.ExecuteNonQuery("dbo.SPCFacturas", parametros) == 0)
                    {
                        throw new CustomException("No se actualizo el registro");
                    }

                }
                else
                { //Insert                  
                    parametros.Add("@estatus", this._estatus);
                    if (DataBaseHelper.ExecuteNonQuery("dbo.SPAFacturas", parametros) == 0)
                    {
                        throw new CustomException("No se creo el registro");
                    }
                }
             }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message.ToString(), ex);
            }
        }
        
        
        #endregion

        #region Metodos Estaticos

        public static void desactivar(int folio)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            parametros.Add("@folio", folio);

            try
            {
                if (DataBaseHelper.ExecuteNonQuery("dbo.SPBFacturas", parametros) == 0)
                {
                    throw new CustomException("No se elimino el registro");
                }
            }
            catch(Exception ex)
            {
                throw new CustomException(ex.Message.ToString());
            }

        }

        public static Factura buscarPorFolio(int folio)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            parametros.Add("@folio", folio);

            DataTable dt = new DataTable();

            DataBaseHelper.Fill(dt, "dbo.SLPFactura", parametros);
            Factura resultado = null;
            foreach(DataRow fila in dt.Rows)
            {
                resultado = new Factura(fila);
                break;
            }

            return resultado;
        }

        public static List<Factura> traerTodos()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            
            DataTable dt = new DataTable();
            try
            {
                DataBaseHelper.Fill(dt, "dbo.SPLFacturas", parametros);
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message.ToString(), ex);
            }
            List<Factura> listado = new List<Factura>();
            foreach(DataRow fila in dt.Rows)
            {
                listado.Add(new Factura(fila));
            }
            return listado;
        }

        #endregion 

    }
}
