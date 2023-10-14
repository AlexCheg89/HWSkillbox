using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ввод количества строк будущей матрицы

            Console.Write("Введите количество столбцов: ");
            int row = int.Parse(Console.ReadLine());

            // Ввод количетва столбцов в будущей матрицы

            Console.Write("Введите количество столбцов: ");
            int col = int.Parse(Console.ReadLine());
            Console.WriteLine();

            int[,] matrix = new int[row, col];

            Random r = new Random();

            int sum = 0;

            for (int i = 0; i < row; i++)
            {
                int rowSum = 0;
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = r.Next(10);          // Заполнение матрицы случайными числами
                    Console.Write($"{matrix[i,j]} ");   // Вывод полученной матрицы на экран
                    rowSum += matrix[i, j];
                }

                Console.WriteLine(); // Вывод полученной матрицы на экран

                sum += rowSum;
            }
            Console.WriteLine();

            // Вывод суммы всех элементов этой матрицы она экран
            Console.WriteLine($"Сумма всех элементов матрицы: {sum}");

            Console.ReadKey();
        }
    }
}
