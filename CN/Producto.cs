using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #endregion

        #region FUNCIONES

        #endregion

        #region METODOS ESTATICOS

        public static bool eliminar(int idProducto)
        {
            return false;//TODO Implementar CD y Store Procedure
        }
        #endregion
    }
}
