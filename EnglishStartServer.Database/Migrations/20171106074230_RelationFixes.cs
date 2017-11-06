using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EnglishStartServer.Database.Migrations
{
    public partial class RelationFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserDictionary_Dictionaries_DictionaryId",
                table: "ApplicationUserDictionary");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserWords_Words_WordId",
                table: "ApplicationUserWords");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_ApplicationUserId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Dictionaries_Files_ImageId",
                table: "Dictionaries");

            migrationBuilder.DropIndex(
                name: "IX_Courses_ApplicationUserId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Courses");

            migrationBuilder.AlterColumn<Guid>(
                name: "ImageId",
                table: "Dictionaries",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserDictionary_Dictionaries_DictionaryId",
                table: "ApplicationUserDictionary",
                column: "DictionaryId",
                principalTable: "Dictionaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserWords_Words_WordId",
                table: "ApplicationUserWords",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dictionaries_Files_ImageId",
                table: "Dictionaries",
                column: "ImageId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserDictionary_Dictionaries_DictionaryId",
                table: "ApplicationUserDictionary");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserWords_Words_WordId",
                table: "ApplicationUserWords");

            migrationBuilder.DropForeignKey(
                name: "FK_Dictionaries_Files_ImageId",
                table: "Dictionaries");

            migrationBuilder.AlterColumn<Guid>(
                name: "ImageId",
                table: "Dictionaries",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ApplicationUserId",
                table: "Courses",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserDictionary_Dictionaries_DictionaryId",
                table: "ApplicationUserDictionary",
                column: "DictionaryId",
                principalTable: "Dictionaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserWords_Words_WordId",
                table: "ApplicationUserWords",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_ApplicationUserId",
                table: "Courses",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dictionaries_Files_ImageId",
                table: "Dictionaries",
                column: "ImageId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
