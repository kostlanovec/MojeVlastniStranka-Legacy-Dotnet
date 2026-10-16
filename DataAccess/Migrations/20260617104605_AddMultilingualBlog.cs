using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojeVlastniStranka.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMultilingualBlog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentEn",
                table: "BlogPosts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                table: "BlogPosts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeywordsEn",
                table: "BlogPosts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "BlogPosts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleEn",
                table: "BlogPosts",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentEn",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "KeywordsEn",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "TitleEn",
                table: "BlogPosts");
        }
    }
}
