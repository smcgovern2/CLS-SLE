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
    
    public partial class AssessmentRubric
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AssessmentRubric()
        {
            this.Outcomes = new HashSet<Outcome>();
            this.ProgramAssessmentMappings = new HashSet<ProgramAssessmentMapping>();
            this.ScoreTypes = new HashSet<ScoreType>();
            this.SectionRubrics = new HashSet<SectionRubric>();
        }
    
        public short RubricID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte AssessmentID { get; set; }
        public Nullable<byte> ScoreSetID { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public Nullable<int> CreatedByLoginID { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
        public Nullable<int> ModifiedByLoginID { get; set; }
        public bool IsActive { get; set; }
    
        public virtual Assessment Assessment { get; set; }
        public virtual ScoreSet ScoreSet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Outcome> Outcomes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProgramAssessmentMapping> ProgramAssessmentMappings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ScoreType> ScoreTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SectionRubric> SectionRubrics { get; set; }
    }
}
