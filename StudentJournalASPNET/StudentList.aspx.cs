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
        StudentRepository studentRepository;
        StudentCheckResult updateStudentResult;

        protected void Page_Load(object sender, EventArgs e)
        {
            studentRepository = new StudentRepository();
            InitializeDropDownLists();
            StudentGridView.DataSource = studentRepository.SelectAllStudents();
            StudentGridView.DataBind();
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
            StudentGridView.DataSource = studentRepository.SelectAllStudentsWhere(SelectClassList.Text);
            StudentGridView.DataBind();
        }

        protected void StudentAddButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherPage.aspx");
        }

        protected void ShowAllButton_Click(object sender, EventArgs e)
        {
            StudentGridView.DataSource = studentRepository.SelectAllStudents();
            StudentGridView.DataBind();
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            string date = DayDropDownList.Text + " " + MonthDropDownList.Text + " " + YearDropDownList.Text;

            Student student = new Student(PeselLabelText.Text, NameTextBox.Text, SurnameTextBox.Text, date, CityTextBox.Text, GenderDropDownList.Text, ClassChoose.Text);

            studentRepository.UpdateStudent(student);
        }

        protected void DeleteStudent_Click(object sender, EventArgs e)
        {
            string date = DayDropDownList.Text + " " + MonthDropDownList.Text + " " + YearDropDownList.Text;

            Student student = new Student(PeselLabelText.Text, NameTextBox.Text, SurnameTextBox.Text, date, CityTextBox.Text, GenderDropDownList.Text, ClassChoose.Text);

            studentRepository.DeleteStudent(student);

            StudentGridView.DataSource = studentRepository.SelectAllStudents();
            StudentGridView.DataBind();
            if (MultiView1.ActiveViewIndex >= 1)
                MultiView1.ActiveViewIndex--;
        }

        protected void StudentGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow studentRow = StudentGridView.SelectedRow;

            string Day = string.Empty;
            string Month = string.Empty;
            string Year = string.Empty;

            Student student = studentRepository.SelectStudentByPesel(studentRow.Cells[1].Text);
            for (int i = 0; i < 2; i++)
            {
                if (Char.IsDigit(student.BirthDate[i]))
                    Day += student.BirthDate[i];
            }
            for (int i = 3; i < 5; i++)
            {
                if (Char.IsDigit(student.BirthDate[i]))
                    Month += student.BirthDate[i];
            }
            for (int i = 6; i < 10; i++)
            {
                if (Char.IsDigit(student.BirthDate[i]))
                    Year += student.BirthDate[i];
            }
            PeselLabelText.Text = student.Pesel;
            NameTextBox.Text = student.Name;
            SurnameTextBox.Text = student.Surname;
            DayDropDownList.Text = Day;
            MonthDropDownList.Text = Month;
            YearDropDownList.Text = Year;
            GenderDropDownList.Text = student.Gender;
            CityTextBox.Text = student.City;
            ClassChoose.Text = student.Classes;

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