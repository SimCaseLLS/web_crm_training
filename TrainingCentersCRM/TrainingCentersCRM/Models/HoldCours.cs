namespace TrainingCentersCRM.Models
{

using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoldCourses")]
    public partial class HoldCours
    {
        public int Id { get; set; }

        public int? IdTrainingCourse { get; set; }

        public int? IdTrainingGroup { get; set; }

        public virtual TrainingCours TrainingCours { get; set; }

        public virtual TrainingGroup TrainingGroup { get; set; }
    }
}
