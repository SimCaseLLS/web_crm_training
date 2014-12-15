namespace TrainingCentersCRM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TrainingCenterTeacher
    {
        public int Id { get; set; }

        public int? IdTrainingCenter { get; set; }

        public int? IdTeacher { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual TrainingCenter TrainingCenter { get; set; }
    }
}
