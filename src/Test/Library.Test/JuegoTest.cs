using NUnit.Framework;
using System.Collections.Generic;
using Library;


namespace Library.Test
{
    public class JudgeTest
    {

        private Juego juego1;
        private Viajero viajero1;
        private Viajero viajero2;
        private Viajero viajero3;
        private Viajero viajero4;

        [SetUp]
        public void Setup()
        {
            juego1=new Juego(2);
            viajero1= new ViajeroComun("123","Juan");
            viajero2= new ViajeroComun("124","Pedro");
            viajero3= new ViajeroComun("125","Ana");
            viajero4= new ViajeroComun("123","Ana");
        }      

        [Test]
        public void CargarExperiencias()
        {
            
        }

        /*[Test]
        public void TestCargarViajero()
        {
            Assert.True(juego1.CargarViajero(viajero1));
        }

        [Test]
        public void TestCargarViajeroMayorAMaximo()
        {
            Assert.True(juego1.CargarViajero(viajero1));
            Assert.True(juego1.CargarViajero(viajero2));
            Assert.False(juego1.CargarViajero(viajero3));
        }

        [Test]
        public void TestCargarViajeroConMismoID()
        {
            Assert.True(juego1.CargarViajero(viajero1));
            Assert.False(juego1.CargarViajero(viajero1));
        }*/

        

    }
}