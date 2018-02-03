using System.Collections.Generic;
using System.Data;
using CD;
using CN.Excepciones;
using System;

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
                         string nombre,
                         string detalles
                        , bool esActivo)
        {
            _idModoPago = idModoPago;
            _nombre = nombre;
            _detalles = detalles;
            _esActivo = esActivo;
        }

        public ModoPago(DataRow fila)
        {
            _idModoPago = fila.Field<int>("idModoPago");
            _nombre = fila.Field<string>("nombre");
            _detalles = fila.Field<string>("detalles");
            _esActivo = fila.Field<bool>("esActivo");
        }
        #endregion

        #region Funciones
        public void guardar()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            
            parametros.Add("@nombre", this._nombre);
            parametros.Add("@detalles", this._detalles);

            try
            {
                if (_idModoPago > 0)
                {
                    parametros.Add("@idModoPago", this._idModoPago);

                    if (DataBaseHelper.ExecuteNonQuery("dbo.SPCModoPago", parametros) == 0)
                    {
                        throw new CustomException("No se actualizo el registro.");
                    }
                }
                else
                {
                    parametros.Add("@esActivo", this._esActivo);

                    if (DataBaseHelper.ExecuteNonQuery("dbo.SPAModoPago", parametros) == 0)
                    {
                        throw new CustomException("No se creo el registro.");
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

        public static bool desactivar(int idModoPago)
        {
            return false;//TODO: Implementar CD y Store Procedure
        }


        #endregion





















    }
}
