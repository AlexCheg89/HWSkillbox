using System;
using System.Collections.Generic;


namespace HW8Task1
{
     internal class Program
    {
        /// <summary>
        /// Заполнение листа случайными числами от 0 до 100
        /// </summary>
        /// <param name="number">Коллекция чисел</param>
        /// <param name="lengthList">Количество чисел для заполнения</param>
        static void EnterList(List<int> number, int lengthList)
        {
            Random r = new Random();
            for (int i = 0; i < lengthList; i++)
            {
                number.Add(r.Next(0, 100));
            }
        }

        /// <summary>
        /// Вывод коллекции на экран
        /// </summary>
        /// <param name="number">Коллекция для вывода на экран</param>
        static void OutputList(List<int> number)
        {

            foreach (var item in number)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            //Console.WriteLine($"Количество элементов: {number.Count}");
            //Console.WriteLine("\n");
        }

        /// <summary>
        /// Удаление из листа числа, которые больше 25, но меньше 50 
        /// </summary>
        /// <param name="tempNumber">Коллекция чисел</param>
        /// <returns>Возвращает Коллекцию чисел после удаления</returns>
        static List<int> DeleteCorentNumberOfList(List<int> tempNumber)
        {
            for (int i = 0; i < tempNumber.Count; i++)
            {
                if (tempNumber[i] > 25 && tempNumber[i] < 50)
                {
                    tempNumber.Remove(tempNumber[i]);
                }
            }

            return tempNumber;
        }

        static void Main(string[] args)
        {
            // Создание листа целых чисел.
            List<int> number = new List<int>();

            // Заполните листа 100 случайными числами в диапозоне от 0 до 100.
            int lengthList = 100;

            EnterList(number, lengthList);

            // Вывод коллекции чисел на экран.
            Console.WriteLine("Заполненный лист из целлых чисел:");
            OutputList(number);

            // Удаления из листа числа, которые больше 25, но меньше 50.

            Console.WriteLine("Лист целых чисел после удаления значений которые больше 25 и меньше 50:");

            OutputList(DeleteCorentNumberOfList(number));

            Console.ReadKey();

        }
    }
}
