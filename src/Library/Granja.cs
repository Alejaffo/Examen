using System;

namespace Library
{
    public class Granja:Experiencia
    {

        public Granja(int disponibilidad):base(disponibilidad)
        {
            
        }

        public override void Accion(Viajero viajero)
        {
            viajero.MonedasAcumuladas+=3;
        }

    }
}