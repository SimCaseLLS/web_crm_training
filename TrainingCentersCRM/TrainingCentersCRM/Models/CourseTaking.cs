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

        [RegularExpression("[0-9]+", ErrorMessage = "������������ ��������")]
        [Display(Name = "�������")]
        public Nullable<int> IdStudent { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "������������ ��������")]
        [Display(Name = "������� ����")]
        public Nullable<int> IdTrainingCourse { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "������������ ��������")]
        [Display(Name = "������")]
        public Nullable<int> Status { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "������������ ��������")]
        [Display(Name = "���������� ����� �� ����")]
        [Column(TypeName = "money")]
        public Nullable<decimal> AmountPaid { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "������������ ��������")]
        [Display(Name = "����")]
        [Column(TypeName = "money")]
        public Nullable<decimal> Debt { get; set; }

        [StringLength(1023, ErrorMessage = "����� ������ ������ ���� ����� 1024 ��������")]
        [Display(Name = "����������")]
        public string Description { get; set; }

        [StringLength(10)]
        public string IdObecjt { get; set; }

        public virtual ICollection<Listener> Listeners { get; set; }

}

}
