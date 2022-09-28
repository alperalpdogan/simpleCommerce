using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimCom.Data.Migrations
{
    public partial class AddedMainPageFieldToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DisplayedOnMainPage",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayedOnMainPage",
                table: "Product");
        }
    }
}
