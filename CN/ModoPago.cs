using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN
{
    class ModoPago
    {
        #region Propiedades
        private int _idModoPago;

        public int idModoPago
        {
            get
            {
                return _idModoPago;
            }
        }

        private string _nombre;

        public string nombre
        {
            get
            {
                return _nombre;
            }
        }

        private string _detalles;

        public string detalles
        {
            get { return _detalles; }           
        }

        private bool _esActivo;

        public bool esActivo
        {
            get { return _esActivo; }
        }
                
        #endregion

        #region Constructores
        public ModoPago(int idModoPago,
                         string detalles
                        , bool esActivo)
        {
            _idModoPago = idModoPago;
            _detalles = detalles;
            _esActivo = esActivo;
        }
        #endregion

        #region Funciones

        #endregion

        #region Metodos Estaticos

        public static bool eliminar(int idModoPago)
        {
            return false;//TODO: Implementar CD y Store Procedure
        }


        #endregion





















    }
}
