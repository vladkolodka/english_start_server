using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace EnglishStartServer.Database.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public List<ApplicationUserCourse> UserCourses { get; set; }
        public List<ApplicationUserDictionary> UserDictionaries { get; set; }
        public List<ApplicationUserWord> UserWords { get; set; }
        public List<File> Files { get; set; }
    }
}