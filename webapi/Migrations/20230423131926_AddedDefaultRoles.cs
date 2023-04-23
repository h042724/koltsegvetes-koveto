using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "90021c92-984d-4b2e-b82f-19e56a0fbe56", null, "Administrator", "ADMINISTRATOR" },
                    { "970c357a-568c-455e-9b96-91372bb5b48d", null, "Guest", "GUEST" },
                    { "a8845f66-2415-48e6-97ac-f4136da3aa32", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90021c92-984d-4b2e-b82f-19e56a0fbe56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "970c357a-568c-455e-9b96-91372bb5b48d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8845f66-2415-48e6-97ac-f4136da3aa32");
        }
    }
}
