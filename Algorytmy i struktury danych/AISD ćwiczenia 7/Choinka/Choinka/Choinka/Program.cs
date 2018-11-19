using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choinka
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("Podaj ilosc poziomow choinki: ");
            int poziomy = Convert.ToInt32(Console.ReadLine());

            for (int j = 0; j < poziomy; j++)
                
            {
                Console.WriteLine("");
                for (int i = poziomy - 1; i > j; i--)
                        Console.Write("8");
                        for(int x=j*2; x>=0; x--)
                {
                    Console.Write("*");
                }
            }
            Console.ReadKey();

        }
    }

}



         