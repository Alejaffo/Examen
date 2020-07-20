using System;
using System.Collections.Generic;

namespace Library
{
    public class Oceano:Paisaje
    {
        public Oceano(int disponibilidad):base(disponibilidad)
        {
            
        }

        public override void Accion(Viajero viajero)
        {
            int cantidadDeEntradas = CantidadDeEntradas(viajero);
            viajero.PuntosAcumulados+=(2*cantidadDeEntradas-1);
        }
    }
}