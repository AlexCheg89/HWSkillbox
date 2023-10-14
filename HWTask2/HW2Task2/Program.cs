using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fullName = "Иванов Иван Иванович"; // ФИО полностью
            byte age = 28;                            // Возраст студента
            string email = "ivanov@ya.ru";            // E-mail студента
            float progarmming_score = 5.00F;          // Бал по программированию
            float math_score = 4.00F;                 // Бал по математике
            float physics_score = 3.00F;              // Бал по физике

            Console.WriteLine($"Имя: {fullName,46}"); // Вывод ФИО
            Console.WriteLine($"Возраст: {age,24}");  // Вывод возраста
            Console.WriteLine($"Email: {email,36}");  // Вывод Email
            Console.WriteLine($"Баллы по программированию: {progarmming_score,5}"); // Вывод бала по программированию
            Console.WriteLine($"Баллы по математике: {math_score,11}"); // Вывод балла по математике
            Console.WriteLine($"Баллы по физике: {physics_score,15}");  // Вывод балла по физике

            Console.ReadKey();

            Console.WriteLine("____________________________________________________________________");

            float sum_score = progarmming_score + math_score + physics_score;

            string sum_scoreFormated = sum_score.ToString("##.##");
            Console.WriteLine($"Сумма баллов: {sum_scoreFormated,19}"); // Вывод суммы баллов

            Console.ReadKey();

            Console.WriteLine("____________________________________________________________________");

            float average_score = sum_score / 3;
            string average_scoreFormated = average_score.ToString("##.##");
            Console.WriteLine($"Средний балл: {average_scoreFormated,19}"); // Вывод среднего балла

            Console.ReadKey();

        }
    }
}
