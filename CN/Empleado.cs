using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using CD;
using CN.Excepciones;


namespace CN
{
    public class Empleado
    {
        #region Propiedades

        private int _idEmpleado;
        
        public int idEmpleado
        {
            get { return _idEmpleado; }
            set { _idEmpleado = value; } //Guarda el valor en _idEmpleado;
        }

        private string _nombreCompleto;

        public string nombreCompleto
        {
            get { return _nombreCompleto; }
            set { _nombreCompleto = value; }
        }

        private DateTime _fechaIngreso;

        public DateTime fechaIngreso
        {
            get { return _fechaIngreso; }
            set { _fechaIngreso = value; }
        }

        private int _idRol;

        public int idRol
        {
            get { return _idRol; }
            set { _idRol = value; }
        }

        private bool _esActivo;

        public bool esActivo
        {
            get { return _esActivo; }
            set { _esActivo = value; }
        }

        private DateTime _fechaNacimiento;

        public DateTime fechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }


        private string _correoElectronico;

        public string correoElectronico
        {
            get { return _correoElectronico; }
            set { _correoElectronico = value; }
        }

        private string _contrasena;

        public string contrasena
        {
            get { return _contrasena; }
            set { _contrasena = value; }
        }
        #endregion Propiedades
        #region Constructores
        public Empleado(int idEmpleado,string nombreCompleto, DateTime fechaIngreso, int idRol, bool esActivo, 
                        DateTime fechaNacimiento,string correoElectronico, string contrasena)//TODO: Peniente Revisar
        {
            this.idEmpleado = idEmpleado;
            this.nombreCompleto = nombreCompleto;
            this.fechaIngreso = fechaIngreso;
            this.idRol = idRol;
            this.esActivo = esActivo;
            this.fechaNacimiento = fechaNacimiento;
            this.correoElectronico = correoElectronico;
            this.contrasena = contrasena;
        }

        public Empleado(DataRow fila) //DataRow
        {
            _idEmpleado = fila.Field<int>("idEmpleado");
            _nombreCompleto = fila.Field<string>("nombreCompleto");
            _fechaIngreso = fila.Field<DateTime>("fechaIngreso");
            _idRol = fila.Field<int>("idRol");
            _esActivo = fila.Field<bool>("esActivo");
            _fechaNacimiento = fila.Field<DateTime>("fechaNacimiento");
            _correoElectronico = fila.Field<string>("correoElectronico");
            _contrasena = fila.Field<string>("contrasena");
        }
        #endregion Constructores
        #region Funciones
        public void guardar()//SPI
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@nombreCompleto", this._nombreCompleto);
            parametros.Add("@fechaIngreso", this._fechaIngreso);
            parametros.Add("@idRol", this._idRol);
            parametros.Add("@fechaNacimiento", this._fechaNacimiento);
            parametros.Add("@correoElectronico", this._correoElectronico);
            parametros.Add("@contrasena", this._contrasena);

            try
            {   
                if (_idEmpleado > 0) //SP - Update de registros
                {
                    parametros.Add("@idEmpleado", this._idEmpleado); //Se agrega este parametro dentro del if ,ya que no se necesita en el insert
                    if (DataBaseHelper.ExecuteNonQuery("dbo.SPCEmplados", parametros) == 0)
                    {
                        throw new CustomException("No se actualizo el registro.");
                    }
                }
                else //SP - Insert
                {
                    parametros.Add("@esActivo", this._esActivo); //Se agrega este parametro dentro del if ,ya que no se necesita en el update
                    if (DataBaseHelper.ExecuteNonQuery("dbo.SPAEmplados", parametros) == 0)
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
        #endregion Funciones

        #region MetodosEstaticos
        public static void desactivar(int idEmpleado) //EsActivo pasa a 0
            {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@idEmpleado", idEmpleado);

            try
            {
                if (DataBaseHelper.ExecuteNonQuery("dbo.SPBEmplados", parametros) == 0)
                {
                    throw new CustomException("No se elimino el registro.");
                }
            }
            catch (Exception ex)
            {

                throw new CustomException(ex.Message.ToString(), ex);
            }

        }

        public static Empleado iniciarSesion(string correo, string contrasena)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@correo", correo);
            parametros.Add("@contrasena", contrasena);
            
            DataTable dt = new DataTable();

            try
            {
                DataBaseHelper.Fill(dt, "dbo.SPIniciarSesion", parametros);
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message.ToString(), ex);
            }
            Empleado resultado = null;

            foreach (DataRow fila in dt.Rows) //Recorremos el SELECT por filas
            {
                resultado = new Empleado(fila);
                break;
            }
            return resultado;
        }

        public static Empleado buscarPorId(int idEmpleado) //Consulta de datos SELECT 
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@idEmpleado", idEmpleado);

            DataTable dt = new DataTable(); //Registros SQL, se usa cuando tenemos un SELECT * FROM, se guarda en un datatable

            try
            {
                DataBaseHelper.Fill(dt, "dbo.SPLEmpleado", parametros);
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message.ToString(), ex);
            }
            Empleado resultado = null;

            foreach (DataRow fila in dt.Rows) //Recorremos el SELECT por filas
            {
                resultado = new Empleado(fila);
                break;
            }
            return resultado;
        }

        public static List<Empleado> traerTodos(bool filtrarSoloActivos = false) //Consulta el listado embase a los activos o no activos
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            if (filtrarSoloActivos)
            {
                parametros.Add("@esActivo", true);
            }

            DataTable dt = new DataTable(); //Registros SQL, se usa cuando tenemos un SELECT * FROM, se guarda en un datatable

            try
            {
                DataBaseHelper.Fill(dt, "dbo.SPLEmpleado", parametros);
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message.ToString(), ex);
            }

            List<Empleado> listado = new List<Empleado>();

            foreach (DataRow fila in dt.Rows) //Recorremos el SELECT por filas
            {
                listado.Add(new Empleado(fila));
            }
            return listado;
        }

        #endregion MetodosEstaticos
    }
}
