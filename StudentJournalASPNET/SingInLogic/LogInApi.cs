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

                try
                {
                    logIn.CheckUserName(studentModel.USERS.Where(u => (u.userLogin == logIn.userName && u.userPassword == logIn.password)).FirstOrDefault().userLogin);
                    logIn.CheckPassword(studentModel.USERS.Where(u => (u.userLogin == logIn.userName && u.userPassword == logIn.password)).FirstOrDefault().userPassword);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("nie poprawne dane");
                }
                if (logIn.GetLogInCheckerState() == LogInChecker.SuccesToLogIn)
                {
                    int logInLevel;
                    using (StudentsEntitiesModel studentEntityModel = new StudentsEntitiesModel())
                    {
                        try
                        {
                            logInLevel = studentEntityModel.USERS.Where(u => (u.userLogin == logIn.userName && u.userPassword == logIn.password)).FirstOrDefault().LVL;
                            logIn.logInLevel = logInLevel;
                        }
                        catch(Exception)
                        {
                            Console.WriteLine("bład");
                        }
                    }

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