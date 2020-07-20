using NUnit.Framework;
using System.Collections.Generic;
using Library;


namespace Library.Test
{
    public class OceanoTest
    {

        private Viajero viajero;
        private Oceano oceano;

        [SetUp]
        public void Setup()
        {
            viajero = new ViajeroComun("123","Juan");
            oceano = new Oceano(1);
        }      

        [Test]
        public void TestCantidadDeEntradasUnaEntrada()
        {
            Assert.AreEqual(1,oceano.CantidadDeEntradas(viajero));
        }  

        [Test]
        public void TestCantidadDeEntradasCincoEntradas()
        {
            oceano.CantidadDeEntradas(viajero);
            oceano.CantidadDeEntradas(viajero);
            oceano.CantidadDeEntradas(viajero);
            oceano.CantidadDeEntradas(viajero);
            Assert.AreEqual(5,oceano.CantidadDeEntradas(viajero));
        }

        [Test]
        public void TestAccion()
        {
            oceano.Accion(viajero);
            oceano.Accion(viajero);
            oceano.Accion(viajero);
            oceano.Accion(viajero);
            Assert.AreEqual(16,viajero.PuntosAcumulados);
        }     

        [Test]
        public void TestAccionConValorPrevio()
        {
            viajero.PuntosAcumulados=40;
            oceano.Accion(viajero);
            oceano.Accion(viajero);
            oceano.Accion(viajero);
            oceano.Accion(viajero);
            Assert.AreEqual(56,viajero.PuntosAcumulados);
        } 

        [Test]
        public void TestDisponibilidadUno()
        {
            Oceano oceano2 = new Oceano(4);
            Assert.AreEqual(4,oceano2.Disponibilidad);
        }

        [Test]
        public void TestDisponibilidadValorNegativo()
        {
            Oceano oceano2;
            Assert.Throws<MiExcepcion>(() =>  oceano2 = new Oceano(-4));
        }  

        [Test]
        public void TestDisponibilidadCero()
        {
            Oceano oceano3;
            Assert.Throws<MiExcepcion>(() =>  oceano3 = new Oceano(0));
        }               
    }
}