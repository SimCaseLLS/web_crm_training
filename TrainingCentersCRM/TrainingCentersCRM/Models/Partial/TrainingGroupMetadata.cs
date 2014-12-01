using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrainingCentersCRM.Models
{
    [Bind()]
    public class TrainingGroupMetadata
    {
        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Учебный курс")]
        public Nullable<int> IdTrainingCourse { get; set; }

        [StringLength(255, ErrorMessage = "Смета затрат")]
        [Display(Name = "Название")]
        public string EstimateOfExpenditures { get; set; }
    }
}