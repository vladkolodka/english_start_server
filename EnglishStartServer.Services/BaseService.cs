using EnglishStartServer.Database;

namespace EnglishStartServer.Services
{
    public class BaseService
    {
        public BaseService(ApplicationDbContext dbContext)
        {
            Db = dbContext;
        }

        protected ApplicationDbContext Db { get; set; }
    }
}