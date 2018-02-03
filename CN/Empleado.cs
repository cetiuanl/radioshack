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
    class Empleado
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
            get { return nombreCompleto; }
            set { nombreCompleto = value; }
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

        public Empleado(DataRow fila)
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
        public CustomException guardar()//SPI
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
                if (_idEmpleado > 0) //SP - Update
                {
                    parametros.Add("@idEmpleado", this._idEmpleado); //Se agrega este parametro dentro del if ,ya que no se necesita en el insert
                    if (CD.DataBaseHelper.ExecuteNonQuery("dbo.SPCEmplados", parametros) == 0)
                    {
                        return new CustomException("No se actualizo el registro.");
                    }
                }
                else //SP - Insert
                {
                    parametros.Add("@esActivo", this._esActivo); //Se agrega este parametro dentro del if ,ya que no se necesita en el update
                    if (CD.DataBaseHelper.ExecuteNonQuery("dbo.SPAEmplados", parametros) == 0)
                    {
                        return new CustomException("No se creo el registro.");
                    }
                }
            }
            catch (Exception ex)
            {
                return new CustomException(ex.Message.ToString(), ex);
            }
                
            return null;
        }
        public bool desactivar()
        {
            return false;
        }
        public bool eliminar()
        {
            return false;
        }
        #endregion Funciones
        #region MetodosEstaticos
        public static bool eliminar(int idEmpleado)
            {
            return false; //TODO: Implementar CD y Stored Procedure;
            }
        #endregion MetodosEstaticos
    }
}
