//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentJournalASPNET.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TEACHER
    {
        public TEACHER()
        {
            this.TEACHERSCLASSes = new HashSet<TEACHERSCLASS>();
            this.USERS = new HashSet<USER>();
        }
    
        public int teacherId { get; set; }
        public string teacherName { get; set; }
        public string teacherSurname { get; set; }
        public int subjectId { get; set; }
    
        public virtual SubjectInfo SubjectInfo { get; set; }
        public virtual ICollection<TEACHERSCLASS> TEACHERSCLASSes { get; set; }
        public virtual ICollection<USER> USERS { get; set; }
    }
}