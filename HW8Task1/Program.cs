using System;
using System.Collections.Generic;


namespace HW8Task1
{
     internal class Program
    {
        /// <summary>
        /// Заполнение листа случайными числами от 0 до 100
        /// </summary>
        /// <param name="number"></param>
        /// <param name="lengthList"></param>
        static void EnterList(List<int> number, int lengthList)
        {
            Random r = new Random();
            for (int i = 0; i < lengthList; i++)
            {
                number.Add(r.Next(0, 100));
            }
        }

        /// <summary>
        /// Выход коллекции на экран
        /// </summary>
        /// <param name="number"></param>
        static void OutputList(List<int> number)
        {
            foreach (var item in number)
            {
                Console.WriteLine($"{item} ");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Удаление из листа числа, которые больше 25, но меньше 50 
        /// </summary>
        /// <param name="tempNumber"></param>
        /// <returns></returns>
        static List<int> DeleteCorentNumberOfList(List<int> tempNumber) 
        {
            for (int i = 0;i < tempNumber.Count; i++) 
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
            // Cоздание листа целых чисел.
            List<int> number = new List<int>();

            // Заполнение листа 100 случайными числами в диапазоне от 0 до 100.
            int lengthList = 100;

            EnterList(number, lengthList);

            // Вывод коллекции чисел на экран.
            Console.WriteLine("Заполненный лист из целых чисел:");
            OutputList(number);

            // Удаленпие из листа чисел, которые больше 25, но меньше 50.
            Console.WriteLine("Лист целых числе после удаления значений больше 25 и меньше 50:");
            OutputList(DeleteCorentNumberOfList(number));

            Console.ReadKey();
        }
    }
}
