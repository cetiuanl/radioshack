using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN
{
    class Factura
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
            get { return porcientoIVA; }
            set { porcientoIVA = value; }
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
        #endregion

        #region  Funciones

        #endregion

        #region Metodos Estaticos

        public static bool eliminar (int folio)
        {
            return false;//TODO: Implementar CD y Store Procedure
        }

        #endregion 

    }
}
