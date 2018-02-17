using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CD;
using CN.Excepciones;

namespace CN {
    public class Cliente {
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

        public Cliente (DataRow fila) {
            _idCliente = fila.Field<int>("idCliente");
            _nombre = fila.Field<string>("nombre");
            _apellidos = fila.Field<string>("apellidos");
            _domicilio = fila.Field<string>("domicilio");
            _fechaNacimiento = fila.Field<DateTime>("fechaNacimiento");
            _telefono = fila.Field<string>("telefono");
            _correo = fila.Field<string>("correo");
            _RFC = fila.Field<string>("RFC");
            _esActivo = fila.Field<bool>("esActivo");
        }

        #endregion

        #region Funciones

        public void guardar() {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            
            parametros.Add("@nombre", this._nombre);
            parametros.Add("@apellidos", this._apellidos);
            parametros.Add("@domicilio", this._domicilio);
            parametros.Add("@fechaNacimiento", this._fechaNacimiento);
            parametros.Add("@telefono", this._telefono);
            parametros.Add("@correo", this._correo);
            parametros.Add("@RFC", this._RFC);

            try {
                if (_idCliente > 0)
                {
                    //Update
                    parametros.Add("@idCliente", this._idCliente);
                    if (DataBaseHelper.ExecuteNonQuery("dbo.SPCClientes", parametros) == 0)
                    {
                        throw new CustomException("No se actualizo el registro");
                    }
                }
                else {
                    //Insert
                    parametros.Add("@esActivo", this._esActivo);
                    if (DataBaseHelper.ExecuteNonQuery("dbo.SPAClientes", parametros) == 0)
                    {
                        throw new CustomException("No se creo el registro");
                    }
                }
            }
            catch (Exception ex) {
                throw new CustomException(ex.Message.ToString(), ex);
            }
        }

        #endregion

        #region Metodos Estaticos

        public static void desactivar(int idCliente, bool esActivo = false) {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@idCliente", idCliente);
            parametros.Add("@esActivo", esActivo);
            try
            {
                if (DataBaseHelper.ExecuteNonQuery("dbo.SPBClientes", parametros) == 0)
                {
                    throw new CustomException("No se elimino el registro");
                }
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message.ToString(), ex);
            }
        }

        public static Cliente buscarPorId(int idCliente) {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@idCliente", idCliente);
            DataTable dt = new DataTable();
            try {
                DataBaseHelper.Fill(dt, "dbo.SPLClientes", parametros);
            }
            catch (Exception ex) {
                throw new CustomException(ex.Message.ToString(), ex);
            }
            Cliente resultado = null;
            foreach (DataRow fila in dt.Rows) {
                resultado = new Cliente(fila);
                break;
            }
            return resultado;
        }

        public static List<Cliente> traerTodos(bool filtrarSoloActivos = false) {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            if (filtrarSoloActivos) {
                parametros.Add("@esActivo", true);
            }
            DataTable dt = new DataTable();
            try {
                DataBaseHelper.Fill(dt, "dbo.SPLClientes", parametros);
            }
            catch (Exception ex) {
                throw new CustomException(ex.Message.ToString(), ex);
            }
            List<Cliente> listado = new List<Cliente>();
            foreach (DataRow fila in dt.Rows) {
                listado.Add(new Cliente(fila));
            }
            return listado;
        }



        #endregion





    }
}
