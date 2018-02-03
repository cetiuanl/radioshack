using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN
{
    class CategoriasProducto
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
        #endregion
        #region Funciones
        #endregion
        #region Metodos estaticos
        public static bool eliminar (int id)
        {
            return false;
        }
        #endregion
    }
}
