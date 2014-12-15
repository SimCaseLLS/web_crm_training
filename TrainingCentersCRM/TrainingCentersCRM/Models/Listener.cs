namespace TrainingCentersCRM.Models
{

using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Listener
    {
        public int Id { get; set; }

        public int? IdTrainingGroup { get; set; }

        public int? IdCourseTakings { get; set; }

        public virtual CourseTaking CourseTaking { get; set; }

        public virtual TrainingGroup TrainingGroup { get; set; }
    }
}
