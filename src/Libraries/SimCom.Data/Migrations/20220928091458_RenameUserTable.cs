using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimCom.Data.Migrations
{
    public partial class RenameUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Users",
                newName: "AspNetUsers");
        }
    }
}
