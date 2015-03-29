namespace TrainingCentersCRM.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Teacher : User
    {
        public Teacher()
        {
            TrainingCenterTeachers = new HashSet<TrainingCenterTeacher>();
            TrainingCourseTeachers = new HashSet<TrainingCourseTeacher>();
        }

        [StringLength(255, ErrorMessage = "����� ������ ������ ���� ����� 256 ��������")]
        [Display(Name = "�������")]
        public string Phone { get; set; }

        public byte[] Image { get; set; }

        public virtual ICollection<TrainingCenterTeacher> TrainingCenterTeachers { get; set; }

        public virtual ICollection<TrainingCourseTeacher> TrainingCourseTeachers { get; set; }
    }

}
