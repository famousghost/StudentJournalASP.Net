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
    
    public partial class Marks
    {
        public Marks()
        {
            this.StudentMarks = new HashSet<StudentMarks>();
        }
    
        public int MarkId { get; set; }
        public string MarkName { get; set; }
        public int MarkNumber { get; set; }
    
        public virtual ICollection<StudentMarks> StudentMarks { get; set; }
    }
}
