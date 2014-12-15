namespace TrainingCentersCRM.Models
{

using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QualificationCertification")]
    public partial class QualificationCertification
    {
        public int Id { get; set; }

        public int? IdQualification { get; set; }

        public int? IdCertification { get; set; }

        public virtual Certification Certification { get; set; }

        public virtual Qualification Qualification { get; set; }
        public virtual Qualification Qualifications { get; set; }
    }
}
