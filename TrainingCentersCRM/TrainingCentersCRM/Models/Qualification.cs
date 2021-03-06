namespace TrainingCentersCRM.Models
{

using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Qualification
    {
        public Qualification()
        {
            QualificationCertifications = new HashSet<QualificationCertification>();
            QualificationTrainingCours = new HashSet<QualificationTrainingCour>();
        }

        public int Id { get; set; }

        [StringLength(255, ErrorMessage = "����� ������ ������ ���� ����� 256 ��������")]
        [Display(Name = "��������")]
        public string Title { get; set; }

        [StringLength(1023, ErrorMessage = "����� ������ ������ ���� ����� 1024 ��������")]
        [Display(Name = "��������")]
        public string Description { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "������������ ��������")]
        [Display(Name = "���")]
        public Nullable<int> Type { get; set; }

        [StringLength(255, ErrorMessage = "����� ������ ������ ���� ����� 256 ��������")]
        [Display(Name = "HeadHunter Id")]
        public string HeadHunterId { get; set; }

        [StringLength(1023, ErrorMessage = "����� ������ ������ ���� ����� 1024 ��������")]
        [Display(Name = "������������ �� HeadHunter'e")]
        public string HeadHunterName { get; set; }

        [StringLength(1023, ErrorMessage = "����� ������ ������ ���� ����� 1024 ��������")]
        [Display(Name = "�������� �����")]
        public string HeadHunterKeys { get; set; }

        public Nullable<int> ParentId { get; set; }
        public virtual ICollection<QualificationCertification> QualificationCertifications { get; set; }

        public virtual ICollection<QualificationTrainingCour> QualificationTrainingCours { get; set; }

        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }

}
