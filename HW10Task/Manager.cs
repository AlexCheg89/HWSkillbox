using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace HW10Task
{
    internal class Manager : Account, IChange<Manager>, IComparable<Manager>
    {
        public Manager() { }
        public Manager(int id, string surName, string firstName, string patronymic, string phoneNumber, string passport)
            : base (id, surName, firstName, patronymic, phoneNumber, passport) 
        { 
            Id = id;
            Surname = surName;
            FirstName = firstName;
            Patronymic = patronymic;
            PhoneNumber = phoneNumber;
            _passport = passport;
        }

        /// <summary>
        /// Чтение аккаунтов из файла Accounts.txt
        /// </summary>
        /// <returns>возвращает список аккуантов</returns>
        public List<Manager> Read()
        {
            string path = "Accounts.txt";
            List<Manager> accounts = new List<Manager>();
            try
            {
                StreamReader sr = new StreamReader(path);
                
                List<string> accs = new List<string>();
                while (!sr.EndOfStream)
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split('#');
                        foreach (string part in parts)
                        {
                            accs.Add(part);
                        }
                        Manager ac = new Manager(Convert.ToInt32(accs[0]), accs[1], accs[2], accs[3], accs[4], accs[5]);
                        if (accs.Count > 6)
                        {
                            ac.TimeDataChange = Convert.ToDateTime(accs[6]);
                            ac.TypeChange = accs[7];
                            ac.WhoChange = accs[9];
                        }
                        accounts.Add(ac);
                        accs.Clear();
                    }

                }
                sr.Close();
                
            }
            catch (IOException)
            {
                File.Create(path);
            }

            return accounts;

        }

        /// <summary>
        /// перезапись списка аккуантов в файл
        /// </summary>
        /// <param name="list"></param>
        public void Write(List<Manager> list)
        {
            StreamWriter sw = new StreamWriter("Accounts.txt");
            foreach (Manager el in list)
            {
                sw.WriteLine(el.ToFile("#"));
            }
            sw.Close();
        }

        public Manager Changing(string newValue, Manager selectedAcc, int trigger)
        {
            switch (trigger)
            {
                case 0:
                    selectedAcc.Surname = newValue;
                    selectedAcc.Changes = "Surname";
                    selectedAcc.TypeChange = "изменение Surname";
                    break;
                case 1:
                    selectedAcc.FirstName = newValue;
                    selectedAcc.Changes = "FirstName";
                    selectedAcc.TypeChange = "изменение FirstName";
                    break;
                case 2:
                    selectedAcc.Patronymic = newValue;
                    selectedAcc.Changes = "Patronymic";
                    selectedAcc.TypeChange = "изменение Patronymic";
                    break;
                case 3:
                    selectedAcc.PhoneNumber = newValue;
                    selectedAcc.Changes = "PhoneNumber";
                    selectedAcc.TypeChange = "изменение PhoneNumber";
                    break;
                case 4:
                    selectedAcc._passport = newValue;
                    selectedAcc.Changes = "Passport";
                    selectedAcc.TypeChange = "изменние Passport";
                    break;
            }
            selectedAcc.TimeDataChange = DateTime.Now;
            selectedAcc.WhoChange = "Менеджер";
            return selectedAcc;
        }

        public int CompareTo(Manager other)
        {
            if (other == null) return 1;
            return this.Surname.CompareTo(other.Surname);

        }
    }
}
