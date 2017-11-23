using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
        StudentCheckResult addStudentResult;
        protected void Page_Load(object sender, EventArgs e)
        {
            Test.Text = "";
            PeselValidatord.Text = "";
            InitializeDropDownLists();
            StudentExistLabel.Text = "";
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
            PeselTextBox.Text = "";
            NameTextBox.Text = "";
            SurnameTextBox.Text = "";
            GenderDropDownList.Text = "Mężczyzna";
            CityTextBox.Text = "";
            DayDropDownList.Text = "01";
            MonthDropDownList.Text = "01";
            YearDropDownList.Text = "1950";
            ClassChoose.Text = "A";
            
        }

        protected void SaveStudentButton_Click(object sender, EventArgs e)
        {
            string date = DayDropDownList.Text + " " + MonthDropDownList.Text + " " + YearDropDownList.Text;

            Student student = new Student(PeselTextBox.Text, NameTextBox.Text, SurnameTextBox.Text, date, CityTextBox.Text, GenderDropDownList.Text,ClassChoose.Text);

            addStudentResult = studentRepositoryCheck.CheckStudentInfo(student);
            if (addStudentResult == StudentCheckResult.SuccessToAddStudent)
            {
                try
                {
                    SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentsConnectionString"].ConnectionString);
                    connect.Open();
                    CheckIfStudentExist(connect,student);
                    if (!studentIsExist)
                    {
                        int genderId;
                        CheckIfCityExist(connect,student);
                        string insertQuery = "insert into Student(Pesel,Name,Surname,GenderId,BirthDate,CityId,ClassId)"
                            +"values(@studentPesel,@studentName,@studentSurname,@studentGender,@studentBirthDate"
                            +",(Select CityId from City where CityName LIKE '" + student.City + "'" + "),(Select ClassId from StudentClass Where ClassName LIKE '" + student.Classes + "'))";
                        SqlCommand cmd = new SqlCommand(insertQuery, connect);
                        if (student.Gender == "Mężczyzna")
                        {
                            genderId = 1;
                        }
                        else
                        {
                            genderId = 2;
                        }
                        cmd.Parameters.AddWithValue("@studentPesel", student.Pesel);
                        cmd.Parameters.AddWithValue("@studentName", student.Name);
                        cmd.Parameters.AddWithValue("@studentSurname", student.Surname);
                        cmd.Parameters.AddWithValue("@studentGender", genderId);
                        cmd.Parameters.AddWithValue("@studentBirthDate", student.BirthDate);
                        cmd.ExecuteNonQuery();

                        StudentExistLabel.ForeColor = Color.Green;
                        StudentExistLabel.Text = "Student został dodany poprawnie";
                        connect.Close();
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("error" + ex.ToString());
                }

            }
            else if(addStudentResult == StudentCheckResult.FailedToAddStudent)
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

        void CheckIfStudentExist(SqlConnection connect,Student student)
        {
            string checkuser = "select count(*) from Student where Pesel LIKE'" + student.Pesel + "'";
            SqlCommand checkUserCmd = new SqlCommand(checkuser, connect);
            int checkStudentExist = Convert.ToInt32(checkUserCmd.ExecuteScalar().ToString());

            if (checkStudentExist == 1)
            {

                StudentExistLabel.ForeColor = Color.Red;
                StudentExistLabel.Text = "Taki student już istnieje";
                studentIsExist = true;
            }
            else
            {
                studentIsExist = false;
            }

        }

        void CheckIfCityExist(SqlConnection connect,Student student)
        {
            string checkCityQuery = "select Count(*) from City where CityName LIKE'" + student.City + "'";
            SqlCommand checkCityCmd = new SqlCommand(checkCityQuery, connect);
            int checkCityExist = Convert.ToInt32(checkCityCmd.ExecuteScalar().ToString());
            if(checkCityExist < 1)
            {
                string insertCityQuery = "insert into City(CityName) values(@CityName)";
                SqlCommand insertCityCmd = new SqlCommand(insertCityQuery, connect);
                insertCityCmd.Parameters.AddWithValue("@CityName",student.City);
                insertCityCmd.ExecuteNonQuery();
            }


        }

        protected void ShowStudentListButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentList.aspx");
        }
    }
}