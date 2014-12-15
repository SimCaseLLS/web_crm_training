namespace TrainingCentersCRM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vacancy
    {
        public Vacancy()
        {
            QualificationVacancies = new HashSet<QualificationVacancy>();
        }

        public int Id { get; set; }

        [StringLength(1023, ErrorMessage = "Длина строки должна быть менее 1024 символов")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [StringLength(255, ErrorMessage = "Длина строки должна быть менее 256 символов")]
        [Display(Name = "Организация")]
        public string Organization { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Заработная плата")]
        [Column(TypeName = "money")]
        public Nullable<decimal> Wages { get; set; }

        [StringLength(1023, ErrorMessage = "Длина строки должна быть менее 1024 символов")]
        [Display(Name = "Дополнительная информация")]
        public string Additionally { get; set; }

        [StringLength(255, ErrorMessage = "Длина строки должна быть менее 256 символов")]
        [Display(Name = "Ссылка на сайт с резмещеной вакансией")]
        public string Link { get; set; }

        public virtual ICollection<QualificationVacancy> QualificationVacancies { get; set; }
    }
}
