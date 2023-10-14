using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ввод максимального числа диапазона (целое число)
            Console.Write("Введите максимальное число диапазона: ");
            int max_range_numb = int.Parse(Console.ReadLine());
                
            // Генерация случайных чисел (целое число) от 0 до введенного числа
            Random numb = new Random();
            var cpuNumb = numb.Next(0, max_range_numb);

            // Ввод пользователем числа
            while (true) 
            {
                Console.Write("Введите число: ");
                ConsoleKeyInfo userNumb = Console.ReadKey();

                if (userNumb.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine($"\nПопробуйте в другой раз. Загаданное число {cpuNumb}");
                    break;
                }

                if (int.Parse(userNumb.KeyChar.ToString()) < cpuNumb)
                {
                    Console.WriteLine("\nВведенное число меньше загаданного");
                    continue;
                }

                else if (int.Parse(userNumb.KeyChar.ToString()) > cpuNumb)
                {
                    Console.WriteLine("\nВведенное число больше загаданного");
                    continue;
                }

                else if (int.Parse(userNumb.KeyChar.ToString()) == cpuNumb)
                    Console.WriteLine($"\nВы угадали число {cpuNumb}");
                break;

            }

            Console.ReadKey();

        }
    }
}
