using System;

namespace Library
{
    [Serializable]
    public class MiExcepcion:Exception
    {
        public MiExcepcion() { }

        public MiExcepcion(string mensaje)
            : base(mensaje) { }

        public MiExcepcion(string mensaje, Exception interna)
            : base(mensaje, interna) { }
    }
}