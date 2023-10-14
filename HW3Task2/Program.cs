using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HW3Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в игру!!! Сколько у Вас карт на руках? ");

            int number_of_cards = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 1; i <= number_of_cards; i++)
            {
                Console.Write($"Введите номинал {i} карты ");
                string nominal = Console.ReadLine();

                switch (nominal) 
                {
                    case "1":
                        sum += 1;
                        break;
                    case "2":
                        sum += 2;
                        break;
                    case "3":
                        sum += 3;
                        break;
                    case "4":
                        sum += 4;
                        break;
                    case "5":
                        sum += 5;
                        break;
                    case "6":
                        sum += 6;
                        break;
                    case "7":
                        sum += 7;
                        break;
                    case "8":
                        sum += 8;
                        break;
                    case "9":
                        sum += 9;
                        break;
                    case "10":
                        sum += 10;
                        break;
                    case "J":
                        sum += 10;
                        break;
                    case "Q":
                        sum += 10;
                        break;

                    default:
                        Console.WriteLine("Не верно введен номинал карты");
                        break;
                }
            }
            Console.WriteLine($"Сумма карт составляет {sum}");

            Console.ReadKey();
        }
    }
}
