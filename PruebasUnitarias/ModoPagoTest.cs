using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CN;

namespace PruebasUnitarias
{
    [TestClass]
    public class ModoPagoTest
    {
        [TestMethod]
        public void Guardar()
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

        //[ExpectedException(typeof(ArgumentException))]

    }
}
