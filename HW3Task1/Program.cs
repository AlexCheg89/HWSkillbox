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
            int en_new_number;

            do
            {
                Console.Write("Введите целое число ");

                int number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)

                    Console.WriteLine($"Введеное число {number} чётное");

                else
                    Console.WriteLine($"ВВеденое число {number} нечётное");

                Console.WriteLine();
                Console.Write("Чтобы повторить ввод чисел нажмите 1 ");
                en_new_number = int.Parse(Console.ReadLine());

                Console.WriteLine();
            }
            while (en_new_number == 1);

            Console.WriteLine("Досвидание!!!");
            
            
            Console.ReadKey();

        }
    }
}
