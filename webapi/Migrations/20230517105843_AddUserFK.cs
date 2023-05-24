using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class AddUserFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "UserID",
                table: "transactions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9328f92c-af02-4c8c-94fc-13e919c69231", null, "Guest", "GUEST" },
                    { "b1d0b57c-ea29-4254-896d-9419f6a8a50e", null, "Administrator", "ADMINISTRATOR" },
                    { "ec020bf9-ea50-473c-9801-14399a934cd1", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_transactions_UserID",
                table: "transactions",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_AspNetUsers_UserID",
                table: "transactions",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_AspNetUsers_UserID",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_transactions_UserID",
                table: "transactions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9328f92c-af02-4c8c-94fc-13e919c69231");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1d0b57c-ea29-4254-896d-9419f6a8a50e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec020bf9-ea50-473c-9801-14399a934cd1");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "transactions");

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
    }
}
