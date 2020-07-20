using NUnit.Framework;
using System.Collections.Generic;
using Library;


namespace Library.Test
{
    public class MontaniaTest
    {

        private Viajero viajero;
        private Montania montania;

        [SetUp]
        public void Setup()
        {
            viajero = new ViajeroComun("123","Juan");
            montania = new Montania(1);
        }      

        [Test]
        public void TestCantidadDeEntradasUnaEntrada()
        {
            Assert.AreEqual(1,montania.CantidadDeEntradas(viajero));
        }  

        [Test]
        public void TestCantidadDeEntradasCincoEntradas()
        {
            montania.CantidadDeEntradas(viajero);
            montania.CantidadDeEntradas(viajero);
            montania.CantidadDeEntradas(viajero);
            montania.CantidadDeEntradas(viajero);
            Assert.AreEqual(5,montania.CantidadDeEntradas(viajero));
        }

        [Test]
        public void TestAccion()
        {
            montania.Accion(viajero);
            montania.Accion(viajero);
            montania.Accion(viajero);
            montania.Accion(viajero);
            Assert.AreEqual(10,viajero.PuntosAcumulados);
        }     

        [Test]
        public void TestAccionConValorPrevio()
        {
            viajero.PuntosAcumulados=40;
            montania.Accion(viajero);
            montania.Accion(viajero);
            montania.Accion(viajero);
            montania.Accion(viajero);
            Assert.AreEqual(50,viajero.PuntosAcumulados);
        }    

        [Test]
        public void TestDisponibilidadUno()
        {
            Montania montania2 = new Montania(4);
            Assert.AreEqual(4,montania2.Disponibilidad);
        }

        [Test]
        public void TestDisponibilidadValorNegativo()
        {
            Montania montania2;
            Assert.Throws<MiExcepcion>(() =>  montania2 = new Montania(-4));
        }  

        [Test]
        public void TestDisponibilidadCero()
        {
            Montania montania2;
            Assert.Throws<MiExcepcion>(() =>  montania2 = new Montania(0));
        }    
    }
}