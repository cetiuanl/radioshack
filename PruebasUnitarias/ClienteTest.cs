using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CN;
using System.Collections.Generic;
using System.Linq;

namespace PruebasUnitarias
{
    [TestClass]
    public class ClienteTest
    {
        [TestMethod]
        public void ClienteGuardar()
        {
            bool result = false;
            string mensaje = "";

            try
            {
                Cliente pago = new Cliente(0, "nombre", "apellidos", "domicilio", DateTime.Today, "0000000", "correo@correo.com", "RFC000000", true);
                pago.guardar();
                result = true;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message.ToString();
            }

            Assert.IsTrue(result, mensaje);
        }
        [TestMethod]
        public void ClienteTraerTodos()
        {
            bool result = false;
            string mensaje = "";

            List<Cliente> listado = null;
            try
            {
                listado = Cliente.traerTodos(true);
                result = (listado.Count > 0);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message.ToString();
                Assert.IsNotNull(ex, mensaje);
            }

            Assert.IsTrue(result, mensaje);
        }
        [TestMethod]
        public void ClienteDesactivar()
        {
            bool result = false;
            string mensaje = "";

            Cliente pago = null;
            try
            {
                pago = Cliente.traerTodos().First();
                Cliente.desactivar(pago.idCliente);
                result = true;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message.ToString();
                Assert.IsNotNull(ex, mensaje);
            }

            Assert.IsTrue(result, "Modificacion correct!");
        }
    }
}
