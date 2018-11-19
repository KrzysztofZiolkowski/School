using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stos.Obiektowo
{
    class Stos
    {
        int[] tablica;
        int rozmiar;
        int size;

        public Stos(int size)
        {
            tablica = new int[size];
            rozmiar = 0;
            this.size = size;
        }

        public void Push()
        {
            
            if (rozmiar == size)
            {
                Console.WriteLine("STOS PEŁNY !!");
                Console.ReadKey();
                Console.ReadLine();
            }

            else
            {
                Console.WriteLine("Jaką liczbę położyć na stosie?");
                rozmiar = rozmiar + 1;
                tablica[rozmiar] = Convert.ToInt32(Console.ReadLine());
                

            }
        }

        public void Pop()
        {

            if (rozmiar == 0) { Console.WriteLine("STOS JEST PUSTY!, NIE MOŻNA WYKONAĆ POP"); Console.ReadLine(); }
            else
            {
                Console.WriteLine("Usunąłeś liczbę {0} ze stosu", tablica[rozmiar]);
                rozmiar = rozmiar - 1;
                Console.ReadLine();
            }
        }

        public void Wyswietl_Stos()
        {
           
            
                Console.Clear();
                Console.WriteLine("Liczby w stosie:");

                
     
                    for(int i=rozmiar; i>=1; i--)
                    {
                    Console.WriteLine(tablica[i]);
                    }
               

                if (rozmiar == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Stos jest pusty");
                    Console.WriteLine("===============");
                }


            }



        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Podaj ile liczb ma mieścić stos");
                int z = Convert.ToInt32(Console.ReadLine());
                Stos obiekt1 = new Stos(z);

                Console.WriteLine("Ustawiono bufor na {0} elementów", z);

                int wybor;
                do
                {
                    obiekt1.Wyswietl_Stos();

                    Console.WriteLine("Co chcesz zrobić ? ");
                    Console.WriteLine("1. (PUSH) Wprowadź kolejny element na stos");
                    Console.WriteLine("2. (POP) Zabierz element ze stosu");
                    Console.WriteLine("3. Zakończ");
                    wybor = Convert.ToInt32(Console.ReadLine());
                    

                    switch (wybor)
                    {
                        case 1:
                            obiekt1.Push();
                            break;
                        case 2:
                            obiekt1.Pop();
                            break;
                    }

                }

                while (wybor != 3);
                
            }
        }
    }
}