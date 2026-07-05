using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;

namespace AgenciaShalonEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Grafo g = new Grafo(8);
            float total = 0;

            g.GenerarMatriz();
            g.CrearGrafo();

            int op;

            do
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("   SISTEMA AGENCIA SHALON");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Mostrar matriz");
                Console.WriteLine("2. Recorrer agencias");
                Console.WriteLine("3. Camino más corto (Dijkstra)");
                Console.WriteLine("0. Salir");
                Console.WriteLine("=================================");
                Console.Write("Opción: ");
                op = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (op)
                {
                    case 1:
                        g.MostrarMatriz();
                        break;

                    case 2:
                        total = 0;
                        g.Recorrer(g.GetInicio(), ref total);
                        Console.WriteLine("\nDistancia total: " + total + " km");
                        break;

                    case 3:
                           g.Dijkstra(0);
                        Console.WriteLine("Opción en desarrollo.");
                        break;

                    case 0:
                        Console.WriteLine("Gracias por usar el sistema.");
                        break;

                    default:
                        Console.WriteLine("Opción incorrecta.");
                        break;
                }

                if (op != 0)
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (op != 0);
        }
    }
}
