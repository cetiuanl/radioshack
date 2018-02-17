﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CD;
using CN.Excepciones;

namespace CN
{
    class Producto
    {
        #region PROPIEDADES
        private int _idProducto;

        public int idProducto
        {
            get { return _idProducto; }
            set { _idProducto = value; }
        }

        private string _nombre;

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _marca;

        public string marca
        {
            get { return _marca; }
            set { _marca = value; }
        }

        private double _precio; //TODO: pendiente revisar

        public double precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        private double _inventario; //TODO: pendiente revisar

        public double inventario
        {
            get { return _inventario; }
            set { _inventario = value; }
        }

        private int _idCategoria;

        public int idCategoria
        {
            get { return _idCategoria; }
            set { _idCategoria = value; }
        }

        private bool _esActivo;

        public bool esActivo
        {
            get { return _esActivo; }
            set { _esActivo = value; }
        }
        #endregion

        #region CONSTRUCTORES
        public Producto(int idProducto, string nombre, string marca,
            double precio, double inventario, int idCategoria, bool esActivo)
        {
            this.idProducto = idProducto;
            this.nombre = nombre;
            this.marca = marca;
            this.precio = precio;
            this.inventario = inventario;
            this.idCategoria = idCategoria;
            this.esActivo = esActivo;

        }

        public Producto(DataRow fila)
        {
            _idProducto = fila.Field < int > ("idProducto");
            _nombre = fila.Field < string > ("nombre");
            _marca = fila.Field < string > ("marca");
            _precio = fila.Field < double > ("precio");
            _inventario = fila.Field < double > ("inventario");
            _idCategoria = fila.Field < int > ("idCategoria");
            _esActivo = fila.Field < bool > ("esActivo");

        }
        #endregion

        #region FUNCIONES
        public void guardar()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@nombre", this._nombre);
            parametros.Add("@marca", this._marca);
            parametros.Add("@precio", this._precio);
            parametros.Add("@inventario", this._inventario);
            parametros.Add("@idCategoria", this._idCategoria);

            try
            {
                if (_idProducto > 0)
                {//Update
                    parametros.Add("@idProducto", this._idProducto);
                    if (DataBaseHelper.ExecuteNonQuery("dbo.SPCProductos", parametros) == 0)
                    {
                        throw new CustomException("No se actualizo el registro.");
                    }
                }
                else
                {//Insert
                    parametros.Add("@esActivo", this.esActivo);
                    if (DataBaseHelper.ExecuteNonQuery("dbo.SPCProductos", parametros) == 0)
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

        #region METODOS ESTATICOS

        public static void desactivar(int idProducto)
        {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@idProducto", idProducto);

                try
                {
                    if (DataBaseHelper.ExecuteNonQuery("dbo.SPBProductos", parametros) == 0)
                        {
                            throw new CustomException("No se elimino el registro.");
                        }
                    }
                catch (Exception ex)
                {
                    throw new CustomException(ex.Message.ToString(), ex);
                }
            }

        public static Producto buscarPorId(int idProducto)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@idProducto", idProducto);

            DataTable dt = new DataTable();

            try
            {
                DataBaseHelper.Fill(dt, "dbo.SPLProductos", parametros);
            }
            catch (Exception ex)
            {

                throw new CustomException(ex.Message.ToString(),ex);
            }

            Producto resultado = null;

            foreach (DataRow fila in dt.Rows)
            {
                resultado = new Producto(fila);
                break;
            }
            return resultado;
        }

        public static List<Producto> traerTodos(bool filtrarSoloActivos = false)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            if (filtrarSoloActivos)
            {
                parametros.Add("@esActivo", true);
            }

            DataTable dt = new DataTable();

            try
            {
                DataBaseHelper.Fill(dt, "dbo.SPLProductos", parametros);
            }
            catch (Exception ex)
            {

                throw new CustomException(ex.Message.ToString(), ex);
            }
            List<Producto> listado = new List<Producto>();

            foreach (DataRow fila in dt.Rows)
            {
                listado.Add(new Producto(fila));
            }

            return listado;
        }


        #endregion
    }
}
