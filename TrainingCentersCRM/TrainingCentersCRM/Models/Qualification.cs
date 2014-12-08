//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrainingCentersCRM.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Qualification
    {
        public Qualification()
        {
            this.QualificationCertifications = new HashSet<QualificationCertification>();
            this.QualificationTrainingCours = new HashSet<QualificationTrainingCour>();
            this.QualificationVacancies = new HashSet<QualificationVacancy>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<int> Type { get; set; }
        public int ParentId { get; set; }
    
        public virtual ICollection<QualificationCertification> QualificationCertifications { get; set; }
        public virtual ICollection<QualificationTrainingCour> QualificationTrainingCours { get; set; }
        public virtual ICollection<QualificationVacancy> QualificationVacancies { get; set; }
    }
}
