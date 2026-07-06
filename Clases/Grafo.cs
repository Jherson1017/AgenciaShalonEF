using Clases;
using System;

public class Grafo
{
    public ListaVertices listaVertices = new ListaVertices();
    int[,] ma;
    string[] nombres ={ "Shalon Caj", "Shalon Lim", "Shalon Tru", "Shalon Chi",
            "Shalon Are","Shalon Cus","Shalon Pun", "Shalon Tac", "Shalon Hua",
        };

    string[] ciudades ={ "Cajamarca", "Lima","Trujillo","Chiclayo","Arequipa", "Cusco",
            "Puno", "Tacna", "Huancayo",
        };
    public Grafo(int cant)
    {
        for (int i = 0; i < cant; i++)
        {
            Agencia a = new Agencia();
            a.nombre = nombres[i];
            a.ciudad = ciudades[i];
            a.codigo = " " + (i + 1)+ " ";

            listaVertices.Insertar(a);
        }

        ma = new int[cant, cant];
    }
    public Vertice GetInicio()
    {
        return listaVertices.primero;
    }
    public void GenerarMatriz()
    {
        Random r = new Random();
        for (int i = 0; i < ma.GetLength(0); i++)
        {
            for (int j = 0; j < ma.GetLength(1); j++)
            {
                if (i == j)
                    ma[i, j] = 0;
                else
                    ma[i, j] = r.Next(0, 2);
            }
        }
    }
    public void MostrarAgencias()
    {
        Vertice temp = listaVertices.primero;

        Console.WriteLine("\n===== AGENCIAS =====\n");

        while (temp != null)
        {
            Console.WriteLine(temp.dato);

            temp = temp.sig;
        }
    }

    public void MostrarMatriz()
    {
        Console.WriteLine("\nMATRIZ DE ADYACENCIA\n");
        Console.Write("      ");

        for (int i = 0; i < ma.GetLength(0); i++)
        {
            Console.Write(i + " ");

        }

        Console.WriteLine();

        for (int i = 0; i < ma.GetLength(0); i++)
        {
            Console.Write(i + " --> ");

            for (int j = 0; j < ma.GetLength(1); j++)
            {
                Console.Write(ma[i, j] + " ");
            }

            Console.WriteLine();
        }
    }
    public void CrearGrafo()
    {
        Vertice temp_i = listaVertices.primero;

        for (int i = 0; i < ma.GetLength(0); i++)
        {
            Vertice temp_j = listaVertices.primero;

            for (int j = 0; j < ma.GetLength(1); j++)
            {
                if (ma[i, j] == 1)
                {
                    int distancia;

                    if (i == j)
                    {
                        distancia = 0;
                    }
                    else
                    {
                        distancia = (i + j + 2) * 100;
                    }

                    temp_i.rutas.Insertar(temp_j, distancia);
                }

                temp_j = temp_j.sig;
            }

            temp_i = temp_i.sig;
        }
    }
    public void Recorrer(Vertice v, ref float total)
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("AGENCIA ACTUAL");
        Console.WriteLine(v.dato);
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("Rutas disponibles:");
        v.rutas.Mostrar();
        Console.WriteLine("--------------------------------------");
        Console.Write("Ingrese la ruta (0 para salir): ");

        int op = int.Parse(Console.ReadLine());
        if (op == 0)
            return;
        Arista temp = v.rutas.primero;
        for (int i = 1; i < op; i++)
        {
            temp = temp.sig;
        }
        total += temp.distancia;
        Recorrer(temp.destino, ref total);
    }
    public void ContarConexiones()
    {
        Vertice v = listaVertices.primero;
        Console.WriteLine("\n===== CONEXIONES =====\n");
        while (v != null)
        {
            int contador = 0;

            Arista a = v.rutas.primero;

            while (a != null)
            {
                contador++;
                a = a.sig;
            }

            Console.WriteLine(
                v.dato.nombre +
                " -> " +
                contador +
                " conexiones"
            );

            v = v.sig;
        }
    }
    public void Dijkstra(int origen)
    {
        int n = ma.GetLength(0);

        int[] distancia = new int[n];
        bool[] visitado = new bool[n];
        Vertice[] vertices = new Vertice[n];

        // Guardar los vértices en un arreglo para acceder por índice
        Vertice aux = listaVertices.primero;
        for (int i = 0; i < n; i++)
        {
            vertices[i] = aux;
            aux = aux.sig;

            distancia[i] = 99999;
            visitado[i] = false;
        }

        distancia[origen] = 0;

        for (int i = 0; i < n - 1; i++)
        {
            int min = 99999;
            int u = -1;

            // Buscar el vértice con menor distancia
            for (int j = 0; j < n; j++)
            {
                if (!visitado[j] && distancia[j] < min)
                {
                    min = distancia[j];
                    u = j;
                }
            }

            if (u == -1)
                break;

            visitado[u] = true;

            // Recorrer las aristas del vértice seleccionado
            Arista arista = vertices[u].rutas.primero;

            while (arista != null)
            {
                // Buscar el índice del vértice destino
                int v = -1;

                for (int k = 0; k < n; k++)
                {
                    if (vertices[k] == arista.destino)
                    {
                        v = k;
                        break;
                    }
                }

                // Actualizar la distancia mínima
                if (v != -1 && !visitado[v])
                {
                    if (distancia[u] + arista.distancia < distancia[v])
                    {
                        distancia[v] = distancia[u] + arista.distancia;
                    }
                }

                arista = arista.sig;
            }
        }
        Console.WriteLine("\n===== CAMINOS MÁS CORTOS =====\n");

        bool[] usado = new bool[n];

        for (int k = 0; k < n; k++)
        {
            int min = 99999;
            int pos = -1;

            for (int i = 0; i < n; i++)
            {
                if (!usado[i] && distancia[i] < min)
                {
                    min = distancia[i];
                    pos = i;
                }
            }

            if (pos == -1) break;

            usado[pos] = true;

            if (distancia[pos] == 99999)
                Console.WriteLine(vertices[pos].dato.nombre + " : No hay ruta");
            else
                Console.WriteLine(vertices[pos].dato.nombre + " : " + distancia[pos] + " km");
        }
    }

}