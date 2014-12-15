namespace TrainingCentersCRM.Models
{

using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TrainingGroup
    {
        public TrainingGroup()
        {
            HoldCourses = new HashSet<HoldCours>();
            Listeners = new HashSet<Listener>();
        }

        public int Id { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Учебный курс")]
        public Nullable<int> IdTrainingCourse { get; set; }

        [StringLength(255, ErrorMessage = "Смета затрат")]
        [Display(Name = "Название")]
        public string EstimateOfExpenditures { get; set; }

        public int? IdObject { get; set; }

        public virtual ICollection<HoldCours> HoldCourses { get; set; }

        public virtual ICollection<Listener> Listeners { get; set; }

    }

}
