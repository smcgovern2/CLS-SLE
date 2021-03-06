//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CLS_SLE.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SectionRubric
    {
        public int SectionRubricID { get; set; }
        public int SectionID { get; set; }
        public short RubricID { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string AssessmentLevelCode { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public Nullable<int> CreatedByLoginID { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
        public Nullable<int> ModifiedByLoginID { get; set; }
    
        public virtual AssessmentLevel AssessmentLevel { get; set; }
        public virtual AssessmentRubric AssessmentRubric { get; set; }
        public virtual Section Section { get; set; }
    }
}
