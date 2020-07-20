using System.Collections.Generic;
using Library;

namespace Library.Test
{
    public class Juego1Stub
    {
        public Viajero Viajero1{get;set;}
        public Viajero Viajero2{get;set;}
        public Viajero Viajero3{get;set;}
        public Viajero Viajero4{get;set;}
        private Juego juego;
        public Movimiento Mover{get;}
      
        public Juego1Stub()
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
            Experiencia aguaTermal1 = new AguaTermal(1);
            Experiencia aguaTermal2 = new AguaTermal(4);
            Experiencia oceano1 = new Oceano(4);
            Experiencia oceano2 = new Oceano(2);
            Experiencia montania1 = new Montania(3);
            Experiencia montania2 = new Montania(1);

            List<Experiencia> experiencias = new List<Experiencia>();

            experiencias.Add(granja1);
            experiencias.Add(aguaTermal1);
            experiencias.Add(oceano1);
            experiencias.Add(granja2);
            experiencias.Add(montania1);
            experiencias.Add(oceano2);
            experiencias.Add(montania2);
            experiencias.Add(aguaTermal2);
            
            juego.CargarViajeros(viajeros);
            juego.CargarExperiencias(experiencias);

            Mover = new Movimiento(juego.Camino,juego.Viajeros);
        }
    }
}