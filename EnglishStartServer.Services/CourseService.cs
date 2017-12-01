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
    public class CourseService : BaseService, ICourseService
    {
        public CourseService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Course>> GetAllCourses(int offset, int padding)
        {
            // TODO use DTO
            return await Db.Courses.OrderBy(c => c.DateCreated).Skip(offset).Take(padding).ToListAsync();
        }

        public async Task<List<Course>> GetUserCourses(Guid userId)
        {
            // TODO information about ownership and learning status in DTO
            return await Db.ApplicationUserCourses.Include(c => c.Course).Where(u => u.ApplicationUserId == userId)
                .Select(u => u.Course).ToListAsync();
        }

        public async Task<bool> AssignCourse(Guid userId, Guid courseId)
        {
            if (await
                Db.ApplicationUserCourses.AnyAsync(ac => ac.ApplicationUserId == userId && ac.CourseId == courseId))
                return false;

            var course = await Db.Courses.FirstOrDefaultAsync(c => c.Id == courseId);

            if (course == null) return false;

            await Db.ApplicationUserCourses.AddAsync(new ApplicationUserCourse
            {
                Course = course,
                ApplicationUserId = userId
            });

            await Db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SetCourseLearnStatus(Guid userId, Guid courseId, bool status)
        {
            var userCourse = await
                Db.ApplicationUserCourses.FirstOrDefaultAsync(ac =>
                    ac.ApplicationUserId == userId && ac.CourseId == courseId);

            if (userCourse == null) return false;

            userCourse.IsStudied = status;

            await Db.SaveChangesAsync();
            return true;
        }
    }
}