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

        [StringLength(255, ErrorMessage = "Длина строки должна быть менее 256 символов")]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        public byte[] Image { get; set; }

        public virtual ICollection<TrainingCenterTeacher> TrainingCenterTeachers { get; set; }

        public virtual ICollection<TrainingCourseTeacher> TrainingCourseTeachers { get; set; }
    }

}
