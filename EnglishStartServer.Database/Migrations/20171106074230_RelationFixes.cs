using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnglishStartServer.Database.Migrations
{
    public partial class RelationFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_ApplicationUserDictionary_Dictionaries_DictionaryId",
                "ApplicationUserDictionary");

            migrationBuilder.DropForeignKey(
                "FK_ApplicationUserWords_Words_WordId",
                "ApplicationUserWords");

            migrationBuilder.DropForeignKey(
                "FK_Courses_AspNetUsers_ApplicationUserId",
                "Courses");

            migrationBuilder.DropForeignKey(
                "FK_Dictionaries_Files_ImageId",
                "Dictionaries");

            migrationBuilder.DropIndex(
                "IX_Courses_ApplicationUserId",
                "Courses");

            migrationBuilder.DropColumn(
                "ApplicationUserId",
                "Courses");

            migrationBuilder.AlterColumn<Guid>(
                "ImageId",
                "Dictionaries",
                "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                "FK_ApplicationUserDictionary_Dictionaries_DictionaryId",
                "ApplicationUserDictionary",
                "DictionaryId",
                "Dictionaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_ApplicationUserWords_Words_WordId",
                "ApplicationUserWords",
                "WordId",
                "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_Dictionaries_Files_ImageId",
                "Dictionaries",
                "ImageId",
                "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_ApplicationUserDictionary_Dictionaries_DictionaryId",
                "ApplicationUserDictionary");

            migrationBuilder.DropForeignKey(
                "FK_ApplicationUserWords_Words_WordId",
                "ApplicationUserWords");

            migrationBuilder.DropForeignKey(
                "FK_Dictionaries_Files_ImageId",
                "Dictionaries");

            migrationBuilder.AlterColumn<Guid>(
                "ImageId",
                "Dictionaries",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                "ApplicationUserId",
                "Courses",
                nullable: true);

            migrationBuilder.CreateIndex(
                "IX_Courses_ApplicationUserId",
                "Courses",
                "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                "FK_ApplicationUserDictionary_Dictionaries_DictionaryId",
                "ApplicationUserDictionary",
                "DictionaryId",
                "Dictionaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_ApplicationUserWords_Words_WordId",
                "ApplicationUserWords",
                "WordId",
                "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_Courses_AspNetUsers_ApplicationUserId",
                "Courses",
                "ApplicationUserId",
                "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_Dictionaries_Files_ImageId",
                "Dictionaries",
                "ImageId",
                "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}