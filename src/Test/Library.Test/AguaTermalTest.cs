using NUnit.Framework;
using System.Collections.Generic;
using Library;


namespace Library.Test
{
    public class AguaTermalTest
    {

        private Viajero viajero;
        private AguaTermal aguaTermal;

        [SetUp]
        public void Setup()
        {
            viajero = new ViajeroComun("123","Juan");
            aguaTermal = new AguaTermal(3);
        }      

        [Test]
        public void TestAccion()
        {
            aguaTermal.Accion(viajero);
            Assert.AreEqual(2,viajero.PuntosAcumulados);           
        }  

        [Test]
        public void TestAccionTresEntradas()
        {
            aguaTermal.Accion(viajero); 
            aguaTermal.Accion(viajero);   
            aguaTermal.Accion(viajero);
            Assert.AreEqual(6,viajero.PuntosAcumulados);           
        }     

        [Test]
        public void TestAccionConValorPrevio()
        {
            viajero.PuntosAcumulados=40;
            aguaTermal.Accion(viajero);
            aguaTermal.Accion(viajero);
            Assert.AreEqual(44,viajero.PuntosAcumulados);
        }    

        [Test]
        public void TestDisponibilidadUno()
        {
            AguaTermal aguaTermal2 = new AguaTermal(4);
            Assert.AreEqual(4,aguaTermal2.Disponibilidad);
        }

        [Test]
        public void TestDisponibilidadValorNegativo()
        {
            AguaTermal aguaTermal2;
            Assert.Throws<MiExcepcion>(() =>  aguaTermal2 = new AguaTermal(-4));
        }  

        [Test]
        public void TestDisponibilidadCero()
        {
            AguaTermal aguaTermal2;
            Assert.Throws<MiExcepcion>(() =>  aguaTermal2 = new AguaTermal(0));
        }
    }
}