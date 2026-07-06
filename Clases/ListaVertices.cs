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
            nuevo.sig = null;

            if (primero == null)
            {
                primero = nuevo;
            }
            else
            {
                Vertice aux = primero;

                while (aux.sig != null)
                {
                    aux = aux.sig;
                }

                aux.sig = nuevo;
            }
        }
    }
}
