namespace TrainingCentersCRM.Models
{

using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RelatedCourses")]
    public partial class RelatedCourse
    {
        public RelatedCourse()
        {
        }
        public int Id { get; set; }

        public int? IdTrainingCourseRelated { get; set; }

        public virtual TrainingCenterCours TrainingCours { get; set; }

        public virtual TrainingCenterCours RelatedTrainingCourse { get; set; }

    }
}
