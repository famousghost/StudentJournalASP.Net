using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentJournalASPNET.SingInLogic
{
    public enum LogInChecker
    {
        SuccesToLogIn=0,
        LoginDoesNotExist,
        WrongPassword
    };

    interface ILogIn
    {
        void CheckPassword(string password);

        void CheckUserName(string userName);
    }

    public class LogIn : ILogIn
    {
        private LogInChecker logInChecker;
        public string userName { get; set; }
        public string password { get; set; }
        public int logInLevel { get; set; }

        public LogIn(string userName,string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public void CheckPassword(string password)
        {
            if(this.password != password)
            {
                logInChecker = LogInChecker.WrongPassword;
            }
        }

        public void CheckUserName(string userName)
        {
            if(this.userName != userName)
            {
                logInChecker = LogInChecker.LoginDoesNotExist;
            }
        }

        public LogInChecker GetLogInCheckerState()
        {
            return logInChecker;
        }
    }
}