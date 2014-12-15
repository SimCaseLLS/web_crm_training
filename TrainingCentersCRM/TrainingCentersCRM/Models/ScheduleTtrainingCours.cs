namespace TrainingCentersCRM.Models
{

using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ScheduleTtrainingCourses")]
    public partial class ScheduleTtrainingCours
    {
        public int Id { get; set; }

        [StringLength(256)]
        public string Title { get; set; }

        [StringLength(1023)]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateEnd { get; set; }

        public int? IdTrainingCenter { get; set; }

        public int? IdTrainingCourse { get; set; }

        public virtual TrainingCenter TrainingCenter { get; set; }

        public virtual TrainingCours TrainingCours { get; set; }
    }
}
