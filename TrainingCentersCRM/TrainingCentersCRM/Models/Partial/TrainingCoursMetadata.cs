using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrainingCentersCRM.Models
{
    [Bind()]
    public class TrainingCoursMetadata
    {
        [StringLength(255, ErrorMessage = "Длина строки должна быть менее 256 символов")]
        [Display(Name = "Название")]
        public string Title { get; set; }

        [StringLength(1023, ErrorMessage = "Длина строки должна быть менее 1024 символов")]
        [Display(Name = "Краткое описание")]
        public string ShortDescription { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Количество часов")]
        public Nullable<int> Hourse { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Стоимость для организаций")]
        public Nullable<decimal> PriceForOrganizations { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Стоимость для физических лиц")]
        public Nullable<decimal> PriceForIndividuals { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Стоимость часа для организаций")]
        public Nullable<decimal> CostOfOneHourForOrganizations { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Стоимость часа для физических лиц")]
        public Nullable<decimal> CostOfOneHourForIndividuals { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Сложность")]
        public Nullable<int> LevelOfDifficulty { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Требуемая предварительная подготовка")]
        public string RequiredPreliminaryPreparation { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Обязательная предварительная подготовка")]
        public string MandatoryPreliminaryPreparation { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Учебный центр")]
        public Nullable<int> IdTraningCenter { get; set; }
    }
}