namespace TrainingCentersCRM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CertificationProvider
    {
        public CertificationProvider()
        {
            Certifications = new HashSet<Certification>();
        }

        public int Id { get; set; }

        [StringLength(255, ErrorMessage = "����� ������ ������ ���� ����� 256 ��������")]
        [Display(Name = "��������")]
        public string Title { get; set; }

        [StringLength(255, ErrorMessage = "����� ������ ������ ���� ����� 256 ��������")]
        [Display(Name = "�����")]
        public string Addres { get; set; }

        [StringLength(255, ErrorMessage = "����� ������ ������ ���� ����� 256 ��������")]
        [Display(Name = "�������")]
        public string Phone { get; set; }

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "������������ �����")]
        [Display(Name = "e-mail")]
        [StringLength(255, ErrorMessage = "����� ������ ������ ���� ����� 256 ��������")]
        public string Email { get; set; }

        public virtual ICollection<Certification> Certifications { get; set; }
    }
}
