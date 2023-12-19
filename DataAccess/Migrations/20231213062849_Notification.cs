using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojeVlastniStranka.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Notification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimePublish = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShortMessage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 12, 13, 7, 28, 48, 880, DateTimeKind.Local).AddTicks(1368));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 12, 13, 7, 28, 48, 880, DateTimeKind.Local).AddTicks(1425));

            migrationBuilder.UpdateData(
                table: "ContactForm",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2023, 12, 13, 7, 28, 48, 880, DateTimeKind.Local).AddTicks(1615));

            migrationBuilder.UpdateData(
                table: "ContactForm",
                keyColumn: "Id",
                keyValue: 20,
                column: "Date",
                value: new DateTime(2023, 12, 13, 7, 28, 48, 880, DateTimeKind.Local).AddTicks(1623));

            migrationBuilder.UpdateData(
                table: "IdeaToReleases",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePosted",
                value: new DateTime(2023, 12, 13, 7, 28, 48, 880, DateTimeKind.Local).AddTicks(1644));

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "ShortMessage", "TimePublish" },
                values: new object[] { 1, "Testovací notifikace", new DateTime(2023, 12, 13, 7, 28, 48, 880, DateTimeKind.Local).AddTicks(1668) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

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
    }
}
