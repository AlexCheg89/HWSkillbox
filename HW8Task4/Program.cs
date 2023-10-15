using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;


namespace HW8Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "PhoneBook.xml";

            Console.Write("Введите ФИО: ");
            string name = Console.ReadLine();

            Console.Write("Введите улицу: ");
            string street = Console.ReadLine();

            Console.Write("Введите номер дома: ");
            uint houseNumber = Convert.ToUInt32(Console.ReadLine());

            Console.Write("Введите номер квартиры: ");
            uint flatNumber = Convert.ToUInt32(Console.ReadLine());

            Console.Write("Введите номер мобильного телефона: ");
            string mobilePhone = Console.ReadLine();

            Console.Write("Введите номер домашнего телефона: ");
            string flatPhone = Console.ReadLine();

            XDocument xdoc = new XDocument(new XElement("PhoneBook",
                new XElement("Person",
                    new XAttribute("Name", name),

                new XElement("Address",
                    new XElement("Street", street),
                    new XElement("HouseNumber", houseNumber),
                    new XElement("FlatNumber", flatNumber),
                new XElement("Phones",
                    new XElement("MobilePhone", mobilePhone),
                    new XElement("FlatPhone", flatPhone))))));
            
            xdoc.Save(path);

            Console.WriteLine("Файл создан");

            Console.ReadKey();
        }
    }
}
