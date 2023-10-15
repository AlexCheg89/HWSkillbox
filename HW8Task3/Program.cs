using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> set = new HashSet<int>(new int[] { 10 });

            int numberOfConsole;

            Console.Write($"Введите число: ");
            numberOfConsole = Convert.ToInt32(Console.ReadLine());

            if (set.Contains(numberOfConsole))
            {
                Console.WriteLine($"Число {numberOfConsole} присутствует в коллекции");
            }
            else
            {
                Console.WriteLine($"Число {numberOfConsole} добавлено в коллекцию");
                set.Add(numberOfConsole);
            }

            Console.ReadKey();
        }
    }
}
