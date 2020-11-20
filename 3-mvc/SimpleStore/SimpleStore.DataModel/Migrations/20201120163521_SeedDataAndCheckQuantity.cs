using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleStore.DataModel.Migrations
{
    public partial class SeedDataAndCheckQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name", "Stock" },
                values: new object[] { 1, "Mcdonalds", 20 });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name", "Stock" },
                values: new object[] { 2, "Burger King", 10 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "LocationId", "Quantity" },
                values: new object[] { new Guid("5e3a0865-04ec-4750-9e0b-f260975c6746"), 1, 2 });

            migrationBuilder.AddCheckConstraint(
                name: "CK_Order_Quantity_Nonnegative",
                table: "Orders",
                sql: "[Quantity] >= 0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Order_Quantity_Nonnegative",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("5e3a0865-04ec-4750-9e0b-f260975c6746"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
