using CD;
using CN.Excepciones;
using System;
using System.Collections.Generic;
using System.Data;

namespace CN
{
    public class Rol
    {
        #region Propiedades
        public int idRol { get; }       
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
                   
                    string _descripcion)
        {
            this.idRol = _idRol;
     
            this.descripcion = _descripcion;
        }

        /// <summary>
        /// Constructor para crear un registro
        /// </summary>        
        /// <param name="_nombre">nombre del rol</param>
        /// <param name="_descripcion">descripcion del rol</param>
        public Rol(
                    string _descripcion)
        {            
            
            this.descripcion = _descripcion;
        }


        public Rol(DataRow fila)
        {
            this.idRol = fila.Field<int>("idRol"); 
            this.descripcion = fila.Field<string>("descripcion");
            this.esActivo = fila.Field<bool>("esActivo");
        }
        #endregion

        #region Metodos y Funciones
        public void guardar()
        {
            //Creo un diccionario para guardar los parametros
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            //Al diccionario "parametros" agregamos el nombre del parametro del
            // Store Procedure y su valor (propiedad de la clase correspondiente)            
          
            parametros.Add("@descripcion", this.descripcion);            

            //Si idRol es mayor a 0, significa que es una registro existente, usar un Update            
            if (this.idRol > 0)
            {
                //Agregamos el parametro del id de la tabla utilizado para ubicar el registro
                //a modificar
                parametros.Add("@idRol", this.idRol);
                
                if (DataBaseHelper.ExecuteNonQuery("dbo.SPCRoles", parametros) == 0)
                {
                    throw new CustomException("No se actualizo el registro.");
                }
            }
            else //Si idRol = cero, significa que es una registro nuevo, entonces usar Insert.
            {
                parametros.Add("@esActivo", true);
                if (DataBaseHelper.ExecuteNonQuery("dbo.SPARoles", parametros) == 0)
                {
                    throw new CustomException("No se actualizo el registro.");
                }
            }            
        }

        public static void desactivar(int idRol)
        {
            if (idRol > 0)
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("@idRol", idRol);
                
                try
                {
                    if (DataBaseHelper.ExecuteNonQuery("dbo.SPBRoles", parametros) == 0)
                    {
                        throw new CustomException("No se elimino el registro.");
                    }
                }
                catch (Exception ex)
                {
                    throw new CustomException(ex.Message.ToString(), ex);
                }
            }
        }

        public static Rol traerPorId(int _idRol)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@idRol", _idRol);

            DataTable dt = new DataTable();
            
            try
            {
                DataBaseHelper.Fill(dt, "dbo.SPLRol", parametros);
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message.ToString(), ex);
            }

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

            try
            {
                DataBaseHelper.Fill(dt, "dbo.SPLRol", parametros);
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message.ToString(), ex);
            }

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

            try
            {
                DataBaseHelper.Fill(dt, "dbo.SPLRol", parametros);
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message.ToString(), ex);
            }
            
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