using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainingCentersCRM.Models
{
    public class FileDocument
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public byte[] Data { get; set; }

        public string ContentType { get; set; }

        public Article Article { get; set; }

        public int? ArticleId { get; set; }
    }
}