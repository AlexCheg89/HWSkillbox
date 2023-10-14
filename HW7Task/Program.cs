using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HW7Task
{
    internal class Program
    {
        public char dilimer = '#';

        /// <summary>
        /// Чтение файла, вывод на экран содержимое массива
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static List<Worker> StaffRead(string text)
        {
            Program pr = new Program();
            List<Worker> worker = new List<Worker>();

            using (StreamReader sr = new StreamReader(text))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split(pr.dilimer);
                    worker.Add(new Worker(Convert.ToUInt32(args[0]),
                        Convert.ToDateTime(args[1]),
                        args[2],
                        Convert.ToUInt32(args[3]),
                        Convert.ToUInt32(args[4]),
                        args[5],
                        args[6]));
                }
            }
            return worker;
        }

        /// <summary>
        /// Запись данных
        /// </summary>
        /// <param name="text"></param>
        /// <param name="worker"></param>
        static void StaffWrite(string text, Worker worker)
        {
            using (StreamWriter sw = new StreamWriter(text, true)) 
            {
                sw.Write(worker.ConvertToImportFile());
            }
        }

        static void Menu()
        {
            Console.WriteLine($"Выбирите действие");
            Console.WriteLine($"1. Вывести содержимое базы");
            Console.WriteLine($"2. Просмотреть запись по ID");
            Console.WriteLine($"3. Создание записи");
            Console.WriteLine($"4. )
        }

        static void Main(string[] args)
        {
        }
    }
}
