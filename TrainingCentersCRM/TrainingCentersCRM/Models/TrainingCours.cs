namespace TrainingCentersCRM.Models
{

using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrainingCourses")]
    public partial class TrainingCours
    {
        public TrainingCours()
        {
            CourseModules = new HashSet<CourseModule>();
            HoldCourses = new HashSet<HoldCours>();
            QualificationTrainingCours = new HashSet<QualificationTrainingCour>();
            RelatedCourses = new HashSet<RelatedCours>();
            RelatedCourses1 = new HashSet<RelatedCours>();
            ScheduleTtrainingCourses = new HashSet<ScheduleTtrainingCours>();
            TrainingCenterCourses = new HashSet<TrainingCenterCours>();
            TrainingCourseTeachers = new HashSet<TrainingCourseTeacher>();
        }

        public int Id { get; set; }

        [StringLength(255, ErrorMessage = "����� ������ ������ ���� ����� 256 ��������")]
        [Display(Name = "��������")]
        public string Title { get; set; }

        [StringLength(2048, ErrorMessage = "����� ������ ������ ���� ����� 1024 ��������")]
        [Display(Name = "������� ��������")]
        public string ShortDescription { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "������������ ��������")]
        [Display(Name = "���������� �����")]
        public Nullable<int> Hourse { get; set; }

        [RegularExpression(@"^[\d,]+(\.\d{1,5})?$", ErrorMessage = "������������ ��������")]
        [Display(Name = "��������� ��� �����������")]
        [Column(TypeName = "money")]
        public Nullable<decimal> PriceForOrganizations { get; set; }

        [RegularExpression(@"^[\d,]+(\.\d{1,5})?$", ErrorMessage = "������������ ��������")]
        [Display(Name = "��������� ��� ���������� ���")]
        [Column(TypeName = "money")]
        public Nullable<decimal> PriceForIndividuals { get; set; }

        [RegularExpression(@"^[\d,]+(\.\d{1,5})?$", ErrorMessage = "������������ ��������")]
        [Display(Name = "��������� ���� ��� �����������")]
        [Column(TypeName = "money")]
        public Nullable<decimal> CostOfOneHourForOrganizations { get; set; }

        [RegularExpression(@"^[\d,]+(\.\d{1,5})?$", ErrorMessage = "������������ ��������")]
        [Display(Name = "��������� ���� ��� ���������� ���")]
        [Column(TypeName = "money")]
        public Nullable<decimal> CostOfOneHourForIndividuals { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "������������ ��������")]
        [Display(Name = "���������")]
        public Nullable<int> LevelOfDifficulty { get; set; }

        [Display(Name = "��������� ��������������� ����������")]
        [StringLength(1023, ErrorMessage = "����� ������ ������ ���� ����� 1024 ��������")]
        public string RequiredPreliminaryPreparation { get; set; }

        [Display(Name = "������������ ��������������� ����������")]
        [StringLength(1023, ErrorMessage = "����� ������ ������ ���� ����� 1024 ��������")]
        public string MandatoryPreliminaryPreparation { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "������������ ��������")]
        [Display(Name = "������� �����")]
        public Nullable<int> IdTraningCenter { get; set; }

        public int? IdObject { get; set; }

        public virtual ICollection<CourseModule> CourseModules { get; set; }

        public virtual ICollection<HoldCours> HoldCourses { get; set; }

        public virtual ICollection<QualificationTrainingCour> QualificationTrainingCours { get; set; }

        public virtual ICollection<RelatedCours> RelatedCourses { get; set; }

        public virtual ICollection<RelatedCours> RelatedCourses1 { get; set; }

        public virtual ICollection<ScheduleTtrainingCours> ScheduleTtrainingCourses { get; set; }

        public virtual ICollection<TrainingCenterCours> TrainingCenterCourses { get; set; }

        public virtual ICollection<TrainingCourseTeacher> TrainingCourseTeachers { get; set; }
    }

}
