using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN {
    class Cliente {
        #region Propiedades
        private int _idCliente;

        public int idCliente
        {
            get { return _idCliente; }
            //set { _idCliente = value; }
        }

        private String _nombre;

        public String nombre
        {
            get { return _nombre; }
            //set { _nombre = value; }
        }

        private String _apellidos;

        public String apellidos
        {
            get { return _apellidos; }
            //set { _apellidos = value; }
        }

        private String _domicilio;

        public String domicilio
        {
            get { return _domicilio; }
            //set { _domicilio = value; }
        }

        private DateTime _fechaNacimiento;

        public DateTime fechaNacimiento
        {
            get { return _fechaNacimiento; }
            //set { _fechaNacimiento = value; }
        }

        private String _telefono;

        public String telefono
        {
            get { return _telefono; }
            //set { _telefono = value; }
        }

        private String _correo;

        public String correo
        {
            get { return _correo; }
            //set { _correo = value; }
        }

        private String _RFC;

        public String RFC
        {
            get { return _RFC; }
            //set { _RFC = value.ToUpper(); }
        }

        private bool _esActivo;

        public bool esActivo
        {
            get { return _esActivo; }
            //set { _esActivo = value; }
        }
        #endregion 

        #region Constructores
        public Cliente (int idCliente, string nombre, string apellidos, string domicilio, 
            DateTime fechaNacimiento, string telefono, string correo, string RFC, bool esActivo) {
            _idCliente = idCliente;
            _nombre = nombre;
            _apellidos = apellidos;
            _domicilio = domicilio;
            _fechaNacimiento = fechaNacimiento;
            _telefono = telefono;
            _correo = correo;
            _RFC = RFC;
            _esActivo = esActivo;
        }
        #endregion

        #region Funciones

        #endregion

        #region Metodos Estaticos

        public static bool eliminar(int idClinte) {
            return false; //TODO: Implementar CD Y Store Procedure
        }

        #endregion





    }
}
