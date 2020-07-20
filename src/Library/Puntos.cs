using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase que permite calcular un ganador
    /// </summary>
    public abstract class Puntos
    {
        /// <summary>
        /// Método abstracto que cumple con [OCP] ya que nos permite en el futuro agregar un método que lo implemente
        /// diferente a "PuntosBásico" que tome otros parámetros para definir el ganador sin modificar éste último.
        /// Abierto a la extención, cerrado a la modificación
        /// También cumple con [SRP] porque tiéne sólo 1 razon de cambio vinculada a la forma en que se definen los ganadores
        /// Cumple con [DIP] ya que no tenemos abstracciones dependiendo de clases concretas o clases concretas dependiendo de otras clases concretas
        /// Cumple con [Expert] porque maneja toda la información relacionada con el manejo de los puntos
        /// </summary>
        /// <param name="viajeros"></param>
        /// <returns></returns>
        public abstract List<Viajero> CalcularGanador(List<Viajero> viajeros);
    }
}