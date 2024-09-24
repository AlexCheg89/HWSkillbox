using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10Task
{
    internal class Account
    {
        public int Id { get; set; }

        public string Surname { get; set; }

        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        public string PhoneNumber { get; set; }

        protected string _passport { get; set; }

        public DateTime TimeDataChange { get; set; }
        public string Changes { get; set; }
        public string TypeChange { get; set; }
        public string WhoChange { get; set; }
        public DateTime DefaultDate = new DateTime();
        public string Passport {  get { return "**** ******"; } }
        public Account() { }

        public Account(int id, string surName, string firstName, string patronymic, string phoneNumber, string passport)
        {
            Id = id;
            Surname = surName;
            FirstName = firstName;
            Patronymic = patronymic;
            PhoneNumber = phoneNumber;
            _passport = passport;
        }

        public string ToFile(string sep)
        {
            if (this.TimeDataChange == DefaultDate)
            {
                return $"{this.Id}{sep}{this.Surname}{sep}{this.FirstName}{sep}{this.Patronymic}{sep}{this.PhoneNumber}{sep}{this._passport}";
            }
            else
            {
                return $"{this.Id}{sep}{this.Surname}{sep}{this.FirstName}{sep}{this.Patronymic}{sep}{this.PhoneNumber}{sep}{this._passport}{sep}{TimeDataChange}" +
                    $"{sep}{Changes}{sep}{TypeChange}{sep}{WhoChange}";
            }
        }
    }
}

