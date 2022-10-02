using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ukam.Data.Migrations
{
    public partial class Initial_Book_Tabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookName = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    Establish = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    ConverImage = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Language = table.Column<int>(type: "INTEGER", nullable: false),
                    CheckBook = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<ulong>(type: "INTEGER", nullable: false),
                    UserId = table.Column<ulong>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
