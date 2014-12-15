namespace TrainingCentersCRM.Models
{

using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QualificationVacancy")]
    public partial class QualificationVacancy
    {
        public int Id { get; set; }

        public int? IdQualification { get; set; }

        public int? IdVacancy { get; set; }

        public virtual Qualification Qualification { get; set; }

        public virtual Vacancy Vacancy { get; set; }
    }
}
