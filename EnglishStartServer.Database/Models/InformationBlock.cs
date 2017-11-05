using System;
using System.ComponentModel.DataAnnotations;
using EnglishStartServer.Database.Enums;

namespace EnglishStartServer.Database.Models
{
    public class InformationBlock
    {
        public Guid Id { get; set; }

        [Required]
        public InformationBlockType BlockType { get; set; }

        public int SequentialNumber { get; set; } = 0;

        public Guid ArticleId { get; set; }

        public Article Article { get; set; }
    }
}