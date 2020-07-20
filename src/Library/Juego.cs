using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase que se encarga de cargar la lista de viejeros y la lista de experiencias y delega
    /// el cálculo de puntos y movimientos a las clases [expertas] correspondientes
    /// Soporta [Polimorfismo] en varios métodos, está indicado en cada método
    /// </summary>
    public class Juego
    {
        private int minimoDeViajeros=2;
        private int maximoDeViajeros;
        public List<Viajero> Viajeros{get;set;}
        public List<Experiencia> Camino{get;set;}
        private Experiencia inicio;
        private Experiencia fin;

        /// <summary>
        /// Agrega una experiencia de inicio como primer experiencia al camino de experiencias, recibe la cantidad máxima de jugadores
        /// e inicializa las listas de camino y viajeros
        /// </summary>
        /// <param name="maximoDeViajeros"></param>
        public Juego(int maximoDeViajeros)
        {
            this.maximoDeViajeros=maximoDeViajeros;
            this.inicio=new Inicio(maximoDeViajeros);
            this.fin=new Fin(maximoDeViajeros);
            Camino = new List<Experiencia>();
            Viajeros = new List<Viajero>();
            Camino.Add(inicio);
        }
        
        /// <summary>
        /// Recibe una lista de viajeros y la carga a la lista de viajeros del juego
        /// Soporta [polimorfismo] puede recibir lista de viajeros de distinto tipo
        /// </summary>
        /// <param name="listaDeViajeros"></param>
        /// <returns></returns>
        public bool CargarViajeros(List<Viajero> listaDeViajeros)
        {
            int posInterna=0;
            foreach (Viajero viajero in listaDeViajeros)
            {
                if(Viajeros.Count < maximoDeViajeros && !IdExisteEnListaDeViajeros(viajero.Id))
                {
                    this.Viajeros.Add(viajero);
                    viajero.SetPosicionActual(0,posInterna);
                    inicio.Accion(viajero);
                    posInterna++;
                }
            }
            return false;
        }

        /// <summary>
        /// Comprueba si el viajero ya está ingresado por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IdExisteEnListaDeViajeros(string id)
        {
            if(Viajeros.Count==0)
            {
                return false;
            }
            else
            {
                foreach(Viajero v in Viajeros)
                {
                    if(v.Id.Equals(id))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Cumple con [Polimorfismo] ya que se le puede pasar cualquier subtipo de Experiencia
        /// Recibe una lista de experiencias las agrega al camino en el orden que vienen y agrega la experiencia de fin al final
        /// </summary>
        /// <param name="experiencias"></param>
        public void CargarExperiencias(List<Experiencia> experiencias)  
        {
            foreach(Experiencia exp in experiencias)
            {
                Camino.Add(exp);
            }
            Camino.Add(fin);
        }

        /// <summary>
        /// Controla que el camino tenga al menos 1 experiencia y que la cantidad de jugadores sea mayor a la mínima para jugar
        /// </summary>
        /// <returns></returns>

        public bool IniciarJuego()
        {
            if(Camino.Count<3 || Viajeros.Count < minimoDeViajeros)
            {
                Console.WriteLine("No se puede iniciar el juego");
                return false;
            }
            Console.WriteLine("Iniciar Juego");
            return true;
        }

        /// <summary>
        /// Le pasa el viajero y la posición destino a Movimientos para que se encarge del movimiento
        /// Soporta [Polimorfismo] puede recir subtipos de Viajero
        /// </summary>
        /// <param name="viajero"></param>
        /// <param name="pos"></param>

        public void MoverViajero(Viajero viajero, int pos)
        {
            Movimiento movimiento = new Movimiento(Camino,Viajeros);
            movimiento.MoverViajero(viajero,pos);

        }

        /// <summary>
        /// Verifica si todos los jugadores terminaron, si es así le pide a Puntos que haga el cálculo del ganador
        /// </summary>
        /// <returns></returns>
        public List<Viajero> ObtenerGanador()
        {
            foreach(Viajero viajero in Viajeros)
            {
                if(viajero.EnJuego)
                {
                    System.Console.WriteLine("El juego todavia no terminó");
                    throw new MiExcepcion("El juego todavia no terminó");
                }
            }
            Puntos calculos = new PuntosBasico();
            return calculos.CalcularGanador(Viajeros);
        }
    }
}