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
    
    public partial class CertificationTaking
    {
        public int Id { get; set; }
        public Nullable<int> IdStudent { get; set; }
        public Nullable<int> IdCertification { get; set; }
        public Nullable<int> Date { get; set; }
=======
namespace TrainingCentersCRM.Models
{

using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CertificationTaking
    {
        public int Id { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "������������ ��������")]
        [Display(Name = "�������")]
        public Nullable<int> IdStudent { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "������������ ��������")]
        [Display(Name = "������������")]
        public Nullable<int> IdCertification { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "������������ ��������")]
        [Display(Name = "����")]
        public Nullable<int> Date { get; set; }

        [StringLength(255, ErrorMessage = "����� ������ ������ ���� ����� 256 ��������")]
        [Display(Name = "���������")]
>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878
        public string Result { get; set; }
    }
}
