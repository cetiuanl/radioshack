using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #endregion Constructores
        #region Funciones
        #endregion Funciones
        #region MetodosEstaticos
        public static bool eliminar(int idEmpleado)
            {
            return false; //TODO: Implementar CD y Stoe Procedure;
            }
        #endregion MetodosEstaticos
    }
}
