using System;

namespace Library
{
    public class ViajeroComun:Viajero
    {   

        public ViajeroComun(string id, string nombre):base(id,nombre)
        {
            tieneBono=false;
        }

        public override void VisitarExperiencia(int pos)
        {
            throw new NotImplementedException();
        }
    }
}