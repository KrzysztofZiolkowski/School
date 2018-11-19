using System;
using System.Collections.Generic;
using System.Diagnostics; // do mierzenia czasu.
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kopiec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region RANDOM TAB CREATE
            Console.WriteLine("Zadeklaruj rozmiar kopca ");
            int Rozmiar = Convert.ToInt32(Console.ReadLine());

            int Rozmiar2 = Rozmiar;
            int[] tab = new int[Rozmiar + 1];

            // Przypisuję losowe liczby do tablicy
            Random rnd = new Random();
            for (int i = 1; i < tab.Length; i++)

            {
                tab[i] = rnd.Next(1, 100);
            }

            // Zerowy element tablicy to jej rozmiar 
            tab[0] = Rozmiar2;
            Console.WriteLine("Utworzono nieposortowany kopiec o rozmiarze: {0}", Rozmiar);
            Console.WriteLine("");
            //Wypisuje tablicę na ekran
            foreach (int element in tab)
            {
                Console.Write(element + " , ");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            #endregion
            #region CHECK TIME
            var watch = new Stopwatch();
            watch.Start();
            Build_HEAP_UP(tab);
            watch.Stop();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Czas build_HEAP_UP: {0} ms", 1000.0 * watch.ElapsedTicks / Stopwatch.Frequency);

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            var watch2 = new Stopwatch();
            watch2.Start();
            Build_HEAP_DOWN(tab);
            watch2.Stop();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Czas build_HEAP_DOWN: {0} ms", 1000.0 * watch2.ElapsedTicks / Stopwatch.Frequency);
            #endregion
            HeapSort();


            void heapify(int[] heap, int i)
            {
                try
                {
                    heap[0] = Rozmiar2;// Element 0 tablicy to jej rozmiar
                    int l = 2 * i; // lewy syn wybranego elementu i
                    int p = 2 * i + 1; // prawy syn wybranego elementu i

                    // szukam maks i przypisuje tej zmiennej indeks największej liczby
                    int maks = Math.Max(heap[l], Math.Max(heap[p], heap[i]));
                    for (int x = i; x <= i * 2 + 1; x++)
                    {
                        if (tab[x] == maks) maks = x;
                    }
                    //Console.WriteLine("Max indeks: {0}, Max wartość: {1}",maks,heap[maks]);

                    if (maks != i)
                    {
                        int pomocnicza = heap[i];
                        heap[i] = heap[maks];
                        heap[maks] = pomocnicza;

                        heapify(heap, maks);
                    }
                }
                catch (System.IndexOutOfRangeException) { }
            }
            void Build_HEAP_UP(int[] heap)
            {

                int i = 2;
                int j;
                int k;
                int x;

                for (i = 2; i <= Rozmiar2; i++)
                {
                    j = i; k = j / 2;
                    x = heap[i];
                    while ((k > 0) && (heap[k] < x))
                    {
                        heap[j] = heap[k];
                        j = k; k = j / 2;
                    }
                    heap[j] = x;
                }



                Console.WriteLine("");
                Console.WriteLine("Build HEAP UP :");
                Console.WriteLine("");
                foreach (var element in heap)
                {
                    Console.Write(element + " , ");
                }
            }
            void Build_HEAP_DOWN(int[] heap)
            {
                heap[0] = Rozmiar2;
                if (Rozmiar % 2 != 0)
                {
                    Rozmiar = (Rozmiar + 1) / 2 - 1;
                    for (int z = Rozmiar; z != 0; z--)
                    {
                        heapify(heap, z);
                    }
                }

                else if (Rozmiar % 2 == 0)
                {
                    Rozmiar = (Rozmiar + 1) / 2;
                    for (int c = Rozmiar; c != 0; c--)
                    {
                        heapify(heap, c);
                    }
                }


                Console.WriteLine("");
                Console.WriteLine("Build HEAP DOWN :");
                Console.WriteLine("");
                foreach (var element in heap)
                {
                    Console.Write(element + " , ");
                }
            }
            void HeapSort()
            {
                Build_HEAP(tab);
                void Build_HEAP(int[] heap)
                {
                    int i = 2;
                    int j;
                    int k;
                    int x;

                    for (i = 2; i <= Rozmiar2; i++)
                    {
                        j = i; k = j / 2;
                        x = heap[i];
                        while ((k > 0) && (heap[k] < x))
                        {
                            heap[j] = heap[k];
                            j = k; k = j / 2;
                        }
                        heap[j] = x;
                    }


                    for (i = Rozmiar2; i > 1; i--)
                    {
                        int t = heap[i];
                        heap[i] = heap[1];
                        heap[1] = t;

                        j = 1; k = 2; int m;
                        while (k < i)
                        {
                            if ((k + 1 < i) && (heap[k + 1] > heap[k]))
                                m = k + 1;
                            else
                                m = k;
                            if (heap[m] <= heap[j]) break;

                            int b = heap[j];
                            heap[j] = heap[m];
                            heap[m] = b;

                            j = m; k = j + j;
                        }
                    }
                    // komentarz

                    
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("HEAPSORT: ");
                    foreach (int element in heap)
                    {
                        Console.Write(element + " , ");
                    }

                }
                Console.ReadKey();
            }

        }
    }
}