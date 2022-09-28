using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimCom.Data.Migrations
{
    public partial class AddedUserToReviewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ProductReview",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_UserId",
                table: "ProductReview",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReview_Users_UserId",
                table: "ProductReview",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductReview_Users_UserId",
                table: "ProductReview");

            migrationBuilder.DropIndex(
                name: "IX_ProductReview_UserId",
                table: "ProductReview");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProductReview");
        }
    }
}
