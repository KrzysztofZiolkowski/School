using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafy_Sortowanie_Topologiczne
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Podaj liczbę wierzchołków");
                int n = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Podaj liczbę krawędzi");
                int m = Convert.ToInt32(Console.ReadLine());

                int[,] matrix = new int[n, n];
                int[] A = new int[n];


                Console.WriteLine("Podaj Vi,Vj");

                for (int i = 0; i < m; i++)
                {
                    int Vi = Convert.ToInt32(Console.ReadLine());
                    int Vj = Convert.ToInt32(Console.ReadLine());
                    matrix[Vi - 1, Vj - 1] = 1;
                    Console.WriteLine("{0} {1}", Vi, Vj);
                }

                Console.WriteLine("");

                foreach (var element in A)
                {
                    Console.Write(element);
                }
                Console.WriteLine("");
                Console.WriteLine("");

                for (int z = 0; z < n; z++)
                {
                    Console.WriteLine("");
                    for (int q = 0; q < n; q++)
                    {
                        Console.Write(matrix[z, q] + " , ");
                    }


                }


            }


            catch (FormatException)
            {
                Console.WriteLine("Nieprawidłowy ciąg wejściowy");
            }


            Console.ReadKey();
        }
    }
}


