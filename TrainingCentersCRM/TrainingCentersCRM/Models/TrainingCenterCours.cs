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
    
    public partial class TrainingCenterCours
    {
        public int Id { get; set; }
        public Nullable<int> IdTrainingCenter { get; set; }
        public Nullable<int> IdTrainingCourse { get; set; }
    
        public virtual TrainingCenter TrainingCenter { get; set; }
        public virtual TrainingCours TrainingCours { get; set; }
    }
}