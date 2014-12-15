namespace TrainingCentersCRM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vacancy
    {
        public Vacancy()
        {
            QualificationVacancies = new HashSet<QualificationVacancy>();
        }

        public int Id { get; set; }

        [StringLength(1023, ErrorMessage = "����� ������ ������ ���� ����� 1024 ��������")]
        [Display(Name = "��������")]
        public string Description { get; set; }

        [StringLength(255, ErrorMessage = "����� ������ ������ ���� ����� 256 ��������")]
        [Display(Name = "�����������")]
        public string Organization { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "������������ ��������")]
        [Display(Name = "���������� �����")]
        [Column(TypeName = "money")]
        public Nullable<decimal> Wages { get; set; }

        [StringLength(1023, ErrorMessage = "����� ������ ������ ���� ����� 1024 ��������")]
        [Display(Name = "�������������� ����������")]
        public string Additionally { get; set; }

        [StringLength(255, ErrorMessage = "����� ������ ������ ���� ����� 256 ��������")]
        [Display(Name = "������ �� ���� � ���������� ���������")]
        public string Link { get; set; }

        public virtual ICollection<QualificationVacancy> QualificationVacancies { get; set; }
    }
}
