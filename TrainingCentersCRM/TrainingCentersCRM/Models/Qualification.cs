namespace TrainingCentersCRM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Qualification
    {
        public Qualification()
        {
            QualificationCertifications = new HashSet<QualificationCertification>();
            QualificationTrainingCours = new HashSet<QualificationTrainingCour>();
            QualificationVacancies = new HashSet<QualificationVacancy>();
        }

        public int Id { get; set; }

        [StringLength(255, ErrorMessage = "Длина строки должна быть менее 256 символов")]
        [Display(Name = "Название")]
        public string Title { get; set; }

        [StringLength(1023, ErrorMessage = "Длина строки должна быть менее 1024 символов")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Тип")]
        public Nullable<int> Type { get; set; }

        public virtual ICollection<QualificationCertification> QualificationCertifications { get; set; }

        public virtual ICollection<QualificationTrainingCour> QualificationTrainingCours { get; set; }

        public virtual ICollection<QualificationVacancy> QualificationVacancies { get; set; }
    }
}
