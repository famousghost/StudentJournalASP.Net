using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentJournalASPNET.Model;

namespace StudentJournalASPNET
{
    public partial class StudentPanel : System.Web.UI.Page
    {
        StudentsEntitiesModel studentEntity = new StudentsEntitiesModel();


        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                AddDropDownList();
            }

            int subjectId = studentEntity.SubjectInfo.FirstOrDefault(s => s.SubjectName == SubjectIdDropDownList.Text).SubjectId;

            DisplaySubjectMarks(subjectId);
            DisplayName();
        }

        private void DisplaySubjectMarks(int id)
        {
            int studentId = Int32.Parse(Session["StudentId"].ToString());
            var displaySubject = (from studentMark in studentEntity.StudentMarks
                                  join subjectI in studentEntity.SubjectInfo
                                  on studentMark.SubjectId equals subjectI.SubjectId
                                  where studentMark.SubjectId == id && studentMark.StudentId == studentId
                                  select new
                                  {
                                      Przedmiot = subjectI.SubjectName,
                                      Ocena = studentMark.MarkId
                                  }).ToList();

            StudentMarkGridView.DataSource = displaySubject;
            StudentMarkGridView.DataBind();
        }

        private void DisplayName()
        {
            int studentId = Int32.Parse(Session["StudentId"].ToString());
            var studentName = studentEntity.Student.FirstOrDefault(x => x.id == studentId).Name;

            NameLabel.Text = studentName;
        }

        protected void LogOutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }

        private void AddDropDownList()
        {
            var listOfSubjects = studentEntity.SubjectInfo.Select(s => s.SubjectName).ToList();
            SubjectIdDropDownList.DataSource = listOfSubjects;
            SubjectIdDropDownList.DataBind();

        }
    }
}