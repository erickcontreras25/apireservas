using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reserva.Domain;
using Reserva.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestP
{
    [TestClass]
    public class CanchaTest
    {
        [TestMethod]
        public void validar()
        {
            var cancha = DataCancha();
            CanchaDomain canchaDomain = new CanchaDomain();
            var respuesta = canchaDomain.AgregarCancha(cancha);

            Assert.AreEqual("El precio no puede ser nulo.", respuesta);
        }

        [TestMethod]
        public void validarTamanio()
        {
            var cancha = DataCancha2();
            CanchaDomain canchaDomain = new CanchaDomain();
            var respuesta = canchaDomain.AgregarCancha(cancha);

            Assert.AreEqual("El tamanio de la cancha no puede ser diferente de pequenio, mediana o grande.", respuesta);
        }

        [TestMethod]
        public void validarIdComepljo()
        {
            var cancha = DataCancha1();
            CanchaDomain canchaDomain = new CanchaDomain();
            var respuesta = canchaDomain.AgregarCancha(cancha);

            Assert.AreEqual("Necesita el id del Complejo", respuesta);
        }

        public Cancha DataCancha()
        {
            Cancha cancha = new Cancha();
            cancha.precio = 0;
            cancha.tamanioCancha = "hola";
            cancha.idComplejo = 0;

            return cancha;
        }
        public Cancha DataCancha1()
        {
            Cancha cancha = new Cancha();
            cancha.precio = 80;
            cancha.tamanioCancha = "hola";
            cancha.idComplejo = 0;

            return cancha;
        }
        public Cancha DataCancha2()
        {
            Cancha cancha = new Cancha();
            cancha.precio = 5;
            cancha.tamanioCancha = "hola";
            cancha.idComplejo = 2;

            return cancha;
        }
        public Cancha DataCancha3()
        {
            Cancha cancha = new Cancha();
            cancha.precio = 5;
            cancha.tamanioCancha = "hola";
            cancha.idComplejo = 2;

            return cancha;
        }
    }
}
