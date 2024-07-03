using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MojeVlastniStranka.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CategoryCanBeNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_BlogCategories_BlogCategoryId",
                table: "BlogPosts");

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: new Guid("629d3f4b-46c7-4b30-82ff-ff68c2b75e58"));

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: new Guid("de67dcc3-3ea6-46ab-9716-9a66f14a26b4"));

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("5568548b-8cb0-46a1-99e2-67887ddafc74"));

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("88b839b5-7875-43aa-b240-0f7eae7ec165"));

            migrationBuilder.DeleteData(
                table: "ContactForm",
                keyColumn: "Id",
                keyValue: new Guid("23e505ac-8234-41cd-8afd-9c97bd2241bc"));

            migrationBuilder.DeleteData(
                table: "ContactForm",
                keyColumn: "Id",
                keyValue: new Guid("bd6fe48a-1109-4b42-8bf0-d7d84d0652a4"));

            migrationBuilder.DeleteData(
                table: "IdeaToReleases",
                keyColumn: "Id",
                keyValue: new Guid("dc251d25-9e40-4d3a-acac-10efa1e41da7"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3f9ba961-d98b-4982-b6fe-5edac2484757"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("7efa9722-0c4f-4600-ab2f-47eacdfc3134"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("07e5a851-20cb-468e-8757-b16dd9875887"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("236be4fc-9cd8-4cb6-b86c-ed067c0298e6"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("9b1b2dd9-8d07-4bc2-8f93-7af853f66337"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("a69bfb19-d45b-416f-bfea-1ee64ea8b31a"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("c4ef15a1-a7b2-4a8c-8a28-b8f3183fc155"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("dace6f00-ef41-46f7-95b7-a27a551986c4"));

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: new Guid("46099960-9f61-41ac-a84a-c03fc15a1d95"));

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: new Guid("87fb7223-5e3e-4274-a881-5650ac58e943"));

            migrationBuilder.AlterColumn<Guid>(
                name: "BlogCategoryId",
                table: "BlogPosts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "BlogCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("8ab50b6b-19c5-4d48-bbd7-33bc98811b8f"), "základ" },
                    { new Guid("910ccdf3-28ca-4b69-a693-f6b3a6a8f453"), "neurčený" },
                    { new Guid("a97e20f2-565c-4357-b914-5089685eb793"), "projekty" },
                    { new Guid("d5e16492-d209-4f94-82d4-404d9c219c85"), "blogpříspěvky" }
                });

            migrationBuilder.InsertData(
                table: "ContactForm",
                columns: new[] { "Id", "Date", "Email", "Message", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("67be1ee3-3709-4ea3-91e2-21cb47a33f27"), new DateTime(2024, 7, 1, 15, 41, 0, 402, DateTimeKind.Local).AddTicks(1500), "jan.novak@example.com", "Dobrý den, rád bych se zeptal na možnost spolupráce.", "123456789" },
                    { new Guid("f80c0bb1-306f-4ff9-a192-ae877179e18c"), new DateTime(2024, 7, 1, 15, 41, 0, 402, DateTimeKind.Local).AddTicks(1506), "info@kostlanovec.cz", "Dobrý, mám zájem o nové stránky vámi vyrobené. Těším se, až mi ukážete, co všechno dokážete.", "987654321" }
                });

            migrationBuilder.InsertData(
                table: "IdeaToReleases",
                columns: new[] { "Id", "DatePosted", "Idea" },
                values: new object[] { new Guid("794ac2d1-46d6-4087-bf6a-3585647f8f26"), new DateTime(2024, 7, 1, 15, 41, 0, 402, DateTimeKind.Local).AddTicks(1529), "Chtěl bych vytvořit nějakou animaci na vytváření koblih" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Description", "FileName" },
                values: new object[,]
                {
                    { new Guid("a681a891-ad4f-4d39-9f9c-8a07659f29f3"), "stín minulosti", "stinminulosti.jpg" },
                    { new Guid("c04cd068-3eb7-4738-8433-e46626d99327"), "konec světa", "konecsveta.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Content", "Date", "Description", "ImagePath", "Keywords", "Name", "Slug", "Title", "projectStatus" },
                values: new object[,]
                {
                    { new Guid("1bc4fadf-51a4-4788-bdf9-5754bb071b60"), "obsah", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Local), "Description 6", "/images/tvorbaher.jpg", "Keywords 6", "Project 6", "slug-6", "Title 6", 2 },
                    { new Guid("4a99f581-47df-4d97-bb30-9043a5f3229d"), "obsah", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Local), "Description 4", "/images/tvorbaher.jpg", "Keywords 4", "Project 4", "slug-4", "Title 4", 0 },
                    { new Guid("55d01bb9-6be7-411e-95e3-6cb87543f54f"), "obsah", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Local), "Description 5", "/images/tvorbaher.jpg", "Keywords 5", "Project 5", "slug-5", "Title 5", 1 },
                    { new Guid("7ad679cf-8cd7-46bf-b329-8e39f4844001"), "obsah", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Local), "Description 1", "/images/tvorbaher.jpg", "Keywords 1", "Project 1", "slug-1", "Title 1", 0 },
                    { new Guid("9330ab6d-c461-48e4-a2e5-7e0e906c37cf"), "obsah", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Local), "Description 2", "/images/tvorbaher.jpg", "Keywords 2", "Project 2", "slug-2", "Title 2", 1 },
                    { new Guid("f73bb7f5-032d-4cfa-a2b4-52a966b1ee16"), "obsah", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Local), "Description 3", "/images/tvorbaher.jpg", "Keywords 3", "Project 3", "slug-3", "Title 3", 2 }
                });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "Author", "BlogCategoryId", "Content", "Date", "Description", "ImagePath", "Keywords", "Name", "Slug", "Title" },
                values: new object[,]
                {
                    { new Guid("46ce660f-6d34-49bc-b03f-910a6f5c7cb9"), "Pepek Námořník", new Guid("910ccdf3-28ca-4b69-a693-f6b3a6a8f453"), "<h1>Ahoj</h1>", new DateTime(2024, 7, 1, 15, 41, 0, 402, DateTimeKind.Local).AddTicks(1126), "moje klobasa", "blogimages/boxing.jpg", "rohlík, klobása", "Jak mit obri pero", "Jak-mit-obri-pero", "Deset malých švestek" },
                    { new Guid("6b17edde-dbc2-44a8-8454-6bc7997af8e3"), "Chleba s marmeládou", new Guid("a97e20f2-565c-4357-b914-5089685eb793"), "<h1>Projekt</h1>", new DateTime(2024, 7, 1, 15, 41, 0, 402, DateTimeKind.Local).AddTicks(1186), "moje klobasa", "blogimages/boxing.jpg", "Jsi slizký had, nemám tě rád", "deset malych cernousku", "deset-malych-cernousku", "Pět malých kačátek" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_BlogCategories_BlogCategoryId",
                table: "BlogPosts",
                column: "BlogCategoryId",
                principalTable: "BlogCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_BlogCategories_BlogCategoryId",
                table: "BlogPosts");

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: new Guid("8ab50b6b-19c5-4d48-bbd7-33bc98811b8f"));

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: new Guid("d5e16492-d209-4f94-82d4-404d9c219c85"));

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("46ce660f-6d34-49bc-b03f-910a6f5c7cb9"));

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("6b17edde-dbc2-44a8-8454-6bc7997af8e3"));

            migrationBuilder.DeleteData(
                table: "ContactForm",
                keyColumn: "Id",
                keyValue: new Guid("67be1ee3-3709-4ea3-91e2-21cb47a33f27"));

            migrationBuilder.DeleteData(
                table: "ContactForm",
                keyColumn: "Id",
                keyValue: new Guid("f80c0bb1-306f-4ff9-a192-ae877179e18c"));

            migrationBuilder.DeleteData(
                table: "IdeaToReleases",
                keyColumn: "Id",
                keyValue: new Guid("794ac2d1-46d6-4087-bf6a-3585647f8f26"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("a681a891-ad4f-4d39-9f9c-8a07659f29f3"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c04cd068-3eb7-4738-8433-e46626d99327"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("1bc4fadf-51a4-4788-bdf9-5754bb071b60"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("4a99f581-47df-4d97-bb30-9043a5f3229d"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("55d01bb9-6be7-411e-95e3-6cb87543f54f"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("7ad679cf-8cd7-46bf-b329-8e39f4844001"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("9330ab6d-c461-48e4-a2e5-7e0e906c37cf"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("f73bb7f5-032d-4cfa-a2b4-52a966b1ee16"));

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: new Guid("910ccdf3-28ca-4b69-a693-f6b3a6a8f453"));

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: new Guid("a97e20f2-565c-4357-b914-5089685eb793"));

            migrationBuilder.AlterColumn<Guid>(
                name: "BlogCategoryId",
                table: "BlogPosts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "BlogCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("46099960-9f61-41ac-a84a-c03fc15a1d95"), "neurčený" },
                    { new Guid("629d3f4b-46c7-4b30-82ff-ff68c2b75e58"), "základ" },
                    { new Guid("87fb7223-5e3e-4274-a881-5650ac58e943"), "projekty" },
                    { new Guid("de67dcc3-3ea6-46ab-9716-9a66f14a26b4"), "blogpříspěvky" }
                });

            migrationBuilder.InsertData(
                table: "ContactForm",
                columns: new[] { "Id", "Date", "Email", "Message", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("23e505ac-8234-41cd-8afd-9c97bd2241bc"), new DateTime(2024, 6, 30, 20, 31, 5, 964, DateTimeKind.Local).AddTicks(120), "info@kostlanovec.cz", "Dobrý, mám zájem o nové stránky vámi vyrobené. Těším se, až mi ukážete, co všechno dokážete.", "987654321" },
                    { new Guid("bd6fe48a-1109-4b42-8bf0-d7d84d0652a4"), new DateTime(2024, 6, 30, 20, 31, 5, 964, DateTimeKind.Local).AddTicks(111), "jan.novak@example.com", "Dobrý den, rád bych se zeptal na možnost spolupráce.", "123456789" }
                });

            migrationBuilder.InsertData(
                table: "IdeaToReleases",
                columns: new[] { "Id", "DatePosted", "Idea" },
                values: new object[] { new Guid("dc251d25-9e40-4d3a-acac-10efa1e41da7"), new DateTime(2024, 6, 30, 20, 31, 5, 964, DateTimeKind.Local).AddTicks(146), "Chtěl bych vytvořit nějakou animaci na vytváření koblih" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Description", "FileName" },
                values: new object[,]
                {
                    { new Guid("3f9ba961-d98b-4982-b6fe-5edac2484757"), "konec světa", "konecsveta.jpg" },
                    { new Guid("7efa9722-0c4f-4600-ab2f-47eacdfc3134"), "stín minulosti", "stinminulosti.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Content", "Date", "Description", "ImagePath", "Keywords", "Name", "Slug", "Title", "projectStatus" },
                values: new object[,]
                {
                    { new Guid("07e5a851-20cb-468e-8757-b16dd9875887"), "obsah", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Local), "Description 4", "/images/tvorbaher.jpg", "Keywords 4", "Project 4", "slug-4", "Title 4", 0 },
                    { new Guid("236be4fc-9cd8-4cb6-b86c-ed067c0298e6"), "obsah", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Local), "Description 3", "/images/tvorbaher.jpg", "Keywords 3", "Project 3", "slug-3", "Title 3", 2 },
                    { new Guid("9b1b2dd9-8d07-4bc2-8f93-7af853f66337"), "obsah", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Local), "Description 5", "/images/tvorbaher.jpg", "Keywords 5", "Project 5", "slug-5", "Title 5", 1 },
                    { new Guid("a69bfb19-d45b-416f-bfea-1ee64ea8b31a"), "obsah", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Local), "Description 1", "/images/tvorbaher.jpg", "Keywords 1", "Project 1", "slug-1", "Title 1", 0 },
                    { new Guid("c4ef15a1-a7b2-4a8c-8a28-b8f3183fc155"), "obsah", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Local), "Description 2", "/images/tvorbaher.jpg", "Keywords 2", "Project 2", "slug-2", "Title 2", 1 },
                    { new Guid("dace6f00-ef41-46f7-95b7-a27a551986c4"), "obsah", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Local), "Description 6", "/images/tvorbaher.jpg", "Keywords 6", "Project 6", "slug-6", "Title 6", 2 }
                });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "Author", "BlogCategoryId", "Content", "Date", "Description", "ImagePath", "Keywords", "Name", "Slug", "Title" },
                values: new object[,]
                {
                    { new Guid("5568548b-8cb0-46a1-99e2-67887ddafc74"), "Chleba s marmeládou", new Guid("87fb7223-5e3e-4274-a881-5650ac58e943"), "<h1>Projekt</h1>", new DateTime(2024, 6, 30, 20, 31, 5, 963, DateTimeKind.Local).AddTicks(9588), "moje klobasa", "blogimages/boxing.jpg", "Jsi slizký had, nemám tě rád", "deset malych cernousku", "deset-malych-cernousku", "Pět malých kačátek" },
                    { new Guid("88b839b5-7875-43aa-b240-0f7eae7ec165"), "Pepek Námořník", new Guid("46099960-9f61-41ac-a84a-c03fc15a1d95"), "<h1>Ahoj</h1>", new DateTime(2024, 6, 30, 20, 31, 5, 963, DateTimeKind.Local).AddTicks(9535), "moje klobasa", "blogimages/boxing.jpg", "rohlík, klobása", "Jak mit obri pero", "Jak-mit-obri-pero", "Deset malých švestek" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_BlogCategories_BlogCategoryId",
                table: "BlogPosts",
                column: "BlogCategoryId",
                principalTable: "BlogCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
