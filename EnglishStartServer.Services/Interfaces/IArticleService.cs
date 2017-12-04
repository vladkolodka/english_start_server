﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishStartServer.Database.Models;
using EnglishStartServer.Dto;

namespace EnglishStartServer.Services.Interfaces
{
    public interface IArticleService
    {
        Task<List<Article>> GetArticlesByCourse(Guid userId, Guid courseId, int padding, int count);
        Task<ArticleModel> GetArticle(Guid articleId);
        Task<ArticleModel> CreateArticle(Guid userId, Guid courseId, ArticleModel articleModel);
    }
}