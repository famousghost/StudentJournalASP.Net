using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentJournalASPNET
{
    public class CurrentUser
    {
        static private CurrentUser currentUser;
        public int userId { get; set;}
        public int teacherId { get; set; }
        public int studentId { get; set; }

        private CurrentUser(int userId,int teacherId,int studentId)
        {
            this.userId = userId;
            this.teacherId = teacherId;
            this.studentId = studentId;
        }

        private CurrentUser()
        {

        }

        public static CurrentUser GetUserInstance()
        {
            if (currentUser == null)
            {
                currentUser = new CurrentUser();
            }
            return currentUser;
        }

        public void SetUserData(int userId,int teacherId, int studentId)
        {
            this.userId = userId;
            this.teacherId = teacherId;
            this.studentId = studentId;
        }
    }
}