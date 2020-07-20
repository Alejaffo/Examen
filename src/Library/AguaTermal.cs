using System;

namespace Library
{
    /// <summary>
    /// Clase que hereda de Experiencia
    /// </summary>
    public class AguaTermal:Experiencia
    {

        public AguaTermal(int disponibilidad):base(disponibilidad)
        {
            
        }
        /// <summary>
        /// Aumenta los puntos en 2 en cada entrada del viajero
        /// </summary>
        /// <param name="viajero"></param>
        public override void Accion(Viajero viajero)
        {
            viajero.PuntosAcumulados+=2;
        }

    }
}