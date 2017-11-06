using System;
using EnglishStartServer.Database.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EnglishStartServer.Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ApplicationUserCourse> ApplicationUserCourses { get; set; }
        public DbSet<ApplicationUserWord> ApplicationUserWords { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Dictionary> Dictionaries { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<ApplicationUserDictionary> ApplicationUserDictionary { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserCourse>().HasKey(auc => new {auc.ApplicationUserId, auc.CourseId});
            builder.Entity<ApplicationUserWord>().HasKey(auw => new {auw.ApplicationUserId, auw.WordId});
            builder.Entity<ApplicationUserDictionary>().HasKey(aud => new {aud.ApplicationUserId, aud.DictionaryId});

            //            builder.Entity<ApplicationUserDictionary>().HasOne(aud => aud.Dictionary).WithMany()
            //                .OnDelete(DeleteBehavior.Restrict);
            //            builder.Entity<ApplicationUserWord>().HasOne(auw => auw.Word).WithMany()
            //                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Word>().HasOne(aud => aud.Image).WithOne()
                .OnDelete(DeleteBehavior.SetNull);
        }

        #region Article information blocks

        public DbSet<InformationBlock> InformationBlock { get; set; }
        public DbSet<TextInformationBlock> TextInformationBlocks { get; set; }
        public DbSet<ImageInformationBlock> ImageInformationBlocks { get; set; }
        public DbSet<VideoInformationBlock> VideoInformationBlocks { get; set; }

        #endregion
    }
}