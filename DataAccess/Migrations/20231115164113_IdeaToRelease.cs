using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojeVlastniStranka.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class IdeaToRelease : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdeaToReleases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePosted = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdeaToReleases", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "neurčený");

            migrationBuilder.InsertData(
                table: "BlogCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "základ" });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Description" },
                values: new object[] { new DateTime(2023, 11, 15, 17, 41, 12, 782, DateTimeKind.Local).AddTicks(1488), "moje klobasa" });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Description" },
                values: new object[] { new DateTime(2023, 11, 15, 17, 41, 12, 782, DateTimeKind.Local).AddTicks(1556), "moje klobasa" });

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

            migrationBuilder.InsertData(
                table: "IdeaToReleases",
                columns: new[] { "Id", "DatePosted", "Idea" },
                values: new object[] { 1, new DateTime(2023, 11, 15, 17, 41, 12, 782, DateTimeKind.Local).AddTicks(1869), "Chtěl bych vytvořit nějakou animaci na vytváření koblih" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdeaToReleases");

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "základ");

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Description" },
                values: new object[] { new DateTime(2023, 10, 18, 6, 38, 55, 8, DateTimeKind.Local).AddTicks(3784), "moje klbasa" });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Description" },
                values: new object[] { new DateTime(2023, 10, 18, 6, 38, 55, 8, DateTimeKind.Local).AddTicks(3865), "moje klbasa" });

            migrationBuilder.UpdateData(
                table: "ContactForm",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2023, 10, 18, 6, 38, 55, 8, DateTimeKind.Local).AddTicks(4216));

            migrationBuilder.UpdateData(
                table: "ContactForm",
                keyColumn: "Id",
                keyValue: 20,
                column: "Date",
                value: new DateTime(2023, 10, 18, 6, 38, 55, 8, DateTimeKind.Local).AddTicks(4230));
        }
    }
}
