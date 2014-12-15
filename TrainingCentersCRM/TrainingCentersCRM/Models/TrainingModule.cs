namespace TrainingCentersCRM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TrainingModule
    {
        public TrainingModule()
        {
            CourseModules = new HashSet<CourseModule>();
        }

        public int Id { get; set; }

        [StringLength(255, ErrorMessage = "����� ������ ������ ���� ����� 256 ��������")]
        [Display(Name = "��������")]
        public string Title { get; set; }

        [StringLength(1023, ErrorMessage = "����� ������ ������ ���� ����� 1024 ��������")]
        [Display(Name = "������� ��������")]
        public string ShortDescription { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "������������ ��������")]
        [Display(Name = "���������� ����� � ������� �����")]
        public int? Numbers { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "������������ ��������")]
        [Display(Name = "���������� ������������� �����")]
        public int? Hours { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "������������ ��������")]
        [Display(Name = "������ ���")]
        public int? Topics { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "������������ ��������")]
        [Display(Name = "������� �����")]
        public int? IdTrainingCenter { get; set; }

        public virtual ICollection<CourseModule> CourseModules { get; set; }
    }
}
