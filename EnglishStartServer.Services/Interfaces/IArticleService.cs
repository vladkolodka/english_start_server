using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishStartServer.Database.Models;

namespace EnglishStartServer.Services.Interfaces
{
    public interface IArticleService
    {
        Task<List<Article>> GetArticlesByCourse(Guid userId, Guid courseId, int padding, int count);
    }
}