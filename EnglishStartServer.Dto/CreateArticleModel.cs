using System;

namespace EnglishStartServer.Dto
{
    public class CreateArticleModel
    {
        public Guid CourseId { get; set; }
        public ArticleModel Article { get; set; }
    }
}