using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentJournalASPNET.Model;
using StudentJournalASPNET.TeacherLogic;

namespace StudentJournalASPNET
{
    public partial class TeacherPanel : System.Web.UI.Page
    {
        private StudentRepository studentRepository = new StudentRepository();

        private StudentsEntitiesModel studentEntity = new StudentsEntitiesModel();

        private List<int> classList = new List<int>();

        int teacherId;

        Teacher teacher;

        protected void Page_Load(object sender, EventArgs e)
        {
            bool correct = Int32.TryParse(Session["teacherId"].ToString(),out teacherId);
            if (correct)
            {
                Response.Write(teacherId);
                Session.Remove("teacherId");
            }

            CurrentTeacherAdd();

           // int a = classList[1];

            //Response.Write(a);


        }


        public void CurrentTeacherAdd()
        {
            string teacherName = studentEntity.TEACHERs.FirstOrDefault(t => t.teacherId == teacherId).teacherName;
            string teacherSurname = studentEntity.TEACHERs.FirstOrDefault(t => t.teacherId == teacherId).teacherSurname;
            classList = studentEntity.TEACHERSCLASSes.Where(t => t.TEACHERID == teacherId).Select(x => x.TEACHERCLASSID).ToList();
        }



    }
}