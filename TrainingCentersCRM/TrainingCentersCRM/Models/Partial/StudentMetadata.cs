using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrainingCentersCRM.Models
{
    [Bind()]
    public class StudentMetadata
    {
        [StringLength(255, ErrorMessage = "Длина строки должна быть менее 256 символов")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [StringLength(255, ErrorMessage = "Длина строки должна быть менее 256 символов")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [StringLength(255, ErrorMessage = "Длина строки должна быть менее 256 символов")]
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
 
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Дата рождения")]
        public Nullable<int> DateOfBirth { get; set; }

        [StringLength(255, ErrorMessage = "Длина строки должна быть менее 256 символов")]
        [Display(Name = "Паспортные данные")]
        public string PassportData { get; set; }

        [StringLength(1023, ErrorMessage = "Длина строки должна быть менее 1024 символов")]
        [Display(Name = "Примечание")]
        public string Description { get; set; }
    }
}