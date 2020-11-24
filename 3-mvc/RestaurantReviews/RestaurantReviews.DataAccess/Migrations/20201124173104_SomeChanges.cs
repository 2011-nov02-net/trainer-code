using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantReviews.DataAccess.Migrations
{
    public partial class SomeChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Restaurant_RestaurantId",
                table: "Review");

            migrationBuilder.EnsureSchema(
                name: "RR");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Review",
                newSchema: "RR");

            migrationBuilder.RenameTable(
                name: "Restaurant",
                newName: "Restaurant",
                newSchema: "RR");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                schema: "RR",
                table: "Review",
                newName: "RestaurantID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "RR",
                table: "Review",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Review_RestaurantId",
                schema: "RR",
                table: "Review",
                newName: "IX_Review_RestaurantID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "RR",
                table: "Restaurant",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Restaurant",
                schema: "RR",
                table: "Review",
                column: "RestaurantID",
                principalSchema: "RR",
                principalTable: "Restaurant",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Restaurant",
                schema: "RR",
                table: "Review");

            migrationBuilder.RenameTable(
                name: "Review",
                schema: "RR",
                newName: "Review");

            migrationBuilder.RenameTable(
                name: "Restaurant",
                schema: "RR",
                newName: "Restaurant");

            migrationBuilder.RenameColumn(
                name: "RestaurantID",
                table: "Review",
                newName: "RestaurantId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Review",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Review_RestaurantID",
                table: "Review",
                newName: "IX_Review_RestaurantId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Restaurant",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Restaurant_RestaurantId",
                table: "Review",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
