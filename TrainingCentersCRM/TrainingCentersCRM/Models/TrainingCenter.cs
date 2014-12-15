namespace TrainingCentersCRM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TrainingCenter
    {
        public TrainingCenter()
        {
            ScheduleTtrainingCourses = new HashSet<ScheduleTtrainingCours>();
            TrainingCenterCourses = new HashSet<TrainingCenterCours>();
            TrainingCenterTeachers = new HashSet<TrainingCenterTeacher>();
        }

        public int Id { get; set; }

        [StringLength(255, ErrorMessage = "����� ������ ������ ���� ����� 256 ��������")]
        [Display(Name = "�����")]
        public string Addres { get; set; }

        [StringLength(255, ErrorMessage = "����� ������ ������ ���� ����� 256 ��������")]
        [Display(Name = "�������")]
        public string Phone { get; set; }

        [StringLength(255, ErrorMessage = "����� ������ ������ ���� ����� 256 ��������")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [StringLength(255, ErrorMessage = "����� ������ ������ ���� ����� 256 ��������")]
        [Display(Name = "�����������")]
        public string Organization { get; set; }

        [StringLength(1023, ErrorMessage = "����� ������ ������ ���� ����� 1024 ��������")]
        [Display(Name = "����� �������� ������")]
        public string Description { get; set; }

        [Display(Name = "�������")]
        [Column(TypeName = "image")]
        public byte[] Logo { get; set; }

        [Required]
        [StringLength(255)]
        public string Url { get; set; }

        public virtual ICollection<ScheduleTtrainingCours> ScheduleTtrainingCourses { get; set; }

        public virtual ICollection<TrainingCenterCours> TrainingCenterCourses { get; set; }

        public virtual ICollection<TrainingCenterTeacher> TrainingCenterTeachers { get; set; }
    }
}
