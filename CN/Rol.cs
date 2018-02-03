using CapaDatos;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocios
{
    public class Rol
    {
        #region Propiedades
        public int idRol { get; }
        public string nombre { get; }
        public string descripcion { get; }
        public bool esActivo { get; }
        #endregion
        
        #region Constructores
        /// <summary>
        /// Constructor vacio
        /// </summary>
        public Rol()
        {

        }
        /// <summary>
        /// Constructor para modificar un registro
        /// </summary>
        /// <param name="_idRol">Identificador a modificar</param>
        /// <param name="_nombre">nombre del rol</param>
        /// <param name="_descripcion">descripcion del rol</param>
        public Rol(int _idRol,
                    string _nombre,
                    string _descripcion)
        {
            this.idRol = _idRol;
            this.nombre = _nombre;
            this.descripcion = _descripcion;
        }

        /// <summary>
        /// Constructor para crear un registro
        /// </summary>        
        /// <param name="_nombre">nombre del rol</param>
        /// <param name="_descripcion">descripcion del rol</param>
        public Rol(string _nombre,
                    string _descripcion)
        {            
            this.nombre = _nombre;
            this.descripcion = _descripcion;
        }


        public Rol(DataRow fila)
        {
            this.idRol = fila.Field<int>("idRol");
            this.nombre = fila.Field<string>("nombre");
            this.descripcion = fila.Field<string>("descripcion");
            this.esActivo = fila.Field<bool>("esActivo");
        }
        #endregion

        #region Metodos y Funciones
        public bool guardar()
        {
            //Creo un diccionario para guardar los parametros
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            //Al diccionario "parametros" agregamos el nombre del parametro del
            // Store Procedure y su valor (propiedad de la clase correspondiente)            
            parametros.Add("@nombre", this.nombre);
            parametros.Add("@descripcion", this.descripcion);            

            //Si idRol es mayor a 0, significa que es una registro existente, usar un Update            
            if (this.idRol > 0)
            {
                //Agregamos el parametro del id de la tabla utilizado para ubicar el registro
                //a modificar
                parametros.Add("@idRol", this.idRol);
                // Si el valor que regresa nonQuery es igual a 1, entonces es TRUE
                return DataBaseHelper.ExecuteNonQuery("dbo.SPURol", parametros) == 1;
            }
            else //Si idRol = cero, significa que es una registro nuevo, entonces usar Insert.
            {
                return DataBaseHelper.ExecuteNonQuery("dbo.SPIRol", parametros) == 1;
            }
        }
        public static bool desactivar(int _idRol)
        {
            if (_idRol > 0)
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("@idRol", _idRol);

                return DataBaseHelper.ExecuteNonQuery("dbo.SPDRol", parametros) == 1;
            }
            else {
                return false;
            }
        }
        public static Rol traerPorId(int _idRol)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@idRol", _idRol);

            DataTable dt = new DataTable();
            DataBaseHelper.Fill(dt, "dbo.SPSRoles", parametros);
            Rol oResultado = new Rol();

            foreach (DataRow item in dt.Rows)
            {
                oResultado = new Rol(item);
                break;
            }
            return oResultado;
        }
        public static List<Rol> traerTodos()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            DataTable dt = new DataTable();
            DataBaseHelper.Fill(dt, "dbo.SPSRoles", parametros);

            List<Rol> listado = new List<Rol>();

            foreach (DataRow item in dt.Rows)
            {
                listado.Add(new Rol(item));
            }

            return listado;
        }
        public static List<Rol> traerActivos()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@esActivo", true);


            DataTable dt = new DataTable();
            DataBaseHelper.Fill(dt, "dbo.SPSRoles", parametros);

            List<Rol> listado = new List<Rol>();

            foreach (DataRow item in dt.Rows)
            {
                listado.Add(new Rol(item));
            }

            return listado;
        }
        #endregion
    }
}