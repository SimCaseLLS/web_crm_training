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
    
    public partial class TrainingModule
    {
        public TrainingModule()
        {
            this.CourseModules = new HashSet<CourseModule>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public Nullable<int> Numbers { get; set; }
        public Nullable<int> Hours { get; set; }
        public Nullable<int> Topics { get; set; }
        public Nullable<int> IdTrainingCenter { get; set; }
    
        public virtual ICollection<CourseModule> CourseModules { get; set; }
    }
}