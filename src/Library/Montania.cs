using System;
using System.Collections.Generic;

namespace Library
{
    public class Montania:Paisaje
    {
        public Montania(int disponibilidad):base(disponibilidad)
        {
            
        }

        public override void Accion(Viajero viajero)
        {
            int cantidadDeEntradas = CantidadDeEntradas(viajero);
            viajero.PuntosAcumulados+=cantidadDeEntradas;
        }
    }
}