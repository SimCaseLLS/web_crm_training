using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainingCentersCRM.Models
{
    public class CertificationTakingMetadata
    {
        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Студент")]
        public Nullable<int> IdStudent { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Сертификация")]
        public Nullable<int> IdCertification { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Дата")]
        public Nullable<int> Date { get; set; }

        [StringLength(255, ErrorMessage = "Длина строки должна быть менее 256 символов")]
        [Display(Name = "Результат")]
        public string Result { get; set; }
    }
}