namespace TrainingCentersCRM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TrainingModule
    {
        public TrainingModule()
        {
            CourseModules = new HashSet<CourseModule>();
        }

        public int Id { get; set; }

        [StringLength(255, ErrorMessage = "Длина строки должна быть менее 256 символов")]
        [Display(Name = "Название")]
        public string Title { get; set; }

        [StringLength(1023, ErrorMessage = "Длина строки должна быть менее 1024 символов")]
        [Display(Name = "Краткое описание")]
        public string ShortDescription { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Порядковый номер в учебном курсе")]
        public int? Numbers { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Количество академических часов")]
        public int? Hours { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Список тем")]
        public int? Topics { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Учебный центр")]
        public int? IdTrainingCenter { get; set; }

        public virtual ICollection<CourseModule> CourseModules { get; set; }
    }
}
