namespace TrainingCentersCRM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Teacher
    {
        public Teacher()
        {
            TrainingCenterTeachers = new HashSet<TrainingCenterTeacher>();
            TrainingCourseTeachers = new HashSet<TrainingCourseTeacher>();
        }

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


        [StringLength(255, ErrorMessage = "����� ������ ������ ���� ����� 256 ��������")]
        [Display(Name = "�������")]
        public string Phone { get; set; }

        [StringLength(1023, ErrorMessage = "����� ������ ������ ���� ����� 1024 ��������")]
        [Display(Name = "�������������� ����������")]
        public string Description { get; set; }

        public virtual ICollection<TrainingCenterTeacher> TrainingCenterTeachers { get; set; }

        public virtual ICollection<TrainingCourseTeacher> TrainingCourseTeachers { get; set; }
    }
}
