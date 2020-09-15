using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diary.Entity.Migrations
{
    public partial class AddDiaryToCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Diaries",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Diaries_CategoryId",
                table: "Diaries",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diaries_Categories_CategoryId",
                table: "Diaries",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diaries_Categories_CategoryId",
                table: "Diaries");

            migrationBuilder.DropIndex(
                name: "IX_Diaries_CategoryId",
                table: "Diaries");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Diaries");
        }
    }
}
