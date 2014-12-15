namespace TrainingCentersCRM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class QualificationTrainingCour
    {
        public int Id { get; set; }

        public int? IdQualification { get; set; }

        public int? IdTrainingCours { get; set; }

        public virtual Qualification Qualification { get; set; }

        public virtual TrainingCours TrainingCours { get; set; }
    }
}
