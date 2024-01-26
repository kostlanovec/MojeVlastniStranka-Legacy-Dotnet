using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojeVlastniStranka.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CanNullPhoneNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "ContactForm",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 1, 26, 13, 23, 55, 361, DateTimeKind.Local).AddTicks(3831));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 1, 26, 13, 23, 55, 361, DateTimeKind.Local).AddTicks(3883));

            migrationBuilder.UpdateData(
                table: "ContactForm",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2024, 1, 26, 13, 23, 55, 361, DateTimeKind.Local).AddTicks(4025));

            migrationBuilder.UpdateData(
                table: "ContactForm",
                keyColumn: "Id",
                keyValue: 20,
                column: "Date",
                value: new DateTime(2024, 1, 26, 13, 23, 55, 361, DateTimeKind.Local).AddTicks(4031));

            migrationBuilder.UpdateData(
                table: "IdeaToReleases",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePosted",
                value: new DateTime(2024, 1, 26, 13, 23, 55, 361, DateTimeKind.Local).AddTicks(4044));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimePublish",
                value: new DateTime(2024, 1, 26, 13, 23, 55, 361, DateTimeKind.Local).AddTicks(4057));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContactForm",
                keyColumn: "PhoneNumber",
                keyValue: null,
                column: "PhoneNumber",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "ContactForm",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 1, 6, 11, 15, 56, 631, DateTimeKind.Local).AddTicks(2058));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 1, 6, 11, 15, 56, 631, DateTimeKind.Local).AddTicks(2333));

            migrationBuilder.UpdateData(
                table: "ContactForm",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2024, 1, 6, 11, 15, 56, 631, DateTimeKind.Local).AddTicks(3488));

            migrationBuilder.UpdateData(
                table: "ContactForm",
                keyColumn: "Id",
                keyValue: 20,
                column: "Date",
                value: new DateTime(2024, 1, 6, 11, 15, 56, 631, DateTimeKind.Local).AddTicks(3538));

            migrationBuilder.UpdateData(
                table: "IdeaToReleases",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePosted",
                value: new DateTime(2024, 1, 6, 11, 15, 56, 631, DateTimeKind.Local).AddTicks(3670));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimePublish",
                value: new DateTime(2024, 1, 6, 11, 15, 56, 631, DateTimeKind.Local).AddTicks(3806));
        }
    }
}
