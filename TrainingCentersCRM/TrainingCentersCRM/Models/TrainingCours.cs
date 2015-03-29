namespace TrainingCentersCRM.Models
{

using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrainingCourses")]
    public partial class TrainingCours
    {
        public TrainingCours()
        {
            CourseModules = new HashSet<CourseModule>();
            HoldCourses = new HashSet<HoldCours>();
            QualificationTrainingCours = new HashSet<QualificationTrainingCour>();
            RelatedCourses = new HashSet<RelatedCours>();
            RelatedCourses1 = new HashSet<RelatedCours>();
            ScheduleTtrainingCourses = new HashSet<ScheduleTtrainingCours>();
            TrainingCenterCourses = new HashSet<TrainingCenterCours>();
            TrainingCourseTeachers = new HashSet<TrainingCourseTeacher>();
        }

        public int Id { get; set; }

        [StringLength(255, ErrorMessage = "Длина строки должна быть менее 256 символов")]
        [Display(Name = "Название")]
        public string Title { get; set; }

        [StringLength(2048, ErrorMessage = "Длина строки должна быть менее 1024 символов")]
        [Display(Name = "Краткое описание")]
        public string ShortDescription { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Количество часов")]
        public Nullable<int> Hourse { get; set; }

        [RegularExpression(@"^[\d,]+(\.\d{1,5})?$", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Стоимость для организаций")]
        [Column(TypeName = "money")]
        public Nullable<decimal> PriceForOrganizations { get; set; }

        [RegularExpression(@"^[\d,]+(\.\d{1,5})?$", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Стоимость для физических лиц")]
        [Column(TypeName = "money")]
        public Nullable<decimal> PriceForIndividuals { get; set; }

        [RegularExpression(@"^[\d,]+(\.\d{1,5})?$", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Стоимость часа для организаций")]
        [Column(TypeName = "money")]
        public Nullable<decimal> CostOfOneHourForOrganizations { get; set; }

        [RegularExpression(@"^[\d,]+(\.\d{1,5})?$", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Стоимость часа для физических лиц")]
        [Column(TypeName = "money")]
        public Nullable<decimal> CostOfOneHourForIndividuals { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Сложность")]
        public Nullable<int> LevelOfDifficulty { get; set; }

        [Display(Name = "Требуемая предварительная подготовка")]
        [StringLength(1023, ErrorMessage = "Длина строки должна быть менее 1024 символов")]
        public string RequiredPreliminaryPreparation { get; set; }

        [Display(Name = "Обязательная предварительная подготовка")]
        [StringLength(1023, ErrorMessage = "Длина строки должна быть менее 1024 символов")]
        public string MandatoryPreliminaryPreparation { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Учебный центр")]
        public Nullable<int> IdTraningCenter { get; set; }

        public int? IdObject { get; set; }

        public virtual ICollection<CourseModule> CourseModules { get; set; }

        public virtual ICollection<HoldCours> HoldCourses { get; set; }

        public virtual ICollection<QualificationTrainingCour> QualificationTrainingCours { get; set; }

        public virtual ICollection<RelatedCours> RelatedCourses { get; set; }

        public virtual ICollection<RelatedCours> RelatedCourses1 { get; set; }

        public virtual ICollection<ScheduleTtrainingCours> ScheduleTtrainingCourses { get; set; }

        public virtual ICollection<TrainingCenterCours> TrainingCenterCourses { get; set; }

        public virtual ICollection<TrainingCourseTeacher> TrainingCourseTeachers { get; set; }
    }

}
