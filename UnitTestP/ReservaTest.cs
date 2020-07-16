using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reserva.Domain;
using Reserva.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestP
{
    [TestClass]
    public class ReservaTest
    {
        [TestMethod]
        public void validar()
        {
            var dataReserva = DataReserva1();
            ReservacionDomain reservaDomain = new ReservacionDomain();
            var respuesta = reservaDomain.AgregarReservacion(dataReserva);

            Assert.AreEqual("La cancha no puede ser nulo.", respuesta);
        }

        [TestMethod]
        public void validarFecha1()
        {
            var dataReserva = DataReserva2();
            ReservacionDomain reservaDomain = new ReservacionDomain();
            var respuesta = reservaDomain.AgregarReservacion(dataReserva);

            Assert.AreEqual("La hora final no puede ser mayor que la inicial.", respuesta);
        }

        [TestMethod]
        public void validarFecha2()
        {
            var dataReserva = DataReserva();
            ReservacionDomain reservaDomain = new ReservacionDomain();
            var respuesta = reservaDomain.AgregarReservacion(dataReserva);

            Assert.AreEqual("La hora final no puede ser igual que la inicial.", respuesta);
        }

        [TestMethod]
        public void validarUsuario()
        {
            var dataReserva = DataReserva4();
            ReservacionDomain reservaDomain = new ReservacionDomain();
            var respuesta = reservaDomain.AgregarReservacion(dataReserva);

            Assert.AreEqual("El usuario no puede ser nulo.", respuesta);
        }

        [TestMethod]
        public void validarCantidadHoras()
        {
            var dataReserva = DataReserva5();
            ReservacionDomain reservaDomain = new ReservacionDomain();
            var respuesta = reservaDomain.AgregarReservacion(dataReserva);

            Assert.AreEqual("No puede reservar por mas de 4 horas.", respuesta);
        }


        public Reservaciones DataReserva()
        {
            Reservaciones reserva = new Reservaciones();
            reserva.userId = "";
            reserva.idCancha = 0;
            reserva.horaInicial = new DateTime(10);
            reserva.horaFinal = new DateTime(10);

            return reserva;
        }

        public Reservaciones DataReserva1()
        {
            Reservaciones reserva = new Reservaciones();
            reserva.userId = "";
            reserva.idCancha = 0;
            reserva.horaInicial = new DateTime(10);
            reserva.horaFinal = new DateTime(11);

            return reserva;
        }

        public Reservaciones DataReserva2()
        {
            Reservaciones reserva = new Reservaciones();
            reserva.horaInicial = new DateTime(10);
            reserva.horaFinal = new DateTime(09);

            return reserva;
        }
        public Reservaciones DataReserva3()
        {
            Reservaciones reserva = new Reservaciones();
            reserva.horaInicial = new DateTime(10);
            reserva.horaFinal = new DateTime(15);

            return reserva;
        }
        public Reservaciones DataReserva4()
        {
            Reservaciones reserva = new Reservaciones();
            reserva.userId = "";
            reserva.idCancha = 2;
            reserva.horaInicial = new DateTime(10);
            reserva.horaFinal = new DateTime(11);

            return reserva;
        }
        public Reservaciones DataReserva5()
        {
            Reservaciones reserva = new Reservaciones();
            reserva.idCancha = 2;
            reserva.userId = "bkbxhdr";
            reserva.horaInicial = new DateTime().AddHours(10);
            reserva.horaFinal = new DateTime().AddHours(15);

            return reserva;
        }
    }
}
