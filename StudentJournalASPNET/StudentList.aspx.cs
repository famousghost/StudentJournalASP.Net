using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentJournalASPNET
{
    public partial class StudentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowAllStudents();
        }

        protected void SelectClassList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentsConnectionString"].ConnectionString);
                connect.Open();

                string sortStudentByClassQuery = "Select S.[Pesel]" +
          ",S.[Name]" +
          ",S.[Surname]" +
          ",G.[name]" +
          ",S.[BirthDate]" +
          ",C.[CityName]" +
          ",SC.[ClassName]" +
      " FROM[Students].[dbo].[Student] S" +
      " JOIN City C" +
      " ON S.CityId = C.CityId" +
      " JOIN Gender G" +
      " ON S.GenderId = G.id" +
      " JOIN StudentClass SC" +
      " ON S.ClassId = Sc.ClassId" +
      " WHERE SC.[ClassName] LIKE '" + SelectClassList.Text + "'" +
      " order by S.Surname";
            SelectStudentSQL.SelectCommand = sortStudentByClassQuery;
            connect.Close();
            }
            catch (Exception ex)
            {
                Response.Write("error" + ex.ToString());
            }
        }

        protected void StudentAddButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherPage.aspx");
        }

        protected void ShowAllButton_Click(object sender, EventArgs e)
        {
            ShowAllStudents();
        }

        private void ShowAllStudents()
        {
            try
            {
                SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentsConnectionString"].ConnectionString);
                connect.Open();

                string AllStudentsSelectQuery = "Select S.[Pesel]" +
      ",S.[Name]" +
      ",S.[Surname]" +
      ",G.[name]" +
      ",S.[BirthDate]" +
      ",C.[CityName]" +
      ",SC.[ClassName]" +
  " FROM[Students].[dbo].[Student] S" +
  " JOIN City C" +
  " ON S.CityId = C.CityId" +
  " JOIN Gender G" +
  " ON S.GenderId = G.id" +
  " JOIN StudentClass SC" +
  " ON S.ClassId = Sc.ClassId" +
  " order by S.Surname";

                SelectStudentSQL.SelectCommand = AllStudentsSelectQuery;
                connect.Close();
            }
            catch (Exception ex)
            {
                Response.Write("error" + ex.ToString());
            }
        }
    }
}