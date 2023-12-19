using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojeVlastniStranka.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedingNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "projekty");

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "blogpříspěvky");

            migrationBuilder.InsertData(
                table: "BlogCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "základ" });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 12, 11, 17, 44, 59, 544, DateTimeKind.Local).AddTicks(1998));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 12, 11, 17, 44, 59, 544, DateTimeKind.Local).AddTicks(2061));

            migrationBuilder.UpdateData(
                table: "ContactForm",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2023, 12, 11, 17, 44, 59, 544, DateTimeKind.Local).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "ContactForm",
                keyColumn: "Id",
                keyValue: 20,
                column: "Date",
                value: new DateTime(2023, 12, 11, 17, 44, 59, 544, DateTimeKind.Local).AddTicks(2304));

            migrationBuilder.UpdateData(
                table: "IdeaToReleases",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePosted",
                value: new DateTime(2023, 12, 11, 17, 44, 59, 544, DateTimeKind.Local).AddTicks(2326));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "blogpříspěvky");

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "základ");

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
    }
}