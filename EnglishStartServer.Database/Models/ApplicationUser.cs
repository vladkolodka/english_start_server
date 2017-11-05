using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace EnglishStartServer.Database.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public List<Course> Courses { get; set; }
        public List<File> Files { get; set; }
    }
}