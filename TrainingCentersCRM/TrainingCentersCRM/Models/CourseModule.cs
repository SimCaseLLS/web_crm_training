namespace TrainingCentersCRM.Models
{

using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CourseModule
    {
        public int Id { get; set; }

        public int? IdTrainingCourse { get; set; }

        public int? IdTrainingModule { get; set; }

        public virtual TrainingCours TrainingCours { get; set; }

        public virtual TrainingModule TrainingModule { get; set; }
    }
}
