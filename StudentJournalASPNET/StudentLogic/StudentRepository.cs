using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentJournalASPNET.Model;

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

        List<Student> SelectAllStudents();

        List<Student> SelectAllStudentsWhere(string classOfStudent);

        Student SelectStudentByPesel(string pesel);

        void InsertStudent();
    }

    public class StudentRepository : IStudentReposiotory
    {
        StudentCheckResult addStudentResult;
        StudentsEntitiesModel studentEntity;

        Pesel pesel;

        public StudentRepository()
        {
            studentEntity = new StudentsEntitiesModel();
        }


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

        public List<Student> SelectAllStudents()
        {
            List<Student> studentList = new List<Student>();
            var selectedStudents = (from student in studentEntity.Student
                                   join city in studentEntity.City
                                   on student.CityId equals city.CityId
                                   join gender in studentEntity.Gender
                                   on student.GenderId equals gender.id
                                   join studentClass in studentEntity.StudentClass
                                   on student.ClassId equals studentClass.ClassId
                                   select new
                                   {
                                       Pesel = student.Pesel,
                                       Imię = student.Name,
                                       Nazwisko = student.Surname,
                                       Płeć = gender.name,
                                       DataUrodzenia = student.BirthDate,
                                       Miasto = city.CityName,
                                       Klasa = studentClass.ClassName
                                   }).ToList();

            foreach (var selectedStudent in selectedStudents)
            {
                Student student = new Student(selectedStudent.Pesel, selectedStudent.Imię, selectedStudent.Nazwisko, selectedStudent.DataUrodzenia, selectedStudent.Miasto, selectedStudent.Płeć, selectedStudent.Klasa);
                studentList.Add(student);
            }
            return studentList;
        }

        public List<Student> SelectAllStudentsWhere(string classOfStudent)
        {
            List<Student> studentList = new List<Student>();
            var selectedStudents = (from student in studentEntity.Student
                                    join city in studentEntity.City
                                    on student.CityId equals city.CityId
                                    join gender in studentEntity.Gender
                                    on student.GenderId equals gender.id
                                    join studentClass in studentEntity.StudentClass
                                    on student.ClassId equals studentClass.ClassId
                                    select new
                                    {
                                        Pesel = student.Pesel,
                                        Imię = student.Name,
                                        Nazwisko = student.Surname,
                                        Płeć = gender.name,
                                        DataUrodzenia = student.BirthDate,
                                        Miasto = city.CityName,
                                        Klasa = studentClass.ClassName
                                    }).ToList();

            var selectedStudentsWhere = selectedStudents.Where(s => s.Klasa == classOfStudent);

            foreach (var selectedStudent in selectedStudentsWhere)
            {
                Student student = new Student(selectedStudent.Pesel, selectedStudent.Imię, selectedStudent.Nazwisko, selectedStudent.DataUrodzenia, selectedStudent.Miasto, selectedStudent.Płeć, selectedStudent.Klasa);
                studentList.Add(student);
            }
            return studentList;
        }

        public void InsertStudent()
        {
            
        }

        public Student SelectStudentByPesel(string pesel)
        {
            Student thisStudent;
            var selectedStudents = (from student in studentEntity.Student
                                    join city in studentEntity.City
                                    on student.CityId equals city.CityId
                                    join gender in studentEntity.Gender
                                    on student.GenderId equals gender.id
                                    join studentClass in studentEntity.StudentClass
                                    on student.ClassId equals studentClass.ClassId
                                    select new
                                    {
                                        Pesel = student.Pesel,
                                        Imię = student.Name,
                                        Nazwisko = student.Surname,
                                        Płeć = gender.name,
                                        DataUrodzenia = student.BirthDate,
                                        Miasto = city.CityName,
                                        Klasa = studentClass.ClassName
                                    }).ToList();

            var selectedStudentsWhere = (selectedStudents.Where(s => s.Pesel == pesel)).SingleOrDefault();
            thisStudent = new Student(selectedStudentsWhere.Pesel, selectedStudentsWhere.Imię, selectedStudentsWhere.Nazwisko, selectedStudentsWhere.DataUrodzenia, selectedStudentsWhere.Miasto, selectedStudentsWhere.Płeć, selectedStudentsWhere.Klasa);

            return thisStudent;
        }
    }
}