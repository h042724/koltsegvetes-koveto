using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class CategoryFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "transactions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ExpenseOrIncome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c481baa-50f6-4942-bc07-6080a9ff1100", null, "Administrator", "ADMINISTRATOR" },
                    { "9b893d6e-58dd-45b3-81e8-d2592481b8ef", null, "Guest", "GUEST" },
                    { "a50637b8-fe6f-4491-bc3c-dbc64a736869", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_transactions_CategoryID",
                table: "transactions",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_category_CategoryID",
                table: "transactions",
                column: "CategoryID",
                principalTable: "category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_category_CategoryID",
                table: "transactions");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropIndex(
                name: "IX_transactions_CategoryID",
                table: "transactions");

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

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "transactions");

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
    }
}
