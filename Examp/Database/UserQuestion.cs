//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Examp.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserQuestion
    {
        public int UserQuestionID { get; set; }
        public int UserID { get; set; }
        public int QuestionID { get; set; }
    
        public virtual Question Question { get; set; }
        public virtual User User { get; set; }
    }
}