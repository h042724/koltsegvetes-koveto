using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class CategoryConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3df52fbb-d560-4b87-8aee-7d338f079669", null, "Administrator", "ADMINISTRATOR" },
                    { "48d132fd-5769-48c3-b48e-4fd5a4fbf6ab", null, "User", "USER" },
                    { "a31d8de7-8e88-4839-b98e-14cf4b847693", null, "Guest", "GUEST" }
                });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "ID",
                keyValue: 1,
                column: "ExpenseOrIncome",
                value: "expense");

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "ID",
                keyValue: 2,
                column: "ExpenseOrIncome",
                value: "expense");

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "ID",
                keyValue: 3,
                column: "ExpenseOrIncome",
                value: "expense");

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "ID", "ExpenseOrIncome", "Name" },
                values: new object[,]
                {
                    { 4, "income", "Salary" },
                    { 5, "income", "Investments" },
                    { 6, "income", "Rental" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3df52fbb-d560-4b87-8aee-7d338f079669");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48d132fd-5769-48c3-b48e-4fd5a4fbf6ab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a31d8de7-8e88-4839-b98e-14cf4b847693");

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3af19094-9e24-4d96-bdd8-485a92f7ec4e", null, "User", "USER" },
                    { "88cc2323-36fb-4192-a2b3-15d651dca77a", null, "Administrator", "ADMINISTRATOR" },
                    { "bac58260-a5ba-4b61-8589-27d46c4e279b", null, "Guest", "GUEST" }
                });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "ID",
                keyValue: 1,
                column: "ExpenseOrIncome",
                value: "Expense");

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "ID",
                keyValue: 2,
                column: "ExpenseOrIncome",
                value: "Expense");

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "ID",
                keyValue: 3,
                column: "ExpenseOrIncome",
                value: "Expense");
        }
    }
}
