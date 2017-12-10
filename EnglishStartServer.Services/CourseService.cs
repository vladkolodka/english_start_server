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
    public class CourseService : BaseService, ICourseService
    {
        public CourseService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<CourseModel>> GetAllCourses(Guid userId, int offset, int count)
        {
            var courses = await Db.Courses.OrderBy(c => c.DateCreated).Skip(offset).Take(count).ToListAsync();

            var ids = courses.Select(c => c.Id);

            var userCourses = await Db.ApplicationUserCourses.Where(uc => uc.ApplicationUserId == userId
                                                                          && ids.Contains(uc.CourseId)
            ).ToDictionaryAsync(ac => ac.CourseId, ac => ac.IsStudied);

            return courses.ToDto(userCourses);
        }

        public async Task<List<CourseModel>> GetUserCourses(Guid userId)
        {
            return (await Db.ApplicationUserCourses.Include(c => c.Course).Where(u => u.ApplicationUserId == userId)
                .ToListAsync()).ToDto();
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

        public async Task<CourseModel> CreateCourse(Guid userId, CourseModel courseModel)
        {
            var course = courseModel.ToEntity();

            course.UserCourses.Add(new ApplicationUserCourse
            {
                IsOwner = true,
                ApplicationUserId = userId
            });

            await Db.Courses.AddAsync(course);
            await Db.SaveChangesAsync();

            return course.ToDto(false);
        }
    }
}