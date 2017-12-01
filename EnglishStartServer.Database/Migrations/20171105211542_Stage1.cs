using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnglishStartServer.Database.Migrations
{
    public partial class Stage1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Courses",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<Guid>("uniqueidentifier", nullable: true),
                    DateCreated = table.Column<DateTime>("datetime2", nullable: false),
                    Description = table.Column<string>("nvarchar(max)", nullable: false),
                    DiffictlyLevel = table.Column<int>("int", nullable: false),
                    Name = table.Column<string>("nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        "FK_Courses_AspNetUsers_ApplicationUserId",
                        x => x.ApplicationUserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Files",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    ContentType = table.Column<string>("nvarchar(max)", nullable: false),
                    Name = table.Column<string>("nvarchar(max)", nullable: false),
                    OwnerId = table.Column<Guid>("uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        "FK_Files_AspNetUsers_OwnerId",
                        x => x.OwnerId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Languages",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    Name = table.Column<string>("nvarchar(max)", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Languages", x => x.Id); });

            migrationBuilder.CreateTable(
                "ApplicationUserCourses",
                table => new
                {
                    ApplicationUserId = table.Column<Guid>("uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>("uniqueidentifier", nullable: false),
                    IsOwner = table.Column<bool>("bit", nullable: false),
                    IsStudied = table.Column<bool>("bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserCourses", x => new {x.ApplicationUserId, x.CourseId});
                    table.ForeignKey(
                        "FK_ApplicationUserCourses_AspNetUsers_ApplicationUserId",
                        x => x.ApplicationUserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_ApplicationUserCourses_Courses_CourseId",
                        x => x.CourseId,
                        "Courses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Articles",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>("uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>("datetime2", nullable: false),
                    Description = table.Column<string>("nvarchar(max)", nullable: false),
                    Name = table.Column<string>("nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        "FK_Articles_Courses_CourseId",
                        x => x.CourseId,
                        "Courses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Dictionaries",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>("datetime2", nullable: false),
                    ImageId = table.Column<Guid>("uniqueidentifier", nullable: false),
                    IsPublic = table.Column<bool>("bit", nullable: false),
                    Name = table.Column<string>("nvarchar(max)", nullable: false),
                    SourceLanguageId = table.Column<Guid>("uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dictionaries", x => x.Id);
                    table.ForeignKey(
                        "FK_Dictionaries_Files_ImageId",
                        x => x.ImageId,
                        "Files",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Dictionaries_Languages_SourceLanguageId",
                        x => x.SourceLanguageId,
                        "Languages",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "InformationBlock",
                table => new
                {
                    FileId = table.Column<Guid>("uniqueidentifier", nullable: true),
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>("uniqueidentifier", nullable: false),
                    BlockType = table.Column<int>("int", nullable: false),
                    Discriminator = table.Column<string>("nvarchar(max)", nullable: false),
                    SequentialNumber = table.Column<int>("int", nullable: false),
                    Text = table.Column<string>("nvarchar(max)", nullable: true),
                    Url = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationBlock", x => x.Id);
                    table.ForeignKey(
                        "FK_InformationBlock_Files_FileId",
                        x => x.FileId,
                        "Files",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_InformationBlock_Articles_ArticleId",
                        x => x.ArticleId,
                        "Articles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ApplicationUserDictionary",
                table => new
                {
                    ApplicationUserId = table.Column<Guid>("uniqueidentifier", nullable: false),
                    DictionaryId = table.Column<Guid>("uniqueidentifier", nullable: false),
                    IsArchived = table.Column<bool>("bit", nullable: false),
                    IsOwner = table.Column<bool>("bit", nullable: false),
                    IsStudied = table.Column<bool>("bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserDictionary", x => new {x.ApplicationUserId, x.DictionaryId});
                    table.ForeignKey(
                        "FK_ApplicationUserDictionary_AspNetUsers_ApplicationUserId",
                        x => x.ApplicationUserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_ApplicationUserDictionary_Dictionaries_DictionaryId",
                        x => x.DictionaryId,
                        "Dictionaries",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Words",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    DictionaryId = table.Column<Guid>("uniqueidentifier", nullable: false),
                    ImageId = table.Column<Guid>("uniqueidentifier", nullable: true),
                    Original = table.Column<string>("nvarchar(max)", nullable: false),
                    Translation = table.Column<string>("nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                    table.ForeignKey(
                        "FK_Words_Dictionaries_DictionaryId",
                        x => x.DictionaryId,
                        "Dictionaries",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Words_Files_ImageId",
                        x => x.ImageId,
                        "Files",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "ApplicationUserWords",
                table => new
                {
                    ApplicationUserId = table.Column<Guid>("uniqueidentifier", nullable: false),
                    WordId = table.Column<Guid>("uniqueidentifier", nullable: false),
                    Stage = table.Column<int>("int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserWords", x => new {x.ApplicationUserId, x.WordId});
                    table.ForeignKey(
                        "FK_ApplicationUserWords_AspNetUsers_ApplicationUserId",
                        x => x.ApplicationUserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_ApplicationUserWords_Words_WordId",
                        x => x.WordId,
                        "Words",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_ApplicationUserCourses_CourseId",
                "ApplicationUserCourses",
                "CourseId");

            migrationBuilder.CreateIndex(
                "IX_ApplicationUserDictionary_DictionaryId",
                "ApplicationUserDictionary",
                "DictionaryId");

            migrationBuilder.CreateIndex(
                "IX_ApplicationUserWords_WordId",
                "ApplicationUserWords",
                "WordId");

            migrationBuilder.CreateIndex(
                "IX_Articles_CourseId",
                "Articles",
                "CourseId");

            migrationBuilder.CreateIndex(
                "IX_Courses_ApplicationUserId",
                "Courses",
                "ApplicationUserId");

            migrationBuilder.CreateIndex(
                "IX_Dictionaries_ImageId",
                "Dictionaries",
                "ImageId");

            migrationBuilder.CreateIndex(
                "IX_Dictionaries_SourceLanguageId",
                "Dictionaries",
                "SourceLanguageId");

            migrationBuilder.CreateIndex(
                "IX_Files_OwnerId",
                "Files",
                "OwnerId");

            migrationBuilder.CreateIndex(
                "IX_InformationBlock_FileId",
                "InformationBlock",
                "FileId");

            migrationBuilder.CreateIndex(
                "IX_InformationBlock_ArticleId",
                "InformationBlock",
                "ArticleId");

            migrationBuilder.CreateIndex(
                "IX_Words_DictionaryId",
                "Words",
                "DictionaryId");

            migrationBuilder.CreateIndex(
                "IX_Words_ImageId",
                "Words",
                "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "ApplicationUserCourses");

            migrationBuilder.DropTable(
                "ApplicationUserDictionary");

            migrationBuilder.DropTable(
                "ApplicationUserWords");

            migrationBuilder.DropTable(
                "InformationBlock");

            migrationBuilder.DropTable(
                "Words");

            migrationBuilder.DropTable(
                "Articles");

            migrationBuilder.DropTable(
                "Dictionaries");

            migrationBuilder.DropTable(
                "Courses");

            migrationBuilder.DropTable(
                "Files");

            migrationBuilder.DropTable(
                "Languages");
        }
    }
}