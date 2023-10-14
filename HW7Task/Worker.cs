using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7Task
{
    internal struct Worker
    {
        #region Поля

        // id записи
        private uint id;

        // дата создания записи
        private DateTime dateOfRecord;

        // ФИО сотрудника
        private string fio;

        // Возраст сотрудника
        private uint age;

        // Рост сотрудника
        private uint height;

        // Дата рождения
        private string dateOfBirth;

        // Место рождения
        private string placeOfBirth;

        #endregion

        #region Свойства
        public uint ID { get { return this.id; } set { this.id = value; } }
        public DateTime DateOfRecord { get {  return this.dateOfRecord; } set { this.dateOfRecord = value; } }
        public string Fio { get { return this.fio; } set { this.fio = value; } }
        public uint Age { get { return this.age; } set { this.age = value; } }
        public uint Height { get { return this.height;} set { this.height = value; } }
        public string DateOfBirth { get {  return this.dateOfBirth; } set { this.dateOfBirth = value; } }
        public string PlaceOfBirth { get { return this.placeOfBirth;} set { this.placeOfBirth = value; } }

        public Worker(uint ID, DateTime DateOfRecord, string Fio, uint Age, uint Height, string DateOfBirth, string PlaceOfBirth)
        {
            this.id = ID;
            this.dateOfRecord = DateOfRecord;
            this.fio = Fio;
            this.age = Age;
            this.height = Height;
            this.dateOfBirth = DateOfBirth;
            this.placeOfBirth = PlaceOfBirth;
        }

        public Worker(uint ID) 
        { 
            this.id = ID;
            this.dateOfRecord = new DateTime();
            this.fio = null;
            this.age = 0;
            this.height = 0;
            this.dateOfBirth = null;
            this.placeOfBirth = null;
        }

        #endregion

        public void Enter()
        {
            Console.Write($"Введите ID: ");
            ID = Convert.ToUInt32(Console.ReadLine());

            DateOfRecord = DateTime.Now;
            DateTime dateNow = DateTime.Today;
            Console.WriteLine($"Дата и время записи: {DateOfRecord}");

            Console.WriteLine($"Введите ФИО сотрудника: ");
            Fio = Console.ReadLine();

            Console.Write($"Введите дату рождения (формат дд.мм.гггг): ");
            DateOfBirth = Console.ReadLine();

            Age = GetAge(dateNow, DateOfBirth);
            Console.WriteLine($"Возраст: {Age}");

            Console.Write("Введите рост сотрудника: ");
            Height = Convert.ToUInt32(Console.ReadLine());

            Console.Write("Введите место рождения: ");
            PlaceOfBirth = Console.ReadLine();
        }

        public string Print()
        {
            return $"{ID} {dateOfRecord} {Fio} {Age} {Height} {DateOfBirth} {PlaceOfBirth}";
        }

        public uint GetAge(DateTime today, string birthday)
        {
            DateTime birth = Convert.ToDateTime(birthday);

            if (today.Year >= birth.Year && today.Month >= birth.Month && today.Day >= birth.Day)
            {
                age = Convert.ToUInt32(today.Year - birth.Year);
            }
            else
            {
                age = Convert.ToUInt32(today.Year - birth.Year) - 1;
            }

            return Age;
        }

        public string ConvertToImportFile()
        {
            Program pr = new Program();
            return $"{ID}{pr.dilimer}{dateOfRecord}{pr.dilimer}{Fio}{pr.dilimer}{Age}{pr.dilimer}" +
                $"{Height}{pr.dilimer}{DateOfBirth}{pr.dilimer}{placeOfBirth}\n";
        }

        //public string ConvertExportFile()
        //{
        //    Program pr = new Program();

        //    return;
        //}
    }
}
