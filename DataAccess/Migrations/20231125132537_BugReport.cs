using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojeVlastniStranka.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class BugReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportedBugs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePosted = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportedBugs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 11, 25, 14, 25, 37, 650, DateTimeKind.Local).AddTicks(7854));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 11, 25, 14, 25, 37, 650, DateTimeKind.Local).AddTicks(7905));

            migrationBuilder.UpdateData(
                table: "ContactForm",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2023, 11, 25, 14, 25, 37, 650, DateTimeKind.Local).AddTicks(8053));

            migrationBuilder.UpdateData(
                table: "ContactForm",
                keyColumn: "Id",
                keyValue: 20,
                column: "Date",
                value: new DateTime(2023, 11, 25, 14, 25, 37, 650, DateTimeKind.Local).AddTicks(8060));

            migrationBuilder.UpdateData(
                table: "IdeaToReleases",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePosted",
                value: new DateTime(2023, 11, 25, 14, 25, 37, 650, DateTimeKind.Local).AddTicks(8073));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportedBugs");

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 11, 15, 17, 41, 12, 782, DateTimeKind.Local).AddTicks(1488));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 11, 15, 17, 41, 12, 782, DateTimeKind.Local).AddTicks(1556));

            migrationBuilder.UpdateData(
                table: "ContactForm",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2023, 11, 15, 17, 41, 12, 782, DateTimeKind.Local).AddTicks(1828));

            migrationBuilder.UpdateData(
                table: "ContactForm",
                keyColumn: "Id",
                keyValue: 20,
                column: "Date",
                value: new DateTime(2023, 11, 15, 17, 41, 12, 782, DateTimeKind.Local).AddTicks(1839));

            migrationBuilder.UpdateData(
                table: "IdeaToReleases",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePosted",
                value: new DateTime(2023, 11, 15, 17, 41, 12, 782, DateTimeKind.Local).AddTicks(1869));
        }
    }
}
