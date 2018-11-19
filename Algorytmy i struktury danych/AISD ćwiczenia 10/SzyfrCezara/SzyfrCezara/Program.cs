using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzyfrCezara
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("WPROWADŹ TEKST");
            String znak = Console.ReadLine();

            Console.WriteLine("PODAJ PRZESUNIĘCIE");
            int przesuniecie = Console.Read();

            Console.WriteLine("SZYFROWANIE");
            for (int i = 0; i < znak.Length; i++)
            {
                int liczba = znak.ElementAt(i);
                int x = 0;
                if (liczba > 96)
                    x = 97 + (liczba + przesuniecie - 93) % 26;
                else if (liczba == 32)
                    x = 32;
                else
                    x = 65 + (liczba + przesuniecie - 61) % 26;
                char zaszyfruj = (char)x;
                Console.Write("" + zaszyfruj);
            }
        }
    }
}

