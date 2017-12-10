using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishStartServer.Dto;

namespace EnglishStartServer.Services.Interfaces
{
    public interface ICourseService
    {
        Task<List<CourseModel>> GetAllCourses(Guid userId, int offset, int count);
        Task<List<CourseModel>> GetUserCourses(Guid userId);
        Task<bool> AssignCourse(Guid userId, Guid courseId);
        Task<bool> SetCourseLearnStatus(Guid userId, Guid courseId, bool status);
        Task<CourseModel> CreateCourse(Guid userId, CourseModel course);
    }
}