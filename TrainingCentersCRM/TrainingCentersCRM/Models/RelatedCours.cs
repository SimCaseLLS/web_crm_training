namespace TrainingCentersCRM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RelatedCourses")]
    public partial class RelatedCours
    {
        public int Id { get; set; }

        public int? IdTrainingCourse { get; set; }

        public int? IdTrainingCourseRelated { get; set; }

        public virtual TrainingCours TrainingCours { get; set; }

        public virtual TrainingCours TrainingCours1 { get; set; }
    }
}
