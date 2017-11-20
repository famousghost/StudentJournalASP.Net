using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentJournalASPNET.Model;

namespace StudentJournalASPNET
{
    public partial class StudentList : System.Web.UI.Page
    {
        StudentRepository studentRepositoryCheck = new StudentRepository();
        StudentCheckResult updateStudentResult;
        protected void Page_Load(object sender, EventArgs e)
        {
            InitializeDropDownLists();
            ShowAllStudents();
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

        protected void SelectClassList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowAllStudents(SelectClassList.Text);
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
            StudentsEntitiesModel studentEntity = new StudentsEntitiesModel();
            var selectedStudent = (from student in studentEntity.Student
                                   join city in studentEntity.City
                                   on student.CityId equals city.CityId
                                   join gender in studentEntity.Gender
                                   on student.GenderId equals gender.id
                                   join studentClass in studentEntity.StudentClass
                                   on student.ClassId equals studentClass.ClassId
                                   select new
                                   {
                                       Pesel = student.Pesel,
                                       Imię = student.Name,
                                       Nazwisko = student.Surname,
                                       Płeć = gender.name,
                                       DataUrodzenia = student.BirthDate,
                                       Miasto = city.CityName,
                                       Klasa = studentClass.ClassName
                                   }).ToList();

            StudentGridView.DataSource = selectedStudent;
            StudentGridView.DataBind();
        }

        private void ShowAllStudents(string ClassText)
        {
            StudentsEntitiesModel studentEntity = new StudentsEntitiesModel();
            var selectedStudent = (from student in studentEntity.Student
                                   join city in studentEntity.City
                                   on student.CityId equals city.CityId
                                   join gender in studentEntity.Gender
                                   on student.GenderId equals gender.id
                                   join studentClass in studentEntity.StudentClass
                                   on student.ClassId equals studentClass.ClassId
                                   select new
                                   {
                                       Pesel = student.Pesel,
                                       Imię = student.Name,
                                       Nazwisko = student.Surname,
                                       Płeć = gender.name,
                                       DataUrodzenia = student.BirthDate,
                                       Miasto = city.CityName,
                                       Klasa = studentClass.ClassName
                                   }).ToList();

            StudentGridView.DataSource = selectedStudent.Where(s => s.Klasa == ClassText);
            StudentGridView.DataBind();
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            string date = DayDropDownList.Text + " " + MonthDropDownList.Text + " " + YearDropDownList.Text;

            Student student = new Student(PeselTextBox.Text, NameTextBox.Text, SurnameTextBox.Text, date, CityTextBox.Text, GenderDropDownList.Text, ClassChoose.Text);
            updateStudentResult = studentRepositoryCheck.CheckStudentInfo(student);
            if (updateStudentResult == StudentCheckResult.SuccessToAddStudent)
            {
                StudentsEntitiesModel studentEntity = new StudentsEntitiesModel();
            }
        }

        protected void DeleteStudent_Click(object sender, EventArgs e)
        {

        }

        protected void StudentGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow studentRow = StudentGridView.SelectedRow;

            PeselTextBox.Text = studentRow.Cells[1].Text;
            NameTextBox.Text = studentRow.Cells[2].Text;
            SurnameTextBox.Text = studentRow.Cells[3].Text;
            GenderDropDownList.Text = studentRow.Cells[4].Text;
            CityTextBox.Text = studentRow.Cells[6].Text;
            ClassChoose.Text = studentRow.Cells[7].Text;
            if (MultiView1.ActiveViewIndex < 1)
                MultiView1.ActiveViewIndex++;
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            if (MultiView1.ActiveViewIndex >= 1)
                MultiView1.ActiveViewIndex--;
        }
    }
}