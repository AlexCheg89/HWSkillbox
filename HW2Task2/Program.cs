using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2Task2
{
    internal class Program
    {
        /// <summary>
        /// Ввод записи номер и ФИО
        /// </summary>
        /// <returns></returns>
        static (string, string) EnterPhoneBookRecord()
        {
            Console.Write("Введите номер телефона (9XXXXXXXXX): ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Введите ФИО Владельца: ");
            string fio = Console.ReadLine();
            var result = (phoneNumber, fio);

            return result;
        }

        /// <summary>
        /// Поиск владельца по номеру
        /// </summary>
        /// <param name="phoneBook"></param>
        static void NumberOwnerSearching(Dictionary<string, string> phoneBook) 
        {
            Console.WriteLine($"Поиск по номеру телефона");
            Console.Write($"Введите номер телефона (9XXXXXXXXX): ");
            string phoneNumber = Console.ReadLine();

            if (phoneBook.TryGetValue(phoneNumber, out string fio))
            {
                Console.WriteLine($"ФИО владельца: {phoneBook[phoneNumber]}");
            }
            else Console.WriteLine($"$Владелец номера {phoneNumber} не зарегистрирован");
        }

        static void OutputToConsole(Dictionary<string, string> phoneBook)
        {
            foreach (KeyValuePair<string, string> e in phoneBook) Console.WriteLine($"{e} );
        }

        static void Main(string[] args)
        {
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();

            char choice = 'н';

            // Ввод записей и добавление в коллекцию Dictionary c добаэвлением новой записи

            do
            {
                var tuple = EnterPhoneBookRecord();
                phoneBook.Add(tuple.Item1, tuple.Item2);

                Console.Write("Ввести новую запись? (д/н): ");
                choice = Convert.ToChar(Console.ReadLine());

            } while (choice == 'д');

            // Вывод содердимого на экран
            OutputToConsole(phoneBook);

            // Поиск владельца по введенному номеру
            NumberOwnerSearching(phoneBook);

            Console.ReadKey();
        }
    }
}
