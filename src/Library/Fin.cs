using System;

namespace Library
{
    public class Fin:Experiencia
    {

        public Fin(int disponibilidad):base(disponibilidad)
        {
            
        }

        public override void Accion(Viajero viajero)
        {
            viajero.EnJuego=false;
        }

    }
}