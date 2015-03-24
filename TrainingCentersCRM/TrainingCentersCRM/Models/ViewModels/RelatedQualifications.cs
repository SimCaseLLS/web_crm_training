using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingCentersCRM.Models.ViewModels
{
    public class RelatedQualifications
    {
        public int QualificationID { get; set; }
        public string Title { get; set; }
        public bool Assigned { get; set; }
    }
}