using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojeVlastniStranka.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89e04b6f-0640-46f0-8d9c-27181481c533");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d785cfbb-ac25-454e-893e-61c5cc3d47c9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "728db716-caaf-48c4-8d6d-3a8df231b9c5", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "413971f7-1300-4953-b56e-8f18d0dce595", 0, "68c38eab-c40e-41cf-b241-78f87140471b", "info@kostlanovec.cz", true, false, null, "INFO@KOSTLANOVEC.CZ", "ADMIN", "[REDACTED_HASH]", null, false, "babdacf3-a604-4b94-873b-ced7188b9485", false, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "728db716-caaf-48c4-8d6d-3a8df231b9c5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "413971f7-1300-4953-b56e-8f18d0dce595");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "89e04b6f-0640-46f0-8d9c-27181481c533", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d785cfbb-ac25-454e-893e-61c5cc3d47c9", 0, "208baf6f-e8c5-4096-a45c-55e7497c3816", "info@kostlanovec.cz", true, false, null, "INFO@KOSTLANOVEC.CZ", "ADMIN", "[REDACTED_HASH]", null, false, "f35b716a-4186-4276-8ebc-a91ff8edbbe3", false, "admin" });
        }
    }
}
