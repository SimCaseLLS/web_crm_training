<<<<<<< HEAD
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrainingCentersCRM.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Teacher
    {
        public Teacher()
        {
            this.TrainingCenterTeachers = new HashSet<TrainingCenterTeacher>();
            this.TrainingCourseTeachers = new HashSet<TrainingCourseTeacher>();
        }
    
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<TrainingCenterTeacher> TrainingCenterTeachers { get; set; }
        public virtual ICollection<TrainingCourseTeacher> TrainingCourseTeachers { get; set; }
    }
=======
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

>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878
}
