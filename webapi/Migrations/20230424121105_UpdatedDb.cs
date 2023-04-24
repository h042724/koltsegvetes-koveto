using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5efbe169-0c48-48de-9df7-120384a803e3", null, "Guest", "GUEST" },
                    { "e48e91a0-185e-4c9d-b4ef-04360e309db2", null, "Administrator", "ADMINISTRATOR" },
                    { "e71ffd3c-538e-4030-9c40-eb272340e7a0", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5efbe169-0c48-48de-9df7-120384a803e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e48e91a0-185e-4c9d-b4ef-04360e309db2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e71ffd3c-538e-4030-9c40-eb272340e7a0");

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
    }
}
