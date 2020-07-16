using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reserva.Domain;
using Reserva.Models;

namespace UnitTestP
{
    [TestClass]
    public class ComplejoTest
    {
        [TestMethod]
        public void validar()
        {
            var complejo = DataComplejo();
            ComplejoDomain complejoDomain = new ComplejoDomain();
            var respuesta = complejoDomain.AgregarComplejo(complejo);

            Assert.AreEqual("El nombre no puede ser nulo.", respuesta);
        }

        //[TestMethod]
        //public void validarNombre()
        //{
        //    var dataComplejo = DataComplejo();
        //    ComplejoDomain complejoDomain = new ComplejoDomain();
        //    var respuesta = complejoDomain.AgregarComplejo(dataComplejo);

        //    Assert.AreEqual("")
        //}

        public Complejo DataComplejo()
        {
            Complejo complejo = new Complejo();
            complejo.nombre = "";
            complejo.parqueo = true;

            return complejo;
        }
    }
}
