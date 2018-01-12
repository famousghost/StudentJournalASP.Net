using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentJournalASPNET.TeacherLogic;

namespace StudentJournalASPNET
{
    public partial class TeacherPanel : System.Web.UI.Page
    {
        private StudentRepository studentRepository = new StudentRepository();

        private List<int> classList = new List<int>();

        private int teacherId;

        private TeacherLogic.TeacherLogic teacherLogic;

        protected void Page_Load(object sender, EventArgs e)
        {
            bool correct = Int32.TryParse(Session["teacherId"].ToString(),out teacherId);
            if (correct)
            {
                teacherLogic = new TeacherLogic.TeacherLogic(teacherId);
                if (!IsPostBack)
                {
                    MultiView1.SetActiveView(View1);
                    SetMarkDropDownList();

                    CurrentTeacherAdd();
                }
            }

            ShowStudentsByClasses(ListOfClasses.Text);

        }

        public void SetMarkDropDownList()
        {
            for(int i=1;i<=6;i++)
                MarkListDropDownList.Items.Add(i.ToString());
        }


        public void CurrentTeacherAdd()
        {
            TeacherNameLabel.Text = teacherLogic.GetTeacherName();
            TeacherSurnameLabel.Text = teacherLogic.GetTeacherSurname();
            TeacherSubjectName.Text = teacherLogic.GetTeacherSubjectName();
            ListOfClasses.DataSource = teacherLogic.GetTeacherClasses();
            ListOfClasses.DataBind();
        }

        public void ShowStudentsByClasses(string className)
        {
            StudentToMarkId.DataSource = studentRepository.SelectAllStudentsWhere(className);
            StudentToMarkId.DataBind();
        }

        protected void ListOfClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowStudentsByClasses(ListOfClasses.Text);
        }

        protected void StudentToMarkId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.Remove("Pesel");
            Session["Pesel"] = StudentToMarkId.SelectedRow.Cells[1].Text;
            
            if (MultiView1.ActiveViewIndex < 1)
                MultiView1.ActiveViewIndex++;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (MultiView1.ActiveViewIndex >= 1)
                MultiView1.ActiveViewIndex--;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Write(teacherLogic.GetStudentId(Session["Pesel"].ToString()));
            Response.Write(teacherLogic.GetSubjectId());
            Response.Write(teacherLogic.GetMarkId(Int32.Parse(MarkListDropDownList.Text)));
            teacherLogic.AddMarkToStudent(teacherLogic.GetStudentId(Session["Pesel"].ToString()),teacherLogic.GetSubjectId(),teacherLogic.GetMarkId(Int32.Parse(MarkListDropDownList.Text)));
        }

        protected void LogOutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }
    }
}