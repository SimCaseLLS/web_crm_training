namespace TrainingCentersCRM.Models
{

using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CourseTaking
    {
        public CourseTaking()
        {
            Listeners = new HashSet<Listener>();
        }

        public int Id { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Студент")]
        public Nullable<int> IdStudent { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Учебный курс")]
        public Nullable<int> IdTrainingCourse { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Статус")]
        public Nullable<int> Status { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Оплаченная сумма за курс")]
        [Column(TypeName = "money")]
        public Nullable<decimal> AmountPaid { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Долг")]
        [Column(TypeName = "money")]
        public Nullable<decimal> Debt { get; set; }

        [StringLength(1023, ErrorMessage = "Длина строки должна быть менее 1024 символов")]
        [Display(Name = "Примечание")]
        public string Description { get; set; }

        [StringLength(10)]
        public string IdObecjt { get; set; }

        public virtual ICollection<Listener> Listeners { get; set; }

}

}
