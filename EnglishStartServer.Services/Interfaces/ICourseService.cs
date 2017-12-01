using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishStartServer.Database.Models;

namespace EnglishStartServer.Services.Interfaces
{
    public interface ICourseService
    {
        Task<List<Course>> GetAllCourses(int offset, int padding);
        Task<List<Course>> GetUserCourses(Guid userId);
        Task<bool> AssignCourse(Guid userId, Guid courseId);
        Task<bool> SetCourseLearnStatus(Guid userId, Guid courseId, bool status);
    }
}