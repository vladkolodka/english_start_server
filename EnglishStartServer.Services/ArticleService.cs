using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishStartServer.Database;
using EnglishStartServer.Database.Models;
using EnglishStartServer.Dto;
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
                .Where(article => article.CourseId.Equals(userId)).OrderBy(article => article.DateCreated).Skip(padding)
                .Take(count).ToListAsync();
        }

        public async Task<ArticleModel> GetArticle(Guid articleId)
        {
            var article = await Db.Articles.Include(a => a.InformationBlocks)
                .FirstOrDefaultAsync(a => a.Id == articleId);

            return article.ToDto(article.InformationBlocks.OrderBy(b => b.SequentialNumber));
        }

        public Task<ArticleModel> CreateArticle(Guid userId, Guid courseId, ArticleModel articleModel)
        {
            var article = articleModel.ToEntity();


            return null;
        }
    }
}