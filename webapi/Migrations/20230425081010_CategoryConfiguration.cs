using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class CategoryConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c481baa-50f6-4942-bc07-6080a9ff1100");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b893d6e-58dd-45b3-81e8-d2592481b8ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a50637b8-fe6f-4491-bc3c-dbc64a736869");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3af19094-9e24-4d96-bdd8-485a92f7ec4e", null, "User", "USER" },
                    { "88cc2323-36fb-4192-a2b3-15d651dca77a", null, "Administrator", "ADMINISTRATOR" },
                    { "bac58260-a5ba-4b61-8589-27d46c4e279b", null, "Guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "ID", "ExpenseOrIncome", "Name" },
                values: new object[,]
                {
                    { 1, "Expense", "Grocery" },
                    { 2, "Expense", "Transportation" },
                    { 3, "Expense", "Entertainment" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3af19094-9e24-4d96-bdd8-485a92f7ec4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88cc2323-36fb-4192-a2b3-15d651dca77a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bac58260-a5ba-4b61-8589-27d46c4e279b");

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c481baa-50f6-4942-bc07-6080a9ff1100", null, "Administrator", "ADMINISTRATOR" },
                    { "9b893d6e-58dd-45b3-81e8-d2592481b8ef", null, "Guest", "GUEST" },
                    { "a50637b8-fe6f-4491-bc3c-dbc64a736869", null, "User", "USER" }
                });
        }
    }
}
