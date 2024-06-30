using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MojeVlastniStranka.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class IdontKnow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: new Guid("843c0b41-cf77-48f9-8c76-52942760a843"));

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: new Guid("cfbe756f-b600-4736-8af4-8d7eab13b118"));

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("c0cd39bb-d087-4c28-939d-e967e34d906d"));

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("d547254f-44fb-4521-8307-f56c2eb8b6c3"));

            migrationBuilder.DeleteData(
                table: "ContactForm",
                keyColumn: "Id",
                keyValue: new Guid("48403d09-50e0-4458-92d5-833c9eeb3aab"));

            migrationBuilder.DeleteData(
                table: "ContactForm",
                keyColumn: "Id",
                keyValue: new Guid("66df0d27-55fb-4592-a37d-cc490bb9a0f2"));

            migrationBuilder.DeleteData(
                table: "IdeaToReleases",
                keyColumn: "Id",
                keyValue: new Guid("78265a7e-4e05-4797-bc2b-406d56a17a24"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("4b184b10-768b-41f4-9b2d-a7cf863f63ed"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("8e264bb8-9daf-4623-b3ec-64d334cac320"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("393f0d7e-211c-4ddc-9fe6-7372729431de"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("4a75f53d-432c-4d56-8eaf-51d3e4d7a2af"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("8fa392ab-2704-4adc-bc4b-3d5e2f286789"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("99fce4f6-262e-49ff-bc23-4d2cb83e7460"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("de50505d-931b-4dcf-bdc8-256bf3cc6a2d"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("f75f9909-3ec8-4997-8c66-5abe30b09f02"));

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: new Guid("ba246baf-081d-4f19-8c84-fe78c63483be"));

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: new Guid("c39a1ce0-e53c-4b3c-8a06-f025f5aecb73"));

            migrationBuilder.DropColumn(
                name: "FeedBack",
                table: "ContactForm");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "ContactForm");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "ContactForm");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "ContactForm",
                type: "nvarchar(1000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "ContactForm",
                type: "nvarchar(1000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BlogCategories",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Message",
                table: "ContactForm");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "ContactForm",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)");

            migrationBuilder.AddColumn<string>(
                name: "FeedBack",
                table: "ContactForm",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "ContactForm",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "ContactForm",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BlogCategories",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.InsertData(
                table: "BlogCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("843c0b41-cf77-48f9-8c76-52942760a843"), "blogpříspěvky" },
                    { new Guid("ba246baf-081d-4f19-8c84-fe78c63483be"), "projekty" },
                    { new Guid("c39a1ce0-e53c-4b3c-8a06-f025f5aecb73"), "neurčený" },
                    { new Guid("cfbe756f-b600-4736-8af4-8d7eab13b118"), "základ" }
                });

            migrationBuilder.InsertData(
                table: "ContactForm",
                columns: new[] { "Id", "Date", "Email", "FeedBack", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("48403d09-50e0-4458-92d5-833c9eeb3aab"), new DateTime(2024, 6, 30, 17, 6, 33, 722, DateTimeKind.Local).AddTicks(6428), "jan.novak@example.com", "Dobrý den, rád bych se zeptal na možnost spolupráce.", "Jan", "Novák", "123456789" },
                    { new Guid("66df0d27-55fb-4592-a37d-cc490bb9a0f2"), new DateTime(2024, 6, 30, 17, 6, 33, 722, DateTimeKind.Local).AddTicks(6438), "info@kostlanovec.cz", "Dobrý, mám zájem o nové stránky vámi vyrobené. Těším se, až mi ukážete, co všechno dokážete.", "Jan", "Kostlán", "987654321" }
                });

            migrationBuilder.InsertData(
                table: "IdeaToReleases",
                columns: new[] { "Id", "DatePosted", "Idea" },
                values: new object[] { new Guid("78265a7e-4e05-4797-bc2b-406d56a17a24"), new DateTime(2024, 6, 30, 17, 6, 33, 722, DateTimeKind.Local).AddTicks(6464), "Chtěl bych vytvořit nějakou animaci na vytváření koblih" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Description", "FileName" },
                values: new object[,]
                {
                    { new Guid("4b184b10-768b-41f4-9b2d-a7cf863f63ed"), "stín minulosti", "stinminulosti.jpg" },
                    { new Guid("8e264bb8-9daf-4623-b3ec-64d334cac320"), "konec světa", "konecsveta.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Content", "Date", "Description", "ImagePath", "Keywords", "Name", "Slug", "Title", "projectStatus" },
                values: new object[,]
                {
                    { new Guid("393f0d7e-211c-4ddc-9fe6-7372729431de"), "obsah", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Local), "Description 3", "/images/tvorbaher.jpg", "Keywords 3", "Project 3", "slug-3", "Title 3", 2 },
                    { new Guid("4a75f53d-432c-4d56-8eaf-51d3e4d7a2af"), "obsah", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Local), "Description 5", "/images/tvorbaher.jpg", "Keywords 5", "Project 5", "slug-5", "Title 5", 1 },
                    { new Guid("8fa392ab-2704-4adc-bc4b-3d5e2f286789"), "obsah", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Local), "Description 2", "/images/tvorbaher.jpg", "Keywords 2", "Project 2", "slug-2", "Title 2", 1 },
                    { new Guid("99fce4f6-262e-49ff-bc23-4d2cb83e7460"), "obsah", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Local), "Description 1", "/images/tvorbaher.jpg", "Keywords 1", "Project 1", "slug-1", "Title 1", 0 },
                    { new Guid("de50505d-931b-4dcf-bdc8-256bf3cc6a2d"), "obsah", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Local), "Description 4", "/images/tvorbaher.jpg", "Keywords 4", "Project 4", "slug-4", "Title 4", 0 },
                    { new Guid("f75f9909-3ec8-4997-8c66-5abe30b09f02"), "obsah", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Local), "Description 6", "/images/tvorbaher.jpg", "Keywords 6", "Project 6", "slug-6", "Title 6", 2 }
                });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "Author", "BlogCategoryId", "Content", "Date", "Description", "ImagePath", "Keywords", "Name", "Slug", "Title" },
                values: new object[,]
                {
                    { new Guid("c0cd39bb-d087-4c28-939d-e967e34d906d"), "Chleba s marmeládou", new Guid("ba246baf-081d-4f19-8c84-fe78c63483be"), "<h1>Projekt</h1>", new DateTime(2024, 6, 30, 17, 6, 33, 722, DateTimeKind.Local).AddTicks(6179), "moje klobasa", "blogimages/boxing.jpg", "Jsi slizký had, nemám tě rád", "deset malych cernousku", "deset-malych-cernousku", "Pět malých kačátek" },
                    { new Guid("d547254f-44fb-4521-8307-f56c2eb8b6c3"), "Pepek Námořník", new Guid("c39a1ce0-e53c-4b3c-8a06-f025f5aecb73"), "<h1>Ahoj</h1>", new DateTime(2024, 6, 30, 17, 6, 33, 722, DateTimeKind.Local).AddTicks(6118), "moje klobasa", "blogimages/boxing.jpg", "rohlík, klobása", "Jak mit obri pero", "Jak-mit-obri-pero", "Deset malých švestek" }
                });
        }
    }
}
