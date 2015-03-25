using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrainingCentersCRM.Models
{
    public class Article
    {
        public enum ArticleType
        {
            News = 1, Article = 2
        }
        public int Id { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Annotation { get; set; }
        [AllowHtml]
        public string Text { get; set; }
        public int UserId { get; set; }
        public DateTime PublishDate { get; set; }
        public ArticleType Type { get; set; }

        [ForeignKey("TrainingCenter")]
        public int? TrainingCenterId { get; set; }
        public virtual TrainingCenter TrainingCenter { get; set; }
    }
}