using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage="Поле обязательно для заполнения")]
        public string Title { get; set; }
        [AllowHtml]
        [StringLength(1000, ErrorMessage = "Аннотация должна быть не более 1000 символов")]
        [Required]
        public string Annotation { get; set; }
        [AllowHtml]
        [Required]
        public string Text { get; set; }
        public int UserId { get; set; }
        public DateTime PublishDate { get; set; }
        public ArticleType Type { get; set; }

        [ForeignKey("TrainingCenter")]
        public int? TrainingCenterId { get; set; }
        public virtual TrainingCenter TrainingCenter { get; set; }

        public byte[] Image { get; set; }

        public string ContentType { get; set; }

        public ICollection<FileDocument> Documents { get; set; }
    }
}