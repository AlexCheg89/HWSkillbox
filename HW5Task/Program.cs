using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5Task
{
    internal class Program
    {
        /// <summary>
        /// Разделение по словам
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static string[] StringToWord(string text)
        {
            string[] words = text.Split(' ');

            return words;
        }

        /// <summary>
        /// Вывод слов в консоль
        /// </summary>
        /// <param name="text"></param>
        static void OutWordToConsole(string[] text)
        {
            foreach (var word in text)
            {
                Console.WriteLine(word);
            }
        }

        /// <summary>
        /// Изменение порядка слов
        /// </summary>
        /// <param name="text"></param>
        static void RewersWords (string text) 
        {
            string[] new_text = StringToWord(text);

            for (int i = new_text.Length -1;  i >= 0; i--)
            {
                Console.Write($"{new_text[i]} ");
            }
        }        

        static void Main(string[] args)
        {
            Console.Write("Введите предложение: ");
            string textofconsol = Console.ReadLine();

            OutWordToConsole(StringToWord(textofconsol));
            Console.WriteLine();

            RewersWords(textofconsol);

            Console.ReadKey();
        }
    }
}
