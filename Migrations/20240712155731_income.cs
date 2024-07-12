using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpenseTracker.Migrations
{
    /// <inheritdoc />
    public partial class income : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Amount", "CategoryId", "Date", "Planned", "Title" },
                values: new object[,]
                {
                    { 1, 150f, 1, new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Grocery Shopping" },
                    { 2, 40f, 3, new DateTime(2023, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Movie Tickets" },
                    { 3, 100f, 4, new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, "Online Course" },
                    { 4, 80f, 5, new DateTime(2023, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, "New Jeans" }
                });

            migrationBuilder.InsertData(
                table: "Incomes",
                columns: new[] { "Id", "Amount", "Date", "Title", "Type" },
                values: new object[,]
                {
                    { 1, 3000f, new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Monthly Salary", 0 },
                    { 2, 500f, new DateTime(2023, 7, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Scholarship Award", 1 },
                    { 3, 200f, new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Birthday Gift", 2 },
                    { 4, 1000f, new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Utc), "Lottery Winnings", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
