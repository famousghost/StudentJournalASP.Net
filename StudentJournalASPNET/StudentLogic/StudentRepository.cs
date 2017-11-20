using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentJournalASPNET
{

    public enum StudentCheckResult
    {
        FailedToAddStudent = 0,
        SuccessToAddStudent
    }

    public interface IStudentReposiotory
    {
        StudentCheckResult CheckStudentInfo(Student studentToAdd);
    }

    public class StudentRepository : IStudentReposiotory
    {
        StudentCheckResult addStudentResult;

        Pesel pesel;

        public StudentCheckResult CheckStudentInfo(Student studentToAdd)
        {
            if (!Pesel.TryParse(studentToAdd.Pesel, out pesel))
            {
                addStudentResult = StudentCheckResult.FailedToAddStudent;
            }
            else
            {
                addStudentResult = StudentCheckResult.SuccessToAddStudent;
            }
            return addStudentResult;
        }
    }
}