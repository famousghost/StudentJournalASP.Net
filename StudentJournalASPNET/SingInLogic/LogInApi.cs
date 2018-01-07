using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentJournalASPNET.Model;

namespace StudentJournalASPNET.SingInLogic
{
    public class LogInApi
    {
        private LogIn logIn;
        private StudentsEntitiesModel studentModel;

        public LogInApi(string userName, string password)
        {
            logIn = new LogIn(userName, password);
            studentModel = new StudentsEntitiesModel();
        }

        public void UserLogIn()
        {
            if (logIn.userName != "" && logIn.password != "")
            {
                logIn.CheckUserName(studentModel.USERS.Where(u => u.userLogin == logIn.userName).FirstOrDefault().userLogin);

                logIn.CheckPassword(studentModel.USERS.Where(u => u.userPassword == logIn.password).FirstOrDefault().userPassword);
                if (logIn.GetLogInCheckerState() == LogInChecker.SuccesToLogIn)
                {
                    int logInLevel;
                    using (StudentsEntitiesModel studentEntityModel = new StudentsEntitiesModel())
                    {
                        logInLevel = studentEntityModel.USERS.Where(u => u.userLogin == logIn.userName).FirstOrDefault().LVL;
                    }
                    logIn.logInLevel = logInLevel;

                }
                
            }
        }

        public bool ErrorMessage()
        {
            if(logIn.GetLogInCheckerState() != LogInChecker.SuccesToLogIn)
            {
                return false;
            }
            return true;
        }

        public int GetLogInLevel()
        {
            return logIn.logInLevel;
        }

    }
}