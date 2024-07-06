using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MojeVlastniStranka.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PasswordBro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b33bf885-20c9-4b2f-b634-d7c2ef6cddb4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("425928ef-df2f-415f-8a4a-b42b325c47d7"));

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: new Guid("a769b14f-fcac-448c-9a07-1c3787eff180"));

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: new Guid("fe916dbe-800e-4dcd-8d57-acb621ca1e5c"));

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("200dd600-648e-4c0b-8b8b-35193b6c9b66"));

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("931d2ae0-7637-44f2-8c43-ecd77666b81e"));

            migrationBuilder.DeleteData(
                table: "ContactForm",
                keyColumn: "Id",
                keyValue: new Guid("22a676a1-ce54-49f7-be71-ba3ca75b80e4"));

            migrationBuilder.DeleteData(
                table: "ContactForm",
                keyColumn: "Id",
                keyValue: new Guid("d560e027-0f46-40e0-8bcf-5c4484119c52"));

            migrationBuilder.DeleteData(
                table: "IdeaToReleases",
                keyColumn: "Id",
                keyValue: new Guid("7194e5e4-afbf-41fd-be4b-5f7135cb025c"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b40d9bc0-8324-47d8-b032-c150ea7ca59b"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("ba857d38-f350-4177-be81-0c4c56345e3a"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("01d4ce50-1c49-491d-a42e-4fcb04452cce"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("533f8cd5-5206-45f2-98b8-d65abc165594"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("55eba25b-9db7-4aaf-8943-6560b0da691a"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("eafea372-6439-4308-8d9b-9003f269b34b"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("fa85c0aa-be89-4bcc-8206-c54c309cc7a9"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("fc3e5cf2-fbde-41c9-95ba-8158f8dc35a6"));

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: new Guid("48c1f357-fd4c-4c40-91e5-b6036a1a96e9"));

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: new Guid("b79af3ea-3f70-41b8-9b9f-0eefd526d0d1"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("24a3365e-0cc1-4e17-be00-1bac7d4b84e4"), null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("5d477119-82b9-44f4-8ecc-6a97710aaa45"), 0, "02923bd8-2583-42be-9328-c0cd82ef5613", "info@kostlanovec.cz", true, false, null, "INFO@KOSTLANOVEC.CZ", "ADMIN", "[REDACTED_HASH]", null, false, "f35c4dbc-acfc-4725-955c-5af700d24ac1", false, "admin" });

            migrationBuilder.InsertData(
                table: "BlogCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5e506350-ec5a-4ea6-bd47-18e3a23cd1a3"), "neurčený" },
                    { new Guid("60a69138-b722-4c68-80af-484cb611f0c2"), "základ" },
                    { new Guid("65ddc01b-c3a3-425a-a64d-9137881434e4"), "projekty" },
                    { new Guid("8cec0b5c-b839-41f4-8de8-c80e24d8934d"), "blogpříspěvky" }
                });

            migrationBuilder.InsertData(
                table: "ContactForm",
                columns: new[] { "Id", "Date", "Email", "Message", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("cdc2f2e0-7fb6-41e4-bd96-e719956c0278"), new DateTime(2024, 7, 6, 12, 49, 0, 498, DateTimeKind.Local).AddTicks(3323), "jan.novak@example.com", "Dobrý den, rád bych se zeptal na možnost spolupráce.", "123456789" },
                    { new Guid("db1d6ed2-4062-41e6-9aed-c85580787061"), new DateTime(2024, 7, 6, 12, 49, 0, 498, DateTimeKind.Local).AddTicks(3331), "info@kostlanovec.cz", "Dobrý, mám zájem o nové stránky vámi vyrobené. Těším se, až mi ukážete, co všechno dokážete.", "987654321" }
                });

            migrationBuilder.InsertData(
                table: "IdeaToReleases",
                columns: new[] { "Id", "DatePosted", "Idea" },
                values: new object[] { new Guid("f647b130-0540-492f-9860-206cc2f0af5e"), new DateTime(2024, 7, 6, 12, 49, 0, 498, DateTimeKind.Local).AddTicks(3358), "Chtěl bych vytvořit nějakou animaci na vytváření koblih" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Description", "FileName" },
                values: new object[,]
                {
                    { new Guid("2393bc28-a45d-42ee-8ec1-e5d5a5ca0a86"), "stín minulosti", "stinminulosti.jpg" },
                    { new Guid("86a790e4-b144-4c5e-b7b7-cc6090c30fdf"), "konec světa", "konecsveta.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Content", "Date", "Description", "ImagePath", "Keywords", "Name", "Slug", "Title", "projectStatus" },
                values: new object[,]
                {
                    { new Guid("0f8eb413-ab14-477c-a521-700f662d08a3"), "obsah", new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), "Description 2", "/images/tvorbaher.jpg", "Keywords 2", "Project 2", "slug-2", "Title 2", 1 },
                    { new Guid("345370af-c7e0-4518-91e8-02d308e12f73"), "obsah", new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), "Description 3", "/images/tvorbaher.jpg", "Keywords 3", "Project 3", "slug-3", "Title 3", 2 },
                    { new Guid("59e6abb1-6cbf-4123-a3f3-c5299e451f81"), "obsah", new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), "Description 4", "/images/tvorbaher.jpg", "Keywords 4", "Project 4", "slug-4", "Title 4", 0 },
                    { new Guid("b81d62cf-28c4-49cb-bda5-83037a0f4899"), "obsah", new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), "Description 6", "/images/tvorbaher.jpg", "Keywords 6", "Project 6", "slug-6", "Title 6", 2 },
                    { new Guid("bf255bf4-076f-456b-931e-0717f759189e"), "obsah", new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), "Description 1", "/images/tvorbaher.jpg", "Keywords 1", "Project 1", "slug-1", "Title 1", 0 },
                    { new Guid("d94387af-762c-4e12-a968-7ea61b5fe130"), "obsah", new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), "Description 5", "/images/tvorbaher.jpg", "Keywords 5", "Project 5", "slug-5", "Title 5", 1 }
                });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "Author", "BlogCategoryId", "Content", "Date", "Description", "ImagePath", "Keywords", "Name", "Slug", "Title" },
                values: new object[,]
                {
                    { new Guid("3c9808cd-a5de-454d-afb2-6d4f7a7f31ca"), "Pepek Námořník", new Guid("5e506350-ec5a-4ea6-bd47-18e3a23cd1a3"), "<h1>Ahoj</h1>", new DateTime(2024, 7, 6, 12, 49, 0, 498, DateTimeKind.Local).AddTicks(2996), "moje klobasa", "ímaablogimages/boxing.jpg", "rohlík, klobása", "Jak mit obri pero", "Jak-mit-obri-pero", "Deset malých švestek" },
                    { new Guid("7405a059-041e-47f4-8c46-bbe7d033b730"), "Chleba s marmeládou", new Guid("65ddc01b-c3a3-425a-a64d-9137881434e4"), "<h1>Projekt</h1>", new DateTime(2024, 7, 6, 12, 49, 0, 498, DateTimeKind.Local).AddTicks(3050), "moje klobasa", "blogimages/boxing.jpg", "Jsi slizký had, nemám tě rád", "deset malych cernousku", "deset-malych-cernousku", "Pět malých kačátek" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("24a3365e-0cc1-4e17-be00-1bac7d4b84e4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5d477119-82b9-44f4-8ecc-6a97710aaa45"));

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: new Guid("60a69138-b722-4c68-80af-484cb611f0c2"));

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: new Guid("8cec0b5c-b839-41f4-8de8-c80e24d8934d"));

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("3c9808cd-a5de-454d-afb2-6d4f7a7f31ca"));

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("7405a059-041e-47f4-8c46-bbe7d033b730"));

            migrationBuilder.DeleteData(
                table: "ContactForm",
                keyColumn: "Id",
                keyValue: new Guid("cdc2f2e0-7fb6-41e4-bd96-e719956c0278"));

            migrationBuilder.DeleteData(
                table: "ContactForm",
                keyColumn: "Id",
                keyValue: new Guid("db1d6ed2-4062-41e6-9aed-c85580787061"));

            migrationBuilder.DeleteData(
                table: "IdeaToReleases",
                keyColumn: "Id",
                keyValue: new Guid("f647b130-0540-492f-9860-206cc2f0af5e"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("2393bc28-a45d-42ee-8ec1-e5d5a5ca0a86"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("86a790e4-b144-4c5e-b7b7-cc6090c30fdf"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("0f8eb413-ab14-477c-a521-700f662d08a3"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("345370af-c7e0-4518-91e8-02d308e12f73"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("59e6abb1-6cbf-4123-a3f3-c5299e451f81"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("b81d62cf-28c4-49cb-bda5-83037a0f4899"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("bf255bf4-076f-456b-931e-0717f759189e"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("d94387af-762c-4e12-a968-7ea61b5fe130"));

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: new Guid("5e506350-ec5a-4ea6-bd47-18e3a23cd1a3"));

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: new Guid("65ddc01b-c3a3-425a-a64d-9137881434e4"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("b33bf885-20c9-4b2f-b634-d7c2ef6cddb4"), null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("425928ef-df2f-415f-8a4a-b42b325c47d7"), 0, "6707720a-12ac-4eb7-afaf-f56132fd3c54", "info@kostlanovec.cz", false, false, null, null, "ADMIN", null, null, false, null, false, "admin" });

            migrationBuilder.InsertData(
                table: "BlogCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("48c1f357-fd4c-4c40-91e5-b6036a1a96e9"), "neurčený" },
                    { new Guid("a769b14f-fcac-448c-9a07-1c3787eff180"), "základ" },
                    { new Guid("b79af3ea-3f70-41b8-9b9f-0eefd526d0d1"), "projekty" },
                    { new Guid("fe916dbe-800e-4dcd-8d57-acb621ca1e5c"), "blogpříspěvky" }
                });

            migrationBuilder.InsertData(
                table: "ContactForm",
                columns: new[] { "Id", "Date", "Email", "Message", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("22a676a1-ce54-49f7-be71-ba3ca75b80e4"), new DateTime(2024, 7, 6, 10, 55, 7, 691, DateTimeKind.Local).AddTicks(4621), "jan.novak@example.com", "Dobrý den, rád bych se zeptal na možnost spolupráce.", "123456789" },
                    { new Guid("d560e027-0f46-40e0-8bcf-5c4484119c52"), new DateTime(2024, 7, 6, 10, 55, 7, 691, DateTimeKind.Local).AddTicks(4628), "info@kostlanovec.cz", "Dobrý, mám zájem o nové stránky vámi vyrobené. Těším se, až mi ukážete, co všechno dokážete.", "987654321" }
                });

            migrationBuilder.InsertData(
                table: "IdeaToReleases",
                columns: new[] { "Id", "DatePosted", "Idea" },
                values: new object[] { new Guid("7194e5e4-afbf-41fd-be4b-5f7135cb025c"), new DateTime(2024, 7, 6, 10, 55, 7, 691, DateTimeKind.Local).AddTicks(4657), "Chtěl bych vytvořit nějakou animaci na vytváření koblih" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Description", "FileName" },
                values: new object[,]
                {
                    { new Guid("b40d9bc0-8324-47d8-b032-c150ea7ca59b"), "stín minulosti", "stinminulosti.jpg" },
                    { new Guid("ba857d38-f350-4177-be81-0c4c56345e3a"), "konec světa", "konecsveta.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Content", "Date", "Description", "ImagePath", "Keywords", "Name", "Slug", "Title", "projectStatus" },
                values: new object[,]
                {
                    { new Guid("01d4ce50-1c49-491d-a42e-4fcb04452cce"), "obsah", new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), "Description 4", "/images/tvorbaher.jpg", "Keywords 4", "Project 4", "slug-4", "Title 4", 0 },
                    { new Guid("533f8cd5-5206-45f2-98b8-d65abc165594"), "obsah", new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), "Description 1", "/images/tvorbaher.jpg", "Keywords 1", "Project 1", "slug-1", "Title 1", 0 },
                    { new Guid("55eba25b-9db7-4aaf-8943-6560b0da691a"), "obsah", new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), "Description 2", "/images/tvorbaher.jpg", "Keywords 2", "Project 2", "slug-2", "Title 2", 1 },
                    { new Guid("eafea372-6439-4308-8d9b-9003f269b34b"), "obsah", new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), "Description 6", "/images/tvorbaher.jpg", "Keywords 6", "Project 6", "slug-6", "Title 6", 2 },
                    { new Guid("fa85c0aa-be89-4bcc-8206-c54c309cc7a9"), "obsah", new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), "Description 3", "/images/tvorbaher.jpg", "Keywords 3", "Project 3", "slug-3", "Title 3", 2 },
                    { new Guid("fc3e5cf2-fbde-41c9-95ba-8158f8dc35a6"), "obsah", new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), "Description 5", "/images/tvorbaher.jpg", "Keywords 5", "Project 5", "slug-5", "Title 5", 1 }
                });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "Author", "BlogCategoryId", "Content", "Date", "Description", "ImagePath", "Keywords", "Name", "Slug", "Title" },
                values: new object[,]
                {
                    { new Guid("200dd600-648e-4c0b-8b8b-35193b6c9b66"), "Chleba s marmeládou", new Guid("b79af3ea-3f70-41b8-9b9f-0eefd526d0d1"), "<h1>Projekt</h1>", new DateTime(2024, 7, 6, 10, 55, 7, 691, DateTimeKind.Local).AddTicks(4027), "moje klobasa", "blogimages/boxing.jpg", "Jsi slizký had, nemám tě rád", "deset malych cernousku", "deset-malych-cernousku", "Pět malých kačátek" },
                    { new Guid("931d2ae0-7637-44f2-8c43-ecd77666b81e"), "Pepek Námořník", new Guid("48c1f357-fd4c-4c40-91e5-b6036a1a96e9"), "<h1>Ahoj</h1>", new DateTime(2024, 7, 6, 10, 55, 7, 691, DateTimeKind.Local).AddTicks(3960), "moje klobasa", "blogimages/boxing.jpg", "rohlík, klobása", "Jak mit obri pero", "Jak-mit-obri-pero", "Deset malých švestek" }
                });
        }
    }
}
