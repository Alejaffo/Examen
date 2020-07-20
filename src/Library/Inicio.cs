using System;

namespace Library
{
    public class Inicio:Experiencia
    {

        public Inicio(int disponibilidad):base(disponibilidad)
        {
            
        }

        public override void Accion(Viajero viajero)
        {
            viajero.MonedasAcumuladas=0;
            viajero.PuntosAcumulados=0;
            viajero.EnJuego=true;
        }

    }
}