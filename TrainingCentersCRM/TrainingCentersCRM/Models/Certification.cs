namespace TrainingCentersCRM.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Certification
    {
        public Certification()
        {
            QualificationCertifications = new HashSet<QualificationCertification>();
        }

        public int Id { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "������������ ��������")]
        [Display(Name = "���������")]
        public int? IdProvider { get; set; }

        [StringLength(255, ErrorMessage = "����� ������ ������ ���� ����� 256 ��������")]
        [Display(Name = "��������")]
        public string Title { get; set; }

        [StringLength(1023, ErrorMessage = "����� ������ ������ ���� ����� 1024 ��������")]
        [Display(Name = "��������")]
        public string Description { get; set; }

        public virtual CertificationProvider CertificationProvider { get; set; }

        public virtual ICollection<QualificationCertification> QualificationCertifications { get; set; }
    }
}