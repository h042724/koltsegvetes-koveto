using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class AddedCategoryIcons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "IconName",
                table: "category",
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

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "ID",
                keyValue: 1,
                column: "IconName",
                value: "nutrition");

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "ID",
                keyValue: 2,
                column: "IconName",
                value: "directions_car");

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "ID",
                keyValue: 3,
                column: "IconName",
                value: "attractions");

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "ID",
                keyValue: 4,
                column: "IconName",
                value: "payments");

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "ID",
                keyValue: 5,
                column: "IconName",
                value: "monetization_on");

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "ID",
                keyValue: 6,
                column: "IconName",
                value: "real_estate_agent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "IconName",
                table: "category");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3df52fbb-d560-4b87-8aee-7d338f079669", null, "Administrator", "ADMINISTRATOR" },
                    { "48d132fd-5769-48c3-b48e-4fd5a4fbf6ab", null, "User", "USER" },
                    { "a31d8de7-8e88-4839-b98e-14cf4b847693", null, "Guest", "GUEST" }
                });
        }
    }
}
