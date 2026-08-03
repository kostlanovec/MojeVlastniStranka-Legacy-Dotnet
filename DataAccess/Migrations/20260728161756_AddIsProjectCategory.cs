using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojeVlastniStranka.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddIsProjectCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsProjectCategory",
                table: "BlogCategories",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsProjectCategory",
                table: "BlogCategories");
        }
    }
}
