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

        public async Task<List<ArticleModel>> GetArticlesByCourse(Guid courseId, int padding, int count)
        {
            return (await Db.Articles
                .Where(article => article.CourseId.Equals(courseId)).OrderBy(article => article.DateCreated).Skip(padding)
                .Take(count).ToListAsync()).ToDto();
        }

        public async Task<ArticleModel> GetArticle(Guid articleId)
        {
            var article = await Db.Articles.Include(a => a.InformationBlocks)
                .FirstOrDefaultAsync(a => a.Id == articleId);

            return article.ToDto(article.InformationBlocks.OrderBy(b => b.SequentialNumber));
        }

        public async Task<ArticleModel> CreateArticle(Guid userId, Guid courseId, ArticleModel articleModel)
        {
            // TODO work with files
            var userCourse = await Db.ApplicationUserCourses.Include(uc => uc.Course)
                .Where(uc => uc.ApplicationUserId == userId && uc.CourseId == courseId && uc.IsOwner)
                .SingleOrDefaultAsync();

            if (userCourse == null) return null;

            var article = articleModel.ToEntity();

            userCourse.Course.Articles.Add(article);

            await Db.SaveChangesAsync();

            return article.ToDto(article.InformationBlocks);
        }

        public async Task<ArticleModel> ModifyArticle(Guid userId, ArticleModel articleModel)
        {
            var article = await Db.Articles.Include(a => a.InformationBlocks)
                .Where(a => a.Id == articleModel.Id)
                .SingleOrDefaultAsync();

            if (article == null) return null;

            var userCourse = await Db.ApplicationUserCourses
                .Where(uc => uc.ApplicationUserId == userId && uc.CourseId == article.CourseId && uc.IsOwner)
                .SingleOrDefaultAsync();

            if (userCourse == null) return null;

            article.Name = articleModel.Name;
            article.Description = articleModel.Description;

            try
            {
                articleModel.InformationBlocks.ForEach(model =>
                {
                    var block =
                        article.InformationBlocks.SingleOrDefault(b => b.Id == model.Id && b.BlockType == model.Type);

                    if (block == null) throw new Exception();

                    block.Update(model);
                });

                await Db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return null;
            }

            return article.ToDto(article.InformationBlocks);
        }

        public async Task<List<ArticleModel>> LastArticles(int count)
        {
            return (await Db.Articles.FromSql("LastArticles {0}", count).ToListAsync()).ToDto();
        }
    }
}