using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentJournalASPNET
{

    public enum AddStudentResult
    {
        FailedToAddStudent = 0,
        SuccessToAddStudent
    }

    public interface IStudentReposiotory
    {
        AddStudentResult CheckAddStudent(Student studentToAdd);
    }

    public class StudentRepository : IStudentReposiotory
    {

        AddStudentResult addStudentResult;

        Pesel pesel;

        public AddStudentResult CheckAddStudent(Student studentToAdd)
        {
            if (!Pesel.TryParse(studentToAdd.Pesel, out pesel))
            {
                addStudentResult = AddStudentResult.FailedToAddStudent;
            }
            else
            {
                addStudentResult = AddStudentResult.SuccessToAddStudent;
            }
            return addStudentResult;
        }
    }
}