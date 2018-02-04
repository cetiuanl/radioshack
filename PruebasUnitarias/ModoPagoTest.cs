using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CN;
using System.Collections.Generic;
using System.Linq;

namespace PruebasUnitarias
{
    [TestClass]
    public class ModoPagoTest
    {
        [TestMethod]
        public void ModoPagoGuardar()
        {
            bool result = false;
            string mensaje = "";

            try
            {
                ModoPago pago = new ModoPago(0, "Test", "Test", true);
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
        public void ModoPagoTraerTodos()
        {
            bool result = false;
            string mensaje = "";

            List<ModoPago> listado = null;
            try
            {
                listado = ModoPago.traerTodos(true);
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
        public void ModoPagoDesactivar()
        {
            bool result = false;
            string mensaje = "";

            ModoPago pago = null;
            try
            {
                pago = ModoPago.traerTodos(true).First();
                ModoPago.desactivar(pago.idModoPago);
                result = true;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message.ToString();
                Assert.IsNotNull(ex, mensaje);
            }

            Assert.IsTrue(result, "Modificacion correct!");
        }

        //[ExpectedException(typeof(ArgumentException))]

    }
}
