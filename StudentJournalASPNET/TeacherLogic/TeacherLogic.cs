using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentJournalASPNET.Model;

namespace StudentJournalASPNET.TeacherLogic
{
    public class TeacherLogic : TeacherMethods
    {

        private Teacher teacher;
        private List<string> teacherClasses;
        private StudentsEntitiesModel studentEntity;

        public TeacherLogic(string TeacherName)
        {
            studentEntity = new StudentsEntitiesModel();
            int id = studentEntity.TEACHERs.Where(x => x.teacherName == TeacherName).FirstOrDefault().teacherId;
            string teacherName = studentEntity.TEACHERs.Where(x=>x.teacherName == TeacherName).FirstOrDefault().teacherName;
            string teacherSurname = studentEntity.TEACHERs.Where(x => x.teacherName == TeacherName).FirstOrDefault().teacherSurname;

           // teacher = new Teacher(id,teacherName, teacherSurname);

        }

        public void AddMarkToStudent(int mark)
        {
            
        }

        public void UpdateMarkToStudent(int mark)
        {
            
        }

        public void DeleteMarkToStudent(int id)
        {
            
        }

        public List<string> GetTeacherClasses()
        {
            var allTeacherClass = (from Classe in studentEntity.StudentClass
                                   join Teach in studentEntity.TEACHERSCLASSes
                              on Classe.ClassId equals Teach.TEACHERCLASSID
                                   select new
                                   {
                                       teacherId = Teach.TEACHERID,
                                       StudentClassName = Classe.ClassName
                                   }).ToList();
            teacherClasses = allTeacherClass.Where(t => t.teacherId == teacher.teacherId).Select(s => s.StudentClassName).ToList();

            return teacherClasses;
        }
    }
}