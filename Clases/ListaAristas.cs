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
        public void Mostrar()
        {
            Arista aux = primero;
            int i = 1;

            while (aux != null)
            {
                Console.WriteLine(i + ". --> " + aux.destino.dato.nombre +
                                  " (" + aux.distancia + " km)");

                aux = aux.sig;
                i++;
            }

            Console.WriteLine();
        }
    }
}
