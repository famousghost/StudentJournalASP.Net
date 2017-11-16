using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentJournalASPNET
{
    public class Student
    {
        //Variables
        public String Pesel { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get;  set; }
        public string City { get; set; }
        public int Gender { get; set; }
        public string Classes { get; set; }

        //constructor
        public Student(String Pesel, string Name, string Surname, string BirthDate, string City,string Gender,string Classes)
        {
            this.Pesel = Pesel;
            this.Name = Name;
            this.Surname = Surname;
            this.BirthDate = BirthDate;
            this.City = City;
            this.Classes = Classes;
            if(Gender == "Mężczyzna")
            {
                this.Gender = 1;
            }
            else
            {
                this.Gender = 2;
            }
            
        }

        //override Equals method from Object class
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Student student = obj as Student;

            var eq = (Pesel == student.Pesel);

            return eq;
        }


        //HashCode must be override if we override Equals method
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        //check This student by Pesel I use it in ERepository class
        public bool checkThisStudent(string Pesel)
        {
            if (this.Pesel == Pesel)
            {
                return true;
            }
            return false;
        }

    }
}