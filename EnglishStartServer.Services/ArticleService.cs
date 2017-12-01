using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishStartServer.Database;
using EnglishStartServer.Database.Models;
using EnglishStartServer.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EnglishStartServer.Services
{
    public class ArticleService : BaseService, IArticleService
    {
        public ArticleService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Article>> GetArticlesByCourse(Guid userId, Guid courseId, int padding, int count)
        {
            return await Db.Articles
                .Where(article => article.CourseId.Equals(userId)) /* .OrderBy(article => article.Name)*/.Skip(padding)
                .Take(count).ToListAsync();
        }
    }
}