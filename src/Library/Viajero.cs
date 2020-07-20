using System;

namespace Library
{
    public abstract class Viajero
    {
        public bool EnJuego{get;set;}
        public string Id{get;set;}
        private string nombre;
        public int PuntosAcumulados{get;set;}
        public int MonedasAcumuladas{get;set;}
        private int[] posicionActual = new int[2];
        protected bool tieneBono;
        
        public Viajero(string id, string nombre)
        {
            this.Id=id;
            this.nombre=nombre;
        }

        public void SetPosicionActual(int posicion,int posicionInterna)
        {
            posicionActual[0]=posicion;
            posicionActual[1]=posicionInterna;
        }

        public int[] GetPosicionActual()
        {
            int[] pos = new int[2];
            pos[0]=posicionActual[0];
            pos[1]=posicionActual[1];
            return pos;        
        }
        public abstract void VisitarExperiencia(int pos);
    }
}