﻿// <auto-generated />
using EnglishStartServer.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace EnglishStartServer.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EnglishStartServer.Database.Models.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("EnglishStartServer.Database.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("EnglishStartServer.Database.Models.ApplicationUserCourse", b =>
                {
                    b.Property<Guid>("ApplicationUserId");

                    b.Property<Guid>("CourseId");

                    b.Property<bool>("IsOwner");

                    b.Property<bool>("IsStudied");

                    b.HasKey("ApplicationUserId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("ApplicationUserCourses");
                });

            modelBuilder.Entity("EnglishStartServer.Database.Models.ApplicationUserDictionary", b =>
                {
                    b.Property<Guid>("ApplicationUserId");

                    b.Property<Guid>("DictionaryId");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsOwner");

                    b.Property<bool>("IsStudied");

                    b.HasKey("ApplicationUserId", "DictionaryId");

                    b.HasIndex("DictionaryId");

                    b.ToTable("ApplicationUserDictionary");
                });

            modelBuilder.Entity("EnglishStartServer.Database.Models.ApplicationUserWord", b =>
                {
                    b.Property<Guid>("ApplicationUserId");

                    b.Property<Guid>("WordId");

                    b.Property<int>("Stage");

                    b.HasKey("ApplicationUserId", "WordId");

                    b.HasIndex("WordId");

                    b.ToTable("ApplicationUserWords");
                });

            modelBuilder.Entity("EnglishStartServer.Database.Models.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CourseId");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("EnglishStartServer.Database.Models.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("DiffictlyLevel");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EnglishStartServer.Database.Models.Dictionary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid?>("ImageId");

                    b.Property<bool>("IsPublic");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid>("SourceLanguageId");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("SourceLanguageId");

                    b.ToTable("Dictionaries");
                });

            modelBuilder.Entity("EnglishStartServer.Database.Models.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContentType")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid>("OwnerId");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("EnglishStartServer.Database.Models.InformationBlock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ArticleId");

                    b.Property<int>("BlockType");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("SequentialNumber");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("InformationBlock");

                    b.HasDiscriminator<string>("Discriminator").HasValue("InformationBlock");
                });

            modelBuilder.Entity("EnglishStartServer.Database.Models.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("EnglishStartServer.Database.Models.Word", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("DictionaryId");

                    b.Property<Guid?>("ImageId");

                    b.Property<string>("Original")
                        .IsRequired();

                    b.Property<string>("Translation")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("DictionaryId");

                    b.HasIndex("ImageId")
                        .IsUnique()
                        .HasFilter("[ImageId] IS NOT NULL");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EnglishStartServer.Database.Models.ImageInformationBlock", b =>
                {
                    b.HasBaseType("EnglishStartServer.Database.Models.InformationBlock");

                    b.Property<Guid>("FileId");

                    b.HasIndex("FileId");

                    b.ToTable("ImageInformationBlock");

                    b.HasDiscriminator().HasValue("ImageInformationBlock");
                });

            modelBuilder.Entity("EnglishStartServer.Database.Models.TextInformationBlock", b =>
                {
                    b.HasBaseType("EnglishStartServer.Database.Models.InformationBlock");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.ToTable("TextInformationBlock");

                    b.HasDiscriminator().HasValue("TextInformationBlock");
                });

            modelBuilder.Entity("EnglishStartServer.Database.Models.VideoInformationBlock", b =>
                {
                    b.HasBaseType("EnglishStartServer.Database.Models.InformationBlock");

                    b.Property<string>("Url")
                        .IsRequired();

                    b.ToTable("VideoInformationBlock");

                    b.HasDiscriminator().HasValue("VideoInformationBlock");
                });

            modelBuilder.Entity("EnglishStartServer.Database.Models.ApplicationUserCourse", b =>
                {
                    b.HasOne("EnglishStartServer.Database.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("UserCourses")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EnglishStartServer.Database.Models.Course", "Course")
                        .WithMany("UserCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EnglishStartServer.Database.Models.ApplicationUserDictionary", b =>
                {
                    b.HasOne("EnglishStartServer.Database.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("UserDictionaries")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EnglishStartServer.Database.Models.Dictionary", "Dictionary")
                        .WithMany("UserDictionaries")
                        .HasForeignKey("DictionaryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EnglishStartServer.Database.Models.ApplicationUserWord", b =>
                {
                    b.HasOne("EnglishStartServer.Database.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("UserWords")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EnglishStartServer.Database.Models.Word", "Word")
                        .WithMany("UserWords")
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EnglishStartServer.Database.Models.Article", b =>
                {
                    b.HasOne("EnglishStartServer.Database.Models.Course", "Course")
                        .WithMany("Articles")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EnglishStartServer.Database.Models.Dictionary", b =>
                {
                    b.HasOne("EnglishStartServer.Database.Models.File", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.HasOne("EnglishStartServer.Database.Models.Language", "SourceLanguage")
                        .WithMany("Dictionaries")
                        .HasForeignKey("SourceLanguageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EnglishStartServer.Database.Models.File", b =>
                {
                    b.HasOne("EnglishStartServer.Database.Models.ApplicationUser", "Owner")
                        .WithMany("Files")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EnglishStartServer.Database.Models.InformationBlock", b =>
                {
                    b.HasOne("EnglishStartServer.Database.Models.Article", "Article")
                        .WithMany("InformationBlocks")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EnglishStartServer.Database.Models.Word", b =>
                {
                    b.HasOne("EnglishStartServer.Database.Models.Dictionary", "Dictionary")
                        .WithMany("Words")
                        .HasForeignKey("DictionaryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EnglishStartServer.Database.Models.File", "Image")
                        .WithOne()
                        .HasForeignKey("EnglishStartServer.Database.Models.Word", "ImageId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("EnglishStartServer.Database.Models.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("EnglishStartServer.Database.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("EnglishStartServer.Database.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("EnglishStartServer.Database.Models.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EnglishStartServer.Database.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("EnglishStartServer.Database.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EnglishStartServer.Database.Models.ImageInformationBlock", b =>
                {
                    b.HasOne("EnglishStartServer.Database.Models.File", "File")
                        .WithMany()
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
