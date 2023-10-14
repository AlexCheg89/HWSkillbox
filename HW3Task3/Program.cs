using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите целое число ");
            int n = int.Parse(Console.ReadLine());
            int i = 2;

            bool result = false;

            while (i <= n-1) 
            { 
                if (n%i==0) 
                    result = true;
                
                i++;
            }

            if (result == true) Console.WriteLine($"{n} - Не простое число!");
            else Console.WriteLine($"{n} - Просто число!");

            Console.ReadKey();           
        }
    }
}
