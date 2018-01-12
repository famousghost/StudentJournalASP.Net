using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentJournalASPNET.SingInLogic;
using StudentJournalASPNET.Model;
using StudentJournalASPNET.TeacherLogic;

namespace StudentJournalASPNET
{
    public partial class MainPage : System.Web.UI.Page
    {
        StudentsEntitiesModel studentEntity;

        protected void Page_Load(object sender, EventArgs e)
        {
            studentEntity = new StudentsEntitiesModel();
        }

        protected void LogInButton_Click(object sender, EventArgs e)
        {
            LogInApi logInApi = new LogInApi(LoginTextBox.Text,PasswordTextBox.Text);
            logInApi.UserLogIn();
            if (logInApi.ErrorMessage())
            {
                if (logInApi.GetLogInLevel() == 1)
                {
                    Response.Redirect("AdminPages.aspx");
                }
                else if (logInApi.GetLogInLevel() == 2)
                {
                    int teacherId = studentEntity.USERS.FirstOrDefault(t => (t.userLogin == LoginTextBox.Text && t.userPassword == PasswordTextBox.Text)).TeacherId.Value;
                    Session.Remove("teacherId");
                    Session["teacherId"] = teacherId;
                    Response.Redirect("TeacherPanel.aspx");
                }
                else if (logInApi.GetLogInLevel() == 3)
                {
                    int studentId = studentEntity.USERS.FirstOrDefault(t => (t.userLogin == LoginTextBox.Text && t.userPassword == PasswordTextBox.Text)).StudentId.Value;
                    Session.Remove("StudentId");
                    Session["StudentId"] = studentId;
                    Response.Redirect("StudentPanel.aspx");
                }
            }
            else
            {
                Response.Write("podałeś nieprawidłowe dane");
            }
        }
    }
}