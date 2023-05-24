using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class IdentityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d38d26f-5f05-46d0-8b9a-ec96449f5714");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65f153ec-b6fb-41a2-b969-8ca1ec5285b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8b1fed5-b777-41de-9036-a32be2e1a4b2");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08685fc3-9fb7-4b72-86d6-bb416c5ce708", null, "User", "USER" },
                    { "580df287-f57a-4076-941a-8b9380c3caf9", null, "Guest", "GUEST" },
                    { "71d958ea-a3da-4da8-ba32-bb06011b5bae", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08685fc3-9fb7-4b72-86d6-bb416c5ce708");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "580df287-f57a-4076-941a-8b9380c3caf9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71d958ea-a3da-4da8-ba32-bb06011b5bae");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d38d26f-5f05-46d0-8b9a-ec96449f5714", null, "User", "USER" },
                    { "65f153ec-b6fb-41a2-b969-8ca1ec5285b1", null, "Administrator", "ADMINISTRATOR" },
                    { "b8b1fed5-b777-41de-9036-a32be2e1a4b2", null, "Guest", "GUEST" }
                });
        }
    }
}
