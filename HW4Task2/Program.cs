using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HW4Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ввод длины последовательности
            Console.Write("Введите длину последовательности: ");
            int symbols = int.Parse(Console.ReadLine());
            int min = int.MaxValue;
            int counter = 0;
            int[] numbs = new int[symbols];

            // Ввод последовательности целых чисел
            for (int i = 0; i < numbs.Length; i++)
            {
                counter++;
                Console.Write($"{counter} число в массиве ");
                numbs[i] = int.Parse(Console.ReadLine());

                if (min> numbs[i]) min = numbs[i];
            }

            Console.WriteLine();

            Console.Write("Введенная Вами последовательность: ");

            foreach (var item in numbs) 
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
            Console.Write($"Минимальное число в массиве: {min}");

            Console.ReadKey();
        }
    }
}
