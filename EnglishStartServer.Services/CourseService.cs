using EnglishStartServer.Database;
using EnglishStartServer.Services.Interfaces;

namespace EnglishStartServer.Services
{
    public class CourseService : BaseService, ICourseService
    {
        public CourseService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}