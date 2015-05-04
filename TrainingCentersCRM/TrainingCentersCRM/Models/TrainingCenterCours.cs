namespace TrainingCentersCRM.Models
{

using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrainingCenterCourses")]
    public partial class TrainingCenterCours
    {
        public TrainingCenterCours()
        {
            Teachers = new HashSet<Teacher>();
            RelatedCourses = new HashSet<RelatedCourse>();
        }
        public int Id { get; set; }

        public int? IdTrainingCenter { get; set; }
        public virtual TrainingCenter TrainingCenter { get; set; }


        public int? IdTrainingCourse { get; set; }
        public virtual TrainingCours TrainingCours { get; set; }


        public ICollection<Teacher> Teachers { get; set; }

        public ICollection<RelatedCourse> RelatedCourses { get; set; }
        
    }
}
