using NUnit.Framework;
using System.Collections.Generic;
using Library;


namespace Library.Test
{
    public class GranjaTest
    {

        private Viajero viajero;
        private Granja granja;

        [SetUp]
        public void Setup()
        {
            viajero = new ViajeroComun("123","Juan");
            granja = new Granja(3);
        }      

        [Test]
        public void TestAccion()
        {
            granja.Accion(viajero);
            Assert.AreEqual(3,viajero.MonedasAcumuladas);           
        }  

        [Test]
        public void TestAccionTresEntradas()
        {
            granja.Accion(viajero);     
            granja.Accion(viajero);   
            granja.Accion(viajero);
            Assert.AreEqual(9,viajero.MonedasAcumuladas);           
        }     

        [Test]
        public void TestAccionConValorPrevio()
        {
            viajero.MonedasAcumuladas=40;
            granja.Accion(viajero);
            granja.Accion(viajero);
            Assert.AreEqual(46,viajero.MonedasAcumuladas);
        }    

        [Test]
        public void TestDisponibilidadUno()
        {
            Granja granja2 = new Granja(4);
            Assert.AreEqual(4,granja2.Disponibilidad);
        }

        [Test]
        public void TestDisponibilidadValorNegativo()
        {
            Granja granja2;
            Assert.Throws<MiExcepcion>(() =>  granja2 = new Granja(-4));
        }  

        [Test]
        public void TestDisponibilidadCero()
        {
            Granja granja2;
            Assert.Throws<MiExcepcion>(() =>  granja2 = new Granja(0));
        }
    }
}