using System;

namespace Library
{
    /// <summary>
    /// Esta clase cumple con [OCP] permite sin modificar lo que tenemos extender las experiencias disponibles
    /// Y que cada una realice la acción que quiera con respecto a la asignación o resta de monedas y o puntos
    /// </summary>
    public abstract class Experiencia
    {
        public int Nombre{get;set;}
        public int Disponibilidad{get;set;}

        /// <summary>
        /// Chequea la disponiblidad no sea menor o igual a cero al iniciarla
        /// </summary>
        /// <param name="disponibilidad"></param>
        public Experiencia (int disponibilidad)
        {
            if(disponibilidad<=0)
            {
                throw new MiExcepcion("La disponibilidad no puede ser <= 0");
            }
            else
            {
                this.Disponibilidad=disponibilidad;
            }
        }

        /// <summary>
        /// Método para que cada experiencia implemente
        /// </summary>
        /// <param name="viajero"></param>
        public abstract void Accion(Viajero viajero);
    }
}