namespace TrainingCentersCRM.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Certification
    {
        public Certification()
        {
            QualificationCertifications = new HashSet<QualificationCertification>();
        }

        public int Id { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Провайдер")]
        public int? IdProvider { get; set; }

        [StringLength(255, ErrorMessage = "Длина строки должна быть менее 256 символов")]
        [Display(Name = "Название")]
        public string Title { get; set; }

        [StringLength(1023, ErrorMessage = "Длина строки должна быть менее 1024 символов")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        public virtual CertificationProvider CertificationProvider { get; set; }

        public virtual ICollection<QualificationCertification> QualificationCertifications { get; set; }
    }
}