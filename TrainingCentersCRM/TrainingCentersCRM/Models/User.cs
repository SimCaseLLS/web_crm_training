namespace TrainingCentersCRM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class User
    {
        public int Id { get; set; }

        public string AspNetUserId { get; set; }

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
        [StringLength(255, ErrorMessage = "Длина строки должна быть менее 256 символов")]
        public string Email { get; set; }


        [StringLength(1023, ErrorMessage = "Длина строки должна быть менее 1024 символов")]
        [Display(Name = "Дополнительная информация")]
        public string Description { get; set; }
    }
}