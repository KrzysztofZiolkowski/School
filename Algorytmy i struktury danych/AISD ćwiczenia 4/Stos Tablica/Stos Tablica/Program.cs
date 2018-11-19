using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Wybierz jedną ze struktur: stos lub kolejkę i napisz jej implementację tablicową
//Uwaga 1! Proszę napisać kod w taki sposób by łatwo było go przenieść do innego programu(przyda się przy grafach).
//Uwaga 2! Proszę unikać korzystania z wbudowanych bibliotek.

namespace Stos_Tablica
{

    class Program 
    {
        
       

        static void Main(string[] args)
        {
            int rozmiar;
            int[] tab = new int[6];

            //===============================Bieżący wynik========================================
            void Wyświetl_Stos()
            {
                Console.Clear();
                Console.WriteLine("Liczby w stosie:");

                for (int i = rozmiar; i >= 1; i--)
                {
                    Console.WriteLine(tab[i]);
                }

                if (rozmiar == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Stos jest pusty");
                    Console.WriteLine("===============");
                }


            }

            //===============================PUSH========================================
            void Push()
            {
                if(rozmiar==5)
                {
                    Console.WriteLine("STOS PEŁNY !!");
                    Console.ReadKey();
                }

              else
                {
                    Console.WriteLine("Jaką liczbę położyć na stosie?");
                    rozmiar = rozmiar + 1;
                    tab[rozmiar] = Convert.ToInt32(Console.ReadLine());

                }
            }
            //===============================POP========================================
            void Pop()
            {
                if (rozmiar >= 1)
                {
                    Console.WriteLine("Nastąpiło usunięcie liczby: {0} ze stosu ", tab[rozmiar]);
                    rozmiar = rozmiar - 1;
                    Console.ReadKey();
                }

                else
                {
                    Console.WriteLine("STOS JEST PUSTY");
                    Console.ReadKey();
                }

            }

            int wybor;
            rozmiar = 0;

            do
            {
                
                Wyświetl_Stos();

                Console.WriteLine("");
                Console.WriteLine("Co chcesz zrobić ? ");
                Console.WriteLine("1. (PUSH) Wprowadź kolejny element na stos");
                Console.WriteLine("2. (POP) Zabierz element ze stosu");
                Console.WriteLine("3. Zakończ");

                Console.WriteLine("");
                Console.WriteLine("Wybierz odpowiedni numer i wciśnij [Enter]");
                wybor = Convert.ToInt32(Console.ReadLine());

                switch (wybor)
                {
                    case 1:
                        Push();
                        break;

                    case 2:
                        Pop();
                        break;        

                }

            }
            while (wybor != 3);
            
            
        }


    }

}
