
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
    
public partial class Program
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Program()
    {

        this.Assessments = new HashSet<Assessment>();

        this.CoursePrograms = new HashSet<CourseProgram>();

        this.ProgramAssessmentMappings = new HashSet<ProgramAssessmentMapping>();

        this.ProgramDepartments = new HashSet<ProgramDepartment>();

        this.ProgramSecurities = new HashSet<ProgramSecurity>();

        this.StudentPrograms = new HashSet<StudentProgram>();

    }


    public short ProgramID { get; set; }

    public string Number { get; set; }

    public string Name { get; set; }

    public bool IsActive { get; set; }

    public Nullable<System.DateTime> CreatedDateTime { get; set; }

    public Nullable<int> CreatedByLoginID { get; set; }

    public Nullable<System.DateTime> ModifiedDateTime { get; set; }

    public Nullable<int> ModifiedByLoginID { get; set; }

    public bool IsSharedProgram { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Assessment> Assessments { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<CourseProgram> CoursePrograms { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<ProgramAssessmentMapping> ProgramAssessmentMappings { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<ProgramDepartment> ProgramDepartments { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<ProgramSecurity> ProgramSecurities { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<StudentProgram> StudentPrograms { get; set; }

}

}
