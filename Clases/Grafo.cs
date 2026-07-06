using Clases;
using System;

public class Grafo
{
    public ListaVertices listaVertices = new ListaVertices();
    int[,] ma;
    string[] nombres ={ "Shalon Cajamarca", "Shalon Lima", "Shalon Trujillo", "Shalon Chiclayo",
            "Shalon Arequipa","Shalon Cusco","Shalon Puno", "Shalon Tacna", "Shalon Huancayo",
            "Shalon Iquitos","Shalon Piura", "Shalon Tarapoto"
        };

    string[] ciudades ={ "Cajamarca", "Lima","Trujillo","Chiclayo","Arequipa", "Cusco",
            "Puno", "Tacna", "Huancayo","Iquitos","Piura","Tarapoto"
        };
    public Grafo(int cant)
    {
        for (int i = 0; i < cant; i++)
        {
            Agencia a = new Agencia();
            a.nombre = nombres[i];
            a.ciudad = ciudades[i];
            a.codigo = "A00" + (i + 1);

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
        Random r = new Random();
        Vertice temp_i = listaVertices.primero;
        for (int i = 0; i < ma.GetLength(0); i++)
        {
            Vertice temp_j = listaVertices.primero;
            for (int j = 0; j < ma.GetLength(1); j++)
            {
                if (ma[i, j] == 1)
                {
                    int distancia = 0;

                    if (i == j)
                    {
                        distancia = 0;
                    }
                    else
                    {
                        distancia = ((i + 1) + (j + 1)) * 100;
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

        for (int i = 0; i < n; i++)
        {
            distancia[i] = 99999;
            visitado[i] = false;
        }

        distancia[origen] = 0;

        for (int i = 0; i < n - 1; i++)
        {
            int min = 99999;
            int u = -1;

            for (int j = 0; j < n; j++)
            {
                if (!visitado[j] && distancia[j] < min)
                {
                    min = distancia[j];
                    u = j;
                }
            }

            visitado[u] = true;

            for (int v = 0; v < n; v++)
            {
                if (ma[u,v] > 0 && !visitado[v] &&
                    distancia[u] + ma[u, v] < distancia[v])
                {
                    distancia[v] = distancia[u] + ma[u, v];
                }
            }
        }
        Console.WriteLine("\nCAMINOS MÁS CORTOS");

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Agencia " + (i + 1) + ": " + distancia[i] + " km");
        }
    }

}