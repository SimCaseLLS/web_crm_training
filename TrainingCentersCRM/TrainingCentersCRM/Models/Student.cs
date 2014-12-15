namespace TrainingCentersCRM.Models
{

using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student
    {
        public int Id { get; set; }

        [StringLength(255, ErrorMessage = "����� ������ ������ ���� ����� 256 ��������")]
        [Display(Name = "�������")]
        public string LastName { get; set; }

        [StringLength(255, ErrorMessage = "����� ������ ������ ���� ����� 256 ��������")]
        [Display(Name = "���")]
        public string FirstName { get; set; }

        [StringLength(255, ErrorMessage = "����� ������ ������ ���� ����� 256 ��������")]
        [Display(Name = "��������")]
        public string Patronymic { get; set; }

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "������������ �����")]
        [Display(Name = "E-mail")]
        [StringLength(255, ErrorMessage = "����� ������ ������ ���� ����� 256 ��������")]
        public string Email { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "������������ ��������")]
        [Display(Name = "���� ��������")]
        public Nullable<int> DateOfBirth { get; set; }

        [StringLength(255, ErrorMessage = "����� ������ ������ ���� ����� 256 ��������")]
        [Display(Name = "���������� ������")]
        public string PassportData { get; set; }

        [StringLength(1023, ErrorMessage = "����� ������ ������ ���� ����� 1024 ��������")]
        [Display(Name = "����������")]
        public string Description { get; set; }

        public int? IdObject { get; set; }
    }
}
