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

        /// <summary>
        /// Вывод основного меню
        /// </summary>
        static void Menu()
        {
            Console.WriteLine($"Выбирите действие");
            Console.WriteLine($"1. Вывести содержимое базы");
            Console.WriteLine($"2. Просмотреть запись по ID");
            Console.WriteLine($"3. Создание записи");
            Console.WriteLine($"4. Удаление записи");
            Console.WriteLine($"5. Редактирование записи");
            Console.WriteLine($"6. Вывести записи в диапозоне дат");
            Console.WriteLine($"7. Сортировка записей");
        }

        /// <summary>
        /// Вывод содержимого List
        /// </summary>
        /// <param name="temp"></param>
        static void OutputToConsole(List<Worker> temp)
        {
            foreach (var item in temp) 
            {
                Console.WriteLine(item.Print());
            }
        }

        static void Main(string[] args)
        {
            string file = "@staff.txt";
            Worker wk = new Worker();
            List<Worker> worker = new List<Worker>();
            char mode = 'н';
            char menuMode = '0';

            do
            {
                Menu();
                Console.Write($"Выбор действия: ");

                menuMode = Convert.ToChar(Console.ReadLine());

                switch (menuMode) 
                {
                    case '1':
                        worker = StaffRead(file);
                        OutputToConsole(worker);
                        break;
                    case '2':
                        worker = StaffRead(file);
                        uint zap = 0;
                        Console.Write($"Какую запись хотите вывести: ");
                        zap = Convert.ToUInt32(Console.ReadLine());
                        Console.WriteLine(worker.Find(item=>item.ID== zap).Print());

                        break;

                    case '3':
                        wk.Enter();
                        worker.Add(new Worker(wk.ID, wk.DateOfRecord, wk.Fio, wk.Age, wk.Height, wk.DateOfBirth, wk.PlaceOfBirth));
                        StaffWrite(file, wk);
                        
                        break;

                    case '4':
                        worker = StaffRead(file);
                        Console.Write($"Какую запись хотите удалить: ");
                        zap = Convert.ToUInt32(Console.ReadLine());
                        int delRecord = worker.FindIndex(item=>item.ID == zap);
                        worker.RemoveAt(delRecord);
                        OutputToConsole(worker);
                        StaffWrite(file, wk);

                        break;

                    case '5':
                        worker = StaffRead(file);
                        Console.Write($"Какую запись хотите редактировать: ");
                        zap = Convert.ToUInt32(Console.ReadLine());
                        int record = worker.FindIndex(item=> item.ID == zap);
                        Console.WriteLine($"Индекс записи: {record}");
                        wk.Enter();
                        worker[record] = new Worker(wk.ID, wk.DateOfRecord, wk.Fio, wk.Age, wk.Height, wk.DateOfBirth, wk.PlaceOfBirth);
                        OutputToConsole(worker);
                        StaffWrite(file, wk);

                        break;
                       
                    case '6':
                        worker = StaffRead(file);
                        Console.Write($"Введите начальную дату: ");
                        DateTime startDate = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine($"Начальна дата: {startDate}");
                        Console.Write($"Введите конечную дату: ");
                        DateTime endDate = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine($"Конечная дата: {endDate}");

                        for (int i = 0; i < worker.Count; i++)
                        {
                            if (worker[i].DateOfRecord >= startDate && worker[i].DateOfRecord <= endDate)
                            {
                                Console.WriteLine(worker[i].Print());
                            }
                        }
                     
                        break;

                    case '7':
                        worker = StaffRead(file);
                        char sortMode = '0';
                        Console.WriteLine($"1. Сортировка по возрастанию даты");
                        Console.WriteLine($"2. Сортировка по убыванию даты");
                        sortMode = Convert.ToChar(Console.ReadLine());

                        switch (sortMode)
                        {
                            case '1':
                                worker.Sort(delegate (Worker worker1, Worker worker2)
                                {
                                    return worker2.DateOfRecord.CompareTo(worker1.DateOfRecord);
                                });
                                OutputToConsole(worker);

                                break;

                            case '2':
                                worker.Sort(delegate (Worker worker1, Worker worker2)
                                {
                                    return worker2.DateOfRecord.CompareTo(worker1.DateOfRecord);
                                });
                                OutputToConsole(worker);

                                break;

                            default:
                                Console.WriteLine("Введите корректное значение");

                                break;
                        }
                        
                        break;

                    default:
                        Console.WriteLine("Введите корректное значение");

                        break;

                }

                Console.Write($"Вернуться в меню д/н: ");
                mode = Convert.ToChar(Console.ReadLine());

            } while (mode == 'д');

            Console.ReadKey();

        }
    }
}
