using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ukam.Data.Migrations
{
    public partial class fixef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserImage",
                table: "Users",
                newName: "UserPath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserPath",
                table: "Users",
                newName: "UserImage");
        }
    }
}
