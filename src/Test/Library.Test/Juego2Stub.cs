using System.Collections.Generic;
using Library;

namespace Library.Test
{
    public class Juego2Stub
    {
        public Viajero Viajero1{get;set;}
        public Viajero Viajero2{get;set;}
        public Viajero Viajero3{get;set;}
        public Viajero Viajero4{get;set;}

        private Juego juego;
        public Movimiento Mover{get;}
      
        public Juego2Stub()
        {
            juego = new Juego (4);

            Viajero1 = new ViajeroComun("123","Juan");
            Viajero2 = new ViajeroComun("124","Ana");
            Viajero3 = new ViajeroComun("125","Pedro");
            Viajero4 = new ViajeroComun("126","Antonio");

            List<Viajero> viajeros = new List<Viajero>();

            viajeros.Add(Viajero1);
            viajeros.Add(Viajero2);
            viajeros.Add(Viajero3);
            viajeros.Add(Viajero4);

            Experiencia granja1 = new Granja(3);
            Experiencia granja2 = new Granja(1);
            Experiencia aguaTermal1 = new AguaTermal(2);
            Experiencia oceano1 = new Oceano(4);
            Experiencia montania1 = new Montania(3);

            List<Experiencia> experiencias = new List<Experiencia>();

            experiencias.Add(granja1);
            experiencias.Add(aguaTermal1);
            experiencias.Add(oceano1);
            experiencias.Add(granja2);
            experiencias.Add(montania1);

            juego.CargarViajeros(viajeros);
            juego.CargarExperiencias(experiencias);
            
            Viajero1.SetPosicionActual(2,2);
            juego.Camino[0].Disponibilidad+=1;
            juego.Camino[2].Disponibilidad-=1;
            Viajero2.SetPosicionActual(2,1);
            juego.Camino[0].Disponibilidad+=1;
            juego.Camino[2].Disponibilidad-=1;
            Viajero3.SetPosicionActual(4,1);
            juego.Camino[0].Disponibilidad+=1;
            juego.Camino[4].Disponibilidad-=1;
            Viajero4.SetPosicionActual(6,3);
            juego.Camino[0].Disponibilidad+=1;
            juego.Camino[6].Disponibilidad-=1;

            Mover = new Movimiento(juego.Camino,juego.Viajeros);
        }
    }
}