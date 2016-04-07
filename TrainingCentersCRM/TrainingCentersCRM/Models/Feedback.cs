using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainingCentersCRM.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Имя")]
        [StringLength(250, ErrorMessage = "Заголовок не может быть больше 250 символов.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [StringLength(250, ErrorMessage = "Поле не может быть больше 250 символов.")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Сообщение")]      
        public string Message { get; set; }

        [Display(Name = "Дата")]   
        public DateTime Date { get; set; }

        [Display(Name="Учебный центр")]
        public TrainingCenter TrainingCenter { get; set; }
        public int IdTrainingCenter { get; set; }
    }
}