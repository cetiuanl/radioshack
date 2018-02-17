using System;
using System.Collections.Generic;
using System.Data;
using CD;
using CN.Excepciones;

namespace CN
{
    public class CategoriasProducto
    {
        #region Propiedades

        private int _idCategoria;

        public int idCategoria
        {
            get { return _idCategoria; }
            set { _idCategoria = value; }
        }

        private string _nombre;

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _descripcion;

        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private bool _esActivo;

        public bool esActivo
        {
            get { return _esActivo; }
            set { _esActivo = value; }
        }
        #endregion
        #region Constructores
        public CategoriasProducto(int idCategoria, string nombre, string detalles, bool esActivo)
        {
            this.idCategoria = idCategoria;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.esActivo = esActivo;
        }

        public CategoriasProducto(DataRow fila) //manejar todo como objeto.
        {
            _idCategoria = fila.Field<int>("idCategoria");
            _nombre = fila.Field<string>("nombre");
            _descripcion = fila.Field<string>("descripcion");
            _esActivo = fila.Field<bool>("esActivo");
        }
        #endregion
        #region Funciones
        public void guardar()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            
            parametros.Add("@nombre",this._nombre);
            parametros.Add("@descripcion", this._descripcion);

            try
            {
                if (_idCategoria > 0)
                {
                    parametros.Add("@idcategoria", this._idCategoria);

                    if (DataBaseHelper.ExecuteNonQuery("dbo.SPCCategoriasProducto", parametros) == 0)
                    {
                        throw new CustomException("mensaje");
                    }
                    //regresa cantidad de filas modificadas
                } //funcion para cuando quiero regresar un update (modificar un registro)

                else //Para hacer un insert
                {
                    parametros.Add("@esActivo", this._esActivo);
                    if (DataBaseHelper.ExecuteNonQuery("dbo.SPACategoriasProducto", parametros) == 0)
                    {
                        throw new CustomException("No se creo el registro.");
                    }
                }
            }
            catch ( Exception ex)
            {

                throw new CustomException(ex.Message.ToString(),ex);
            }
        }





        #endregion
        #region Metodos estaticos
        public static void desactivar(int idCategoria)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@idcategoria", idCategoria);
            try
            {
                if (DataBaseHelper.ExecuteNonQuery("dbo.SPBCategoriasProducto", parametros) == 0)
                {
                    throw new CustomException("No se ha eliminado el registro.");
                }
            }
            catch (Exception ex)
            {

                throw new CustomException(ex.Message.ToString(),ex);
            }
        }

        public static CategoriasProducto buscarPorID(int idCategoria)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@idCategoria", idCategoria);
            DataTable dt = new DataTable();

            try
            {
                DataBaseHelper.Fill(dt, "dbo.SPLCategoriasProducto", parametros);
            }
            catch(Exception ex) {
                throw new CustomException(ex.Message.ToString(), ex);
            }
            CategoriasProducto resultado = null;
            foreach(DataRow fila in dt.Rows)
            {
                resultado = new CategoriasProducto(fila);
                break;
            }
            return resultado;
        }
        public static List<CategoriasProducto> traerTodos(bool filtrarSoloActivos = false)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            if (filtrarSoloActivos)
            {
                parametros.Add("@esActivo", true);

            }
            DataTable dt = new DataTable();

            try
            {
                DataBaseHelper.Fill(dt, "dbo.SPLCategoriasProducto", parametros);
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message.ToString(), ex);
            }
            List<CategoriasProducto> listado = new List<CategoriasProducto>();
            foreach(DataRow fila in dt.Rows)
            {
                listado.Add(new CategoriasProducto(fila));
            }
            return listado;
        }


        #endregion
    }


}

