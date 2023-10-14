using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mail;
using System.Xml.Linq;

namespace HW6Task
{
    internal class Program
    {
        static string[] tabl;

        /// <summary>
        /// Чтение файла, вывод на экран содержимого массива
        /// </summary>
        /// <param name="text"></param>
        static void StaffRead(string text)
        {
            using (StreamReader sr = new StreamReader(text))
            {
                string line = sr.ReadToEnd();
                tabl = line.Split('\n');
            }
        }

        /// <summary>
        /// Вывод данных
        /// </summary>
        static void PrintData() 
        {
            foreach (var line in tabl) 
            {
                string[] data = line.Split('#');
                Console.WriteLine(string.Join(" ", data));
            }
        }

        /// <summary>
        /// Запись данных
        /// </summary>
        /// <param name="text"></param>
        /// <param name="datatowrite"></param>
        static void StaffWrite(string text, string[] datatowrite)
        {
            using (StreamWriter sw = new StreamWriter(text, true)) 
            {
                foreach (var line in datatowrite)
                {
                    sw.Write(line);
                }
                sw.WriteLine();
            }
        }

        /// <summary>
        /// Добавление разделителя # сохранние массива
        /// </summary>
        /// <param name="dilim"></param>
        /// <param name="datatodilim"></param>
        /// <returns></returns>
        static string[] Dilimiter(string dilim, string[] datatodilim)
        {
            string line = string.Join(dilim, datatodilim);
            string[] mass = line.Split('\n');

            return mass;
        }

        static void Main(string[] args)
        {
            string[] nametable = { "ID", "Дата и время добавления записи", "Ф.И.О", "Возраст", "Рост", "Дата рождения", "Место рождения" }; // Шапка в консоль
            string[] data = new string[7];
            string file = "staff.txt";
            string dilim = "#";

            char key = 'д';

            do
            {
                Console.WriteLine("Нажмите 1 - Для вывода данных на экран\n" + "Нажмите 2 - для ввода данных на экран");
                char mode = Char.Parse(Console.ReadLine());

                switch (mode)
                {
                    case '1':
                        // Вывод данных

                        Console.WriteLine();
                        Console.WriteLine($"{"ID",2} {"Дата и время записи",-20} {"Ф.И.О",-30} {"Возраст",4} {"Рост",3} {"Дата рождения",10} {"Место рождения",11}");

                        StaffRead(file);
                        PrintData();

                        Console.WriteLine();

                        break;

                    case '2':
                        // Ввод сотрудников в справочник
                        Console.WriteLine();
                        for (int i = 0; i < data.Length; i++)
                        {
                            if (i != 1)
                            {
                                Console.WriteLine($"Введите {nametable[i]} ");
                                data[i] = Console.ReadLine();
                            }
                            else
                            {
                                string now = DateTime.Now.ToString("g");
                                data[1] = now;
                            }
                        }
                        Console.WriteLine();
                        StaffWrite(file, Dilimiter(dilim, data));

                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }

                Console.Write($"Продолжить выполнение программы д/н ");
                key = char.Parse(Console.ReadLine());

            } while (key == 'д');

            Console.ReadKey();
            
        }
    }
}
