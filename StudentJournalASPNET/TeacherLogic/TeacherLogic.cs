using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentJournalASPNET.Model;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace StudentJournalASPNET.TeacherLogic
{
    public class TeacherLogic : TeacherMethods
    {

        private Teacher teacher;
        private StudentsEntitiesModel studentEntity;

        public TeacherLogic(int teacherId)
        {
            studentEntity = new StudentsEntitiesModel();
            int id = studentEntity.TEACHERs.FirstOrDefault(t=>t.teacherId == teacherId).teacherId;
            string teacherName = studentEntity.TEACHERs.FirstOrDefault(t => t.teacherId == teacherId).teacherName;
            string teacherSurname = studentEntity.TEACHERs.FirstOrDefault(t => t.teacherId == teacherId).teacherSurname;
            int subjectId = studentEntity.TEACHERs.FirstOrDefault(t=>t.teacherId == teacherId).subjectId;

            teacher = new Teacher(id,teacherName, teacherSurname,subjectId);

        }

        public void AddMarkToStudent(int studentId,int subjectId,int markId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["StudentsConnectionString"].ConnectionString;
            using (SqlConnection sqlConnect = new SqlConnection(connectionString))
            {


                string command = "INSERT INTO [Students].[dbo].[StudentMarks] VALUES(@stuId,@subId,@mId)";
                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.Parameters.AddWithValue("@stuId", studentId);
                sqlCommand.Parameters.AddWithValue("@subId", subjectId);
                sqlCommand.Parameters.AddWithValue("@mId", markId);

                try
                {
                    sqlConnect.Open();

                    sqlCommand.Connection = sqlConnect;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = command;



                    sqlCommand.ExecuteNonQuery();
                    sqlConnect.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.GetBaseException());
                }
            }
            
        }

        public int GetStudentId(String pesel)
        {
            var studentId = (from student in studentEntity.Student
                             where student.Pesel == pesel
                             select student.id).FirstOrDefault();

            return studentId;
        }

        public int GetSubjectId()
        {
            var subjectId = (from subject in studentEntity.SubjectInfo
                               join thisTeacher in studentEntity.TEACHERs
                               on subject.SubjectId equals thisTeacher.subjectId
                               where thisTeacher.teacherId == teacher.teacherId
                               select subject.SubjectId).FirstOrDefault();

            return subjectId;
        }

        public int GetMarkId(int markNumber)
        {
            var markId = (from mark in studentEntity.Marks
                          where mark.MarkNumber == markNumber
                          select mark.MarkId).FirstOrDefault();

            return markId;
        }
        
        public void UpdateMarkToStudent(int studentId,int subjectId, int markId)
        {
            StudentMarks studentMarks = new StudentMarks();

            studentMarks.StudentId = studentId;
            studentMarks.SubjectId = subjectId;
            studentMarks.MarkId = markId;

            studentEntity.StudentMarks.Add(studentMarks);
            studentEntity.SaveChanges();
        }
        
        public void DeleteMarkToStudent(int studentId, int subjectId, int markId)
        {
            
        }

        public List<string> GetTeacherClasses()
        {
            var teacherClasses = (from classes in studentEntity.StudentClass
                                  join teacherClassId in studentEntity.TEACHERSCLASSes
                                  on classes.ClassId equals teacherClassId.CLASSID
                                  where teacherClassId.TEACHERID == teacher.teacherId
                                  select classes.ClassName).ToList();

            return teacherClasses;
        }

        public string GetTeacherName()
        {
            return teacher.teachersName;
        }

        public string GetTeacherSurname()
        {
            return teacher.teachersSurname;
        }

        public string GetTeacherSubjectName()
        {
            var subjectName = (from subject in studentEntity.SubjectInfo
                               join thisTeacher in studentEntity.TEACHERs
                               on subject.SubjectId equals thisTeacher.subjectId
                               where thisTeacher.teacherId == teacher.teacherId
                               select subject.SubjectName).FirstOrDefault();

            return subjectName;
        }
    }
}