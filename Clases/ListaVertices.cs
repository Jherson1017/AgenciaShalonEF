using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class ListaVertices
    {
        public Vertice primero = null;

        public void Insertar(Agencia a)
        {
            Vertice nuevo = new Vertice();

            nuevo.dato = a;

            nuevo.sig = primero;

            primero = nuevo;
        }
    }
}
