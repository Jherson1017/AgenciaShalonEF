using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class ListaAristas
    {
        public Arista primero = null;
        public void Insertar(Vertice destino, int distancia)
        {
            Arista nuevo = new Arista();
            nuevo.destino = destino;
            nuevo.distancia = distancia;
            nuevo.sig = null;

            if (primero == null)
            {
                primero = nuevo;
            }
            else
            {
                Arista aux = primero;

                while (aux.sig != null)
                {
                    aux = aux.sig;
                }

                aux.sig = nuevo;
            }
        }

    }
}
