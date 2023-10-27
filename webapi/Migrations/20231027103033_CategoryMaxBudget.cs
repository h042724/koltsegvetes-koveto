using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class CategoryMaxBudget : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxBudget",
                table: "category",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "ID",
                keyValue: 1,
                column: "MaxBudget",
                value: 0);

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "ID",
                keyValue: 2,
                column: "MaxBudget",
                value: 0);

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "ID",
                keyValue: 3,
                column: "MaxBudget",
                value: 0);

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "ID",
                keyValue: 4,
                column: "MaxBudget",
                value: 0);

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "ID",
                keyValue: 5,
                column: "MaxBudget",
                value: 0);

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "ID",
                keyValue: 6,
                column: "MaxBudget",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxBudget",
                table: "category");
        }
    }
}
