﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentJournalASPNET.TeacherLogic
{

    interface TeacherMethods
    {
        void AddMarkToStudent(int mark);

        void UpdateMarkToStudent(int mark);

        void DeleteMarkToStudent(int id);


    }

    public class Teacher
    {
        public int teacherId { get; set; }
        public string teachersName { get; set; }
        public string teachersSurname { get; set; }
        public int subjectId { get; set; }


        public Teacher(int teacherId, string teachersName, string teachersSurname,int subjectId)
        {
            this.teacherId = teacherId;
            this.teachersName = teachersName;
            this.teachersSurname = teachersSurname;
            this.subjectId = subjectId;
        }
    }
}