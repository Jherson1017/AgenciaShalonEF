using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public  class Vertice
    {
        public Agencia dato;
        public Vertice sig = null;

        public ListaAristas rutas = new ListaAristas();

    }
}
