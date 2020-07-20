using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase que se encarga de realizar todo lo que tiene que ver con los movimientos
    /// Cumple con [Expert] porque es la que tiene todos los datos para realizar los cálculos de movimiento.null
    /// Cumple con [SRP] porque la única razón de cambio es que cambie la forma de realizar o validar los movimientos
    /// Cumple con [Alta Cohesión] los métodos están muy relacionados con las tareas a desempeñar y hay [Bajo acoplamiento] porque
    /// no depende de otras clases para funcionar
    /// </summary>
    public class Movimiento
    {
        private List<Viajero> viajeros;
        private List<Experiencia> camino;

        /// <summary>
        /// Recibe el camino y la lista de viajeros y se encarga de chequear todas las opciones que hay que validad
        /// para realizar un movimiento
        /// </summary>
        /// <param name="camino"></param>
        /// <param name="viajeros"></param>
        public Movimiento(List<Experiencia> camino, List<Viajero> viajeros)
        {
            this.viajeros=viajeros;
            this.camino=camino;
        }
        
        /// <summary>
        /// Si el viajero no terminó el juego, si es su turno y el movimiento es válido realiza el movimiento
        /// </summary>
        /// <param name="viajero"></param>
        /// <param name="posicion"></param>
        public void MoverViajero(Viajero viajero, int posicion)
        {
            if(viajero.EnJuego==false)
            {
                System.Console.WriteLine("Ya terminaste");
                throw new MiExcepcion("Ya terminaste el juego no te puedes mover");
            }
            else if(DeQuienEsElTurno().Id!=viajero.Id)
            {
                System.Console.WriteLine("No es tu turno");
                throw new MiExcepcion("No es tu turno, no te puedes mover");
            }
            else if(MovimientoValido(viajero,posicion))
            {
                camino[viajero.GetPosicionActual()[0]].Disponibilidad++;
                viajero.SetPosicionActual(posicion,camino[posicion].Disponibilidad);
                camino[posicion].Disponibilidad-=1;
                if(posicion==camino.Count-1)
                {
                    viajero.EnJuego=false;
                }
                camino[posicion].Accion(viajero);
            }
        }

        /// <summary>
        /// Es un movimineto válido si no se quiere mover fuera del rango del camino
        /// moverse haci atrás o a una experiencia sin disponibilidad
        /// </summary>
        /// <param name="viajero"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool MovimientoValido(Viajero viajero, int pos)
        {
            if(!MovimientoFueraDeRango(viajero,pos) && !MovimientoHaciaAtras(viajero,pos) && !MovimientoADisponibilidadCero(viajero,pos))
            {
                System.Console.WriteLine("Movimiento válido");
                return true;
            }
            
            System.Console.WriteLine("Movimiento inválido");
            return false;
        }

        /// <summary>
        /// Verifica que la posición no esté por fuera de la posición final del camino
        /// </summary>
        /// <param name="viajero"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool MovimientoFueraDeRango(Viajero viajero, int pos)
        {
            if(pos>camino.Count-1)
            {
                System.Console.WriteLine("No se puede ir más allá del destino");
                return true;
            }
            return false;
        }
        
        /// <summary>
        /// Verifica que el viajer no se mueva para atrás o a la posición que tiene actualmente
        /// </summary>
        /// <param name="viajero"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool MovimientoHaciaAtras(Viajero viajero, int pos)
        {
            if(pos<=viajero.GetPosicionActual()[0])
            {
                System.Console.WriteLine("No se puede ir a una posición anterior o igual a la que estás");
                return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica que la disponibilidad del destino sea mayor a 0
        /// </summary>
        /// <param name="viajero"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool MovimientoADisponibilidadCero(Viajero viajero, int pos)
        {
            
            System.Console.WriteLine("Disponibilidad "+camino[pos].Disponibilidad);
            if(camino[pos].Disponibilidad==0)
            {
                System.Console.WriteLine("No hay disponibilidad en la estación a la que quieres ir");
                return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica si es el último de los viajeros que es al que le corresponde jugar
        /// </summary>
        /// <returns></returns>
        public Viajero DeQuienEsElTurno()
        {

            if(viajeros.Count>0)
            {
                Viajero viajeroEnMinimaPos=viajeros[0];

                for(int i=1;i<viajeros.Count;i++)
                {
                    if(viajeros[i].GetPosicionActual()[0]<viajeroEnMinimaPos.GetPosicionActual()[0])
                    {
                        viajeroEnMinimaPos=viajeros[i];
                    }
                    else if(viajeros[i].GetPosicionActual()[0]==viajeroEnMinimaPos.GetPosicionActual()[0])
                    {
                        if(viajeros[i].GetPosicionActual()[1]<viajeroEnMinimaPos.GetPosicionActual()[1])
                        {
                            viajeroEnMinimaPos=viajeros[i];
                        }
                    }
                }
                return viajeroEnMinimaPos;
            }
            return null;
        }
    }
}