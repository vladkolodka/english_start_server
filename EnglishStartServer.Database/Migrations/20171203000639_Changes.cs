using Microsoft.EntityFrameworkCore.Migrations;

namespace EnglishStartServer.Database.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_Files_ImageId",
                table: "Words");

            migrationBuilder.DropIndex(
                name: "IX_Words_ImageId",
                table: "Words");

            migrationBuilder.CreateIndex(
                name: "IX_Words_ImageId",
                table: "Words",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Files_ImageId",
                table: "Words",
                column: "ImageId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_Files_ImageId",
                table: "Words");

            migrationBuilder.DropIndex(
                name: "IX_Words_ImageId",
                table: "Words");

            migrationBuilder.CreateIndex(
                name: "IX_Words_ImageId",
                table: "Words",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Files_ImageId",
                table: "Words",
                column: "ImageId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}