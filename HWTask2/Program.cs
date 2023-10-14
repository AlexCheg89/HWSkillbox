using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWTask2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("// Вывод с использованием метода WriteLine");
            Console.WriteLine("Hello World!!!");
            Console.WriteLine(); // Пустая строка разделитель

            Console.WriteLine("// Вывод с использованием метода Write");
            Console.Write("Hello ");
            Console.Write("World");
            Console.Write("!!!");

            Console.ReadKey();
        }
    }
}
