using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrainingCentersCRM.Models
{
    public class Advertize
    {
        public int Id { get; set; }
        
        [DisplayName("Заголовок")]
        public string Name { get; set; }

        [AllowHtml]
        [DisplayName("Краткое описание")]
        public string Description { get; set; }
        
        public byte[] Image { get; set; }

        [DisplayName("Блок является активным")]
        public bool Enabled { get; set; }

        public string ImageType { get; set; }
    }
}