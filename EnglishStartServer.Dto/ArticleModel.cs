using System;
using System.Collections.Generic;
using EnglishStartServer.Dto.InformationBlocks;

namespace EnglishStartServer.Dto
{
    public class ArticleModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CourseId { get; set; }

        public DateTime DateCreated { get; set; }

        public List<InformationBlockModel> InformationBlocks { get; set; }
    }
}