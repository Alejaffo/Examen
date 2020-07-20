using System;
using System.Collections.Generic;

namespace Library
{
    public abstract class Paisaje:Experiencia
    {

        private Dictionary<string,int> entradas=new Dictionary<string, int>();

        public Paisaje(int disponibilidad):base(disponibilidad)
        {
            
        }

        public int CantidadDeEntradas(Viajero viajero)
        {
            if(entradas.ContainsKey(viajero.Id))
            {
                int cantEntradas = entradas[viajero.Id]+1;
                entradas[viajero.Id]=cantEntradas;
            }
            else
            {
                entradas.Add(viajero.Id,1);
            }
            return entradas[viajero.Id];
        }

    }
}