using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentJournalASPNET
{
    
    public partial class TeacherPage : System.Web.UI.Page
    {
        bool studentIsExist = false;
        StudentRepository studentRepositoryCheck = new StudentRepository();
        AddStudentResult addStudentResult;
        protected void Page_Load(object sender, EventArgs e)
        {
            Test.Text = "";
            PeselValidatord.Text = "";
            InitializeDropDownLists();
            if (IsPostBack)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentsConnectionString"].ConnectionString);
                conn.Open();
                string selectQuery = "SELECT S.[id],S.[Pesel],S.[Name],S.[Surname],G.[name],S.[BirthDate],C.[CityName] FROM[Students].[dbo].[Student] S JOIN City C ON S.CityId = C.CityId JOIN Gender G ON S.GenderId = G.id";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                SqlDataSource1.SelectCommand = cmd.CommandText;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition(
           "jquery",
           new ScriptResourceDefinition
           {
               Path = "/Scripts/jquery-3.1.1.min.js",
               DebugPath = "/Scripts/jquery-3.1.1.js",
               CdnPath = "http://code.jquery.com/jquery-2.2.4.min.js",
               CdnDebugPath = "http://code.jquery.com/jquery-2.2.4.js",
               CdnSupportsSecureConnection = true,
               LoadSuccessExpression = "jQuery"
           });
        }

        private void ClearTextBoxes()
        {

        }

        private void ShowStudentList()
        {
            MultiView1.ActiveViewIndex += 1;
        }

        protected void SaveStudentButton_Click(object sender, EventArgs e)
        {
            string date = DayDropDownList.Text + " " + MonthDropDownList.Text + " " + YearDropDownList.Text;

            Student student = new Student(PeselTextBox.Text, NameTextBox.Text, SurnameTextBox.Text, date, CityTextBox.Text, GenderDropDownList.Text);

            addStudentResult = studentRepositoryCheck.CheckAddStudent(student);
            if (addStudentResult == AddStudentResult.SuccessToAddStudent)
            {
                try
                {
                    if (!studentIsExist)
                    {

                        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentsConnectionString"].ConnectionString);
                        conn.Open();
                        string checkuser = "select count(*) from Student where Pesel='" + PeselTextBox.Text + "'";
                        SqlCommand checkCmd = new SqlCommand(checkuser, conn);
                        int temp = Convert.ToInt32(checkCmd.ExecuteScalar().ToString());

                        if (temp == 1)
                        {

                            Response.Write("Student Already Exist");
                            studentIsExist = true;
                        }

                        if (!studentIsExist)
                        {

                            string insertQuery = "insert into Student(Pesel,Name,Surname,GenderId,BirthDate,CityId)values (@studentPesel,@studentName,@studentSurname,@studentGender,@studentBirthDate,@studentCity)";
                            SqlCommand cmd = new SqlCommand(insertQuery, conn);
                            cmd.Parameters.AddWithValue("@studentPesel", student.Pesel);
                            cmd.Parameters.AddWithValue("@studentName", student.Name);
                            cmd.Parameters.AddWithValue("@studentSurname", student.Surname);
                            cmd.Parameters.AddWithValue("@studentGender", student.Gender);
                            cmd.Parameters.AddWithValue("@studentBirthDate", student.BirthDate);
                            cmd.Parameters.AddWithValue("@studentCity", 3);
                            cmd.ExecuteNonQuery();

                            Response.Write("Student registeration Successfully!!!thank you");

                        }
                        conn.Close();
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("error" + ex.ToString());
                }

            }
            else if(addStudentResult == AddStudentResult.FailedToAddStudent)
            {
                PeselValidatord.Text = "Błędyny Pesel";
            }
        }

        private void InitializeDropDownLists()
        {
            for (int i = 1; i <= 31; i++)
            {
                if (i < 10)
                {
                    DayDropDownList.Items.Add("0" + i.ToString());
                }
                else
                {
                    DayDropDownList.Items.Add(i.ToString());
                }

            }
            for (int i = 1; i <= 12; i++)
            {
                if (i < 10)
                {
                    MonthDropDownList.Items.Add("0" + i.ToString());
                }
                else
                {
                    MonthDropDownList.Items.Add(i.ToString());
                }
            }
            for (int i = 1950; i <= 2012; i++)
            {
                YearDropDownList.Items.Add(i.ToString());
            }

        }

        protected void ShowStudentListButton_Click(object sender, EventArgs e)
        {
             ShowStudentList();
        }

        protected void BackToAddStudentButton_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex -= 1;
        }
    }
}