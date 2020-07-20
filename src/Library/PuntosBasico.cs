using System;
using System.Collections.Generic;

namespace Library
{
    public class PuntosBasico:Puntos
    {
        public override List<Viajero> CalcularGanador(List<Viajero> viajeros)
        {
            List<Viajero> ganadores = new List<Viajero>();
            ganadores.Add(viajeros[0]);

            for(int i=1;i<viajeros.Count;i++)
            {
                if(viajeros[i].PuntosAcumulados > ganadores[0].PuntosAcumulados)
                {
                    ganadores.Clear();
                    ganadores.Add(viajeros[i]);
                }
                else if(viajeros[i].PuntosAcumulados == ganadores[0].PuntosAcumulados)
                {
                    ganadores.Add(viajeros[i]);
                }
            }
            return ganadores;
        }
    }
}