using NUnit.Framework;
using System.Collections.Generic;
using Library;

namespace Library.Test
{
    public class MovimientoTest
    {

        Movimiento movimiento;
        Viajero viajero1;
        Viajero viajero2;
        Viajero viajero3;
        Viajero viajero4;
        Juego2Stub juego;

        [SetUp]
        public void Setup()
        {
            juego = new Juego2Stub();
            viajero1 = juego.Viajero1;
            viajero2 = juego.Viajero2;
            viajero3 = juego.Viajero3;
            viajero4 = juego.Viajero4;
            movimiento = juego.Mover;
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public void TestMovimientoFueraDeRangoPosValidas(int pos)
        {
            Assert.False(movimiento.MovimientoFueraDeRango(viajero1,pos));
        }

        [Test]
        [TestCase(10)]
        [TestCase(40)]
        public void TestMovimientoFueraDeRangoPosInvalidas(int pos)
        {
            Assert.True(movimiento.MovimientoFueraDeRango(viajero1,pos));
        }

        [Test]
        [TestCase(2)]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(-40)]
        public void TestMovimientoHaciaAtras(int pos)
        {
            Assert.True(movimiento.MovimientoHaciaAtras(viajero1,pos));
        }

        [Test]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public void TestMovimientoHaciaAtrasPosCorrectas(int pos)
        {
            Assert.False(movimiento.MovimientoHaciaAtras(viajero1,pos));
        }

        [Test]
        [TestCase(4)]
        public void TestMovimientoADisponibilidadCero(int pos)
        {
            Assert.True(movimiento.MovimientoADisponibilidadCero(viajero1,pos));
        }

        [Test]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(6)]
        public void TestMovimientoADisponibilidadCeroConDisponibilidad(int pos)
        {
            Assert.False(movimiento.MovimientoADisponibilidadCero(viajero1,pos));
        }

        [Test]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(6)]
        public void TestMovimientoValido(int pos)
        {
            Assert.True(movimiento.MovimientoValido(viajero1,pos));
        }

        [Test]
        [TestCase(-5)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(120)]
        public void TestMovimientoValidoAPosInvalidas(int pos)
        {
            Assert.False(movimiento.MovimientoValido(viajero1,pos));
        }

        [Test]
        public void TestMoverViajero1QueNoEsSuTurno()
        {
            Assert.Throws<MiExcepcion>(() => movimiento.MoverViajero(viajero1,5));   
        }

        [Test]
        public void TestMoverViajero2QueEsSuTurno()
        {
            movimiento.MoverViajero(viajero2,5);
            Assert.AreEqual(viajero2.GetPosicionActual()[0],5);   
        }

        [Test]
        public void TestMoverViajero3QueNoEsSuTurno()
        {
            Assert.Throws<MiExcepcion>(() => movimiento.MoverViajero(viajero3,5));   
        }

        [Test]
        public void TestMoverViajero4QueNoEsSuTurno()
        {
            Assert.Throws<MiExcepcion>(() => movimiento.MoverViajero(viajero4,5));   
        }

        [Test]
        public void TestDeQuienEsElTurnoViajero1NoEsSuTurno()
        {
            Viajero viajero = movimiento.DeQuienEsElTurno();
            Assert.AreNotEqual(viajero1,viajero);
        }

        [Test]
        public void TestDeQuienEsElTurnoViajero2EnTurno()
        {
            Viajero viajero = movimiento.DeQuienEsElTurno();
            Assert.AreEqual(viajero2,viajero);
        }

        [Test]
        public void TestDeQuienEsElTurnoViajero3NoEsSuTurno()
        {
            Viajero viajero = movimiento.DeQuienEsElTurno();
            Assert.AreNotEqual(viajero3,viajero);
        }

        [Test]
        public void TestDeQuienEsElTurnoViajero4NoEsSuTurno()
        {
            Viajero viajero = movimiento.DeQuienEsElTurno();
            Assert.AreNotEqual(viajero4,viajero);
        }
    }
}