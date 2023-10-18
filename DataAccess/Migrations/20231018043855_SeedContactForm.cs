using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MojeVlastniStranka.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedContactForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 10, 18, 6, 38, 55, 8, DateTimeKind.Local).AddTicks(3784));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 10, 18, 6, 38, 55, 8, DateTimeKind.Local).AddTicks(3865));

            migrationBuilder.InsertData(
                table: "ContactForm",
                columns: new[] { "Id", "Date", "Email", "FeedBack", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 10, new DateTime(2023, 10, 18, 6, 38, 55, 8, DateTimeKind.Local).AddTicks(4216), "jan.novak@example.com", "Dobrý den, rád bych se zeptal na možnost spolupráce.", "Jan", "Novák", "123456789" },
                    { 20, new DateTime(2023, 10, 18, 6, 38, 55, 8, DateTimeKind.Local).AddTicks(4230), "info@kostlanovec.cz", "Dobrý, mám zájem o nové stránky vámi vyrobené. Těším se, až mi ukážete, co všechno dokážete.", "Jan", "Kostlán", "987654321" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactForm",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ContactForm",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 10, 15, 13, 33, 56, 42, DateTimeKind.Local).AddTicks(855));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 10, 15, 13, 33, 56, 42, DateTimeKind.Local).AddTicks(905));
        }
    }
}
