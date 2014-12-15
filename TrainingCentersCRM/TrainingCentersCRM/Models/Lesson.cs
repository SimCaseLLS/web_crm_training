namespace TrainingCentersCRM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lesson
    {
        public int Id { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "������������ ��������")]
        [Display(Name = "����� �������")]
        public Nullable<int> Time { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "������������ ��������")]
        [Display(Name = "�����������������")]
        public Nullable<int> Duration { get; set; }

        public int? IdObject { get; set; }
    }
}
