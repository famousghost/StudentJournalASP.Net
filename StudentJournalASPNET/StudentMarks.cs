//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentJournalASPNET
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentMarks
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int MarkId { get; set; }
    
        public virtual Marks Marks { get; set; }
        public virtual Student Student { get; set; }
        public virtual SubjectInfo SubjectInfo { get; set; }
    }
}
