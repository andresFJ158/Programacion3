using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasEnlazadas
{
    class Nodo
    {
        public int Dato { get; set; }
        public Nodo Siguiente { get; set; }
        public Nodo (int dato)
        {
            Dato = dato;
            Siguiente = null;
        }

    }
}
