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

        [Display(Name = "Имя")]
        [StringLength(250, ErrorMessage = "Заголовок не может быть больше 250 символов.")]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        [StringLength(250, ErrorMessage = "Поле не может быть больше 250 символов.")]
        public string Email { get; set; }

        [Display(Name = "Сообщение")]      
        public string Message { get; set; }

        [Display(Name = "Дата")]   
        public DateTime Date { get; set; }
    }
}