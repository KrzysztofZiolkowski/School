using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    class Program
    {
        static void Main(string[] args)
        {
            #region START
            int indeks;
            int rozmiar;
            int wybor;
            int szukana;
            int szukanaNP;



            Console.WriteLine("Podaj rozmiar drzewa");
            rozmiar = Convert.ToInt32(Console.ReadLine());

            if (rozmiar <= 3)
            {
                Console.WriteLine("Uwaga: Aby BST ujanwiło swoje własności rozmiar powinien być większy niż 3");
                Console.ReadKey();
            }


            int[] tab = new int[rozmiar];
            int najwiekszy = tab[0];
            int najmniejszy = tab[0];
            #endregion
            #region MENU    
            do
            {
                Console.Clear();
                for (int i = 0; i < tab.Length; i++)
                {
                    Console.WriteLine("{0} element: {1}", i, tab[i]);
                }

                Console.WriteLine("");
                Console.WriteLine("===================");
                Console.WriteLine("=====BST MENU=====");
                Console.WriteLine("===================");
                Console.WriteLine("1. Dodaj liczbę");
                Console.WriteLine("2. Usuń liczbę ");
                Console.WriteLine("3. Znajdź określoną liczbę");
                Console.WriteLine("4. Znajdź następnik i poprzednik");
                Console.WriteLine("5. Znajdź Max i Min");
                Console.WriteLine("6. Zakończ");
                wybor = Convert.ToInt32(Console.ReadLine());

                switch (wybor)
                {
                    case 1:
                        Add(); break;
                    case 2:
                        Remove(); break;
                    case 3:
                        Search(); break;
                    case 4:
                        NextAndPrevious(); break;
                    case 5:
                        MaxMin(); break;

                }
            }
            while (wybor != 6);
            #endregion

            void Add()
            {
                try
                {
                    Console.WriteLine("Podaj liczbę");
                    int liczba = Convert.ToInt32(Console.ReadLine());
                    indeks = 0;


                    rekurencja();
                    int rekurencja()
                    {
                        if (tab[indeks] == 0) return tab[indeks] = liczba;
                        else
                        {
                            if (liczba <= tab[indeks]) { indeks = indeks * 2 + 1; return rekurencja(); }
                            else if (liczba > tab[indeks]) { indeks = indeks * 2 + 2; return rekurencja(); }
                            return 0;
                        }
                    }
                }

                catch (System.IndexOutOfRangeException)
                {
                    Console.WriteLine("Dla podanej liczby nie istnieje już pusty węzeł w drzewie o tym rozmiarze ");
                    Console.ReadKey();
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Podany argument musi być typu liczbowego");
                    Console.ReadKey();
                }


            }
            void MaxMin()
            {
                // jeżeli trzeba, zrobię implementację rekurencyjną zgodnie z filozofią drzewa.
                for (int x = 0; x < tab.Length; x++)
                {
                    if (tab[x] > najwiekszy)
                        najwiekszy = tab[x];
                }
                najmniejszy = tab[0];
                for (int y = 0; y < tab.Length; y++)
                {
                    if (tab[y] <= najmniejszy && tab[y] != 0)
                    {
                        najmniejszy = tab[y];
                    }

                }

                Console.WriteLine("MAX: {0}", najwiekszy);
                Console.WriteLine("MIN: {0}", najmniejszy);
                Console.ReadKey();
            }
            void Search()
            {
                Console.WriteLine("Wpisz szukaną liczbę");
                szukana = Convert.ToInt32(Console.ReadLine());
                indeks = 0;

                try
                {
                    rekurencja2();
                    int rekurencja2()
                    {
                        if (tab[indeks] == szukana) return indeks;
                        else
                        {
                            if (szukana <= tab[indeks]) { indeks = indeks * 2 + 1; return rekurencja2(); }
                            else if (szukana > tab[indeks]) { indeks = indeks * 2 + 2; return rekurencja2(); }
                            return 0;
                        }

                    }
                }

                catch (System.IndexOutOfRangeException)
                {
                    Console.WriteLine("Nie ma takiej liczby");
                }

                Console.WriteLine("Indeks: " + indeks);
                Console.ReadKey();

            }
            void Remove()
            {

                Search();

                try
                {
                    if (tab[indeks * 2 + 1] != 0 && tab[indeks * 2 + 2] != 0) // PIERWSZY WARUNEK
                    {
                        int pomocnicza = tab[indeks];
                        NextForRemove();
                        pomocnicza = tab[indeks];
                        tab[indeks] = 0;

                        Console.WriteLine("Zakończono pomyślnie");
                        Console.ReadKey();

                    }


                    //====================================================================================
                    else if (tab[indeks * 2 + 1] == 0 || tab[indeks * 2 + 2] == 0) // DRUGI WARUNEK
                    {
                        if (tab[indeks * 2 + 1] == 0)
                        {
                            tab[indeks] = tab[indeks * 2 + 2];
                            tab[indeks * 2 + 2] = 0;
                            Console.WriteLine("Jedyny syn stał się teraz ojcem");
                            Console.ReadKey();
                        }

                        else if (tab[indeks * 2 + 2] == 0)
                        {
                            tab[indeks] = tab[indeks * 2 + 1];
                            tab[indeks * 2 + 1] = 0;
                            Console.WriteLine("Jedyny syn stał się teraz ojcem");
                            Console.ReadKey();
                        }
                    }
                    //====================================================================================
                    else if (tab[indeks * 2 + 1] == 0 && tab[indeks * 2 + 2] == 0) // 3 WARUNEK
                    {
                        tab[indeks] = 0;
                        Console.WriteLine("Usunięto pomyślnie");
                        Console.ReadKey();
                    }
                    //====================================================================================


                }
                catch (System.IndexOutOfRangeException)
                { // jeśli indeks wykracza poza zakres talbicy, to wskazana wartość jest liściem.

                    tab[indeks] = 0;
                    Console.WriteLine("Usunięto pomyślnie");
                    Console.ReadKey();

                }

            }
            void NextAndPrevious()
            {
                #region NEXT
                // Wyszukuję liczbę
                Console.WriteLine("Podaj liczbę:");
                szukanaNP = Convert.ToInt32(Console.ReadLine());
                indeks = 0;
                try
                {
                    rekurencja3();
                    int rekurencja3()
                    {
                        if (tab[indeks] == szukanaNP) return indeks;
                        else
                        {
                            if (szukanaNP <= tab[indeks]) { indeks = indeks * 2 + 1; return rekurencja3(); }
                            else if (szukanaNP > tab[indeks]) { indeks = indeks * 2 + 2; return rekurencja3(); }
                            return 0;
                        }

                    }
                }

                catch (System.IndexOutOfRangeException)
                {
                    Console.WriteLine("Nie ma takiej liczby");
                }

                try
                {
                    // Jeżeli wczytana liczba to ostatnia liczba tablicy - nie ma następnika
                    if (indeks == tab.Length - 1)
                    { Console.WriteLine("Brak następnika, wybrana liczba jest największą"); Console.ReadKey(); }

                    // jeżeli wezel ma prawego syna, to przejdz na prawego syna i sprawdzaj czy ten syn ma lewego synta w pętli dopóki nie trafsz na pustego lewego syna
                    else if (tab[indeks * 2 + 2] != 0)
                    {

                        indeks = indeks * 2 + 2;
                        SzukajNastepnika();
                        int SzukajNastepnika()
                        {
                            if (tab[indeks] == 0) { return (indeks - 1) / 2; }
                            else if (tab[indeks] != 0) { indeks = indeks * 2 + 1; return SzukajNastepnika(); }
                            return 0;
                        }

                    }
                }
                catch (System.IndexOutOfRangeException)
                {
                    if (indeks % 2 == 0)
                    {
                        Console.WriteLine("Następnik: " + tab[(((indeks - 1) / 2) - 1) / 2]);
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Następnik: " + tab[(indeks - 1) / 2]);
                        Console.ReadKey();
                    }


                    #endregion
                    #region PREVIOUS
                    indeks = 0;
                    try
                    {
                        rekurencja3();
                        int rekurencja3()
                        {
                            if (tab[indeks] == szukanaNP) return indeks;
                            else
                            {
                                if (szukanaNP <= tab[indeks]) { indeks = indeks * 2 + 1; return rekurencja3(); }
                                else if (szukanaNP > tab[indeks]) { indeks = indeks * 2 + 2; return rekurencja3(); }
                                return 0;
                            }

                        }
                    }

                    catch (System.IndexOutOfRangeException)
                    {
                        Console.WriteLine("Nie ma takiej liczby");
                    }


                    try
                    {
                        if (tab[indeks * 2 + 2] == 0 && tab[indeks * 2 + 1] == 0)
                        {
                        }
                        else if (tab[indeks * 2 + 1] != 0)
                        {
                            indeks = indeks * 2 + 1;
                            SzukajPoprzednika();

                            int SzukajPoprzednika()
                            {
                                if (tab[indeks * 2 + 2] == 0) { return tab[indeks]; }
                                else if (tab[indeks] != 0) { indeks = indeks * 2 + 2; return SzukajPoprzednika(); }
                                return 0;
                            }

                        }

                    }

                    catch (System.IndexOutOfRangeException)
                    {
                        if (indeks % 2 == 0)
                        {
                            if (tab[indeks] > tab[(indeks - 2) / 2])
                            {
                                Console.WriteLine("Poprzednik: " + tab[indeks]);
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Poprzednik: " + tab[(indeks - 2) / 2]);
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            if (tab[indeks] < tab[(indeks - 1) / 2])
                            {
                                if (tab[indeks] == szukanaNP)
                                {
                                    Console.WriteLine("Wybrana liczba jest najmniejszą, brak poprzednika");
                                    Console.ReadKey();
                                }
                                else
                                    Console.Write("Poprzednik: " + tab[indeks]);
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Poprzednik: " + tab[(indeks - 1) / 2]);
                                Console.ReadKey();
                            }
                        }
                    }
                    #endregion


                }
            }
            void NextForRemove()
            {
                try
                {
                    // Jeżeli wczytana liczba to ostatnia liczba tablicy - nie ma następnika
                    if (indeks == tab.Length - 1)
                    { Console.WriteLine("Brak następnika, wybrana liczba jest największą"); Console.ReadKey(); }

                    // jeżeli wezel ma prawego syna, to przejdz na prawego syna i sprawdzaj czy ten syn ma lewego synta w pętli dopóki nie trafsz na pustego lewego syna
                    else if (tab[indeks * 2 + 2] != 0)
                    {

                        indeks = indeks * 2 + 2;
                        SzukajNastepnika();
                        int SzukajNastepnika()
                        {
                            if (tab[indeks] == 0) { return (indeks - 1) / 2; }
                            else if (tab[indeks] != 0) { indeks = indeks * 2 + 1; return SzukajNastepnika(); }
                            return 0;
                        }

                    }
                }
                catch (System.IndexOutOfRangeException)
                {
                    if (indeks % 2 == 0)
                    {
                        Console.WriteLine("Następnik: " + tab[(((indeks - 1) / 2) - 1) / 2]);
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Następnik: " + tab[(indeks - 1) / 2]);
                        Console.ReadKey();
                    }




                }
            }


        }
    }
}
    


                   
 
           
  

                
               
           
        
    