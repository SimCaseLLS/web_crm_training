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
        public int Id { get; set; }

        public int? IdTrainingCenter { get; set; }

        public int? IdTrainingCourse { get; set; }

        public virtual TrainingCenter TrainingCenter { get; set; }

        public virtual TrainingCours TrainingCours { get; set; }
    }
}
