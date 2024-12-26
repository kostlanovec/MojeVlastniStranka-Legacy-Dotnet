using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MojeVlastniStranka.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactForm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactForm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdeaToReleases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Idea = table.Column<string>(type: "text", nullable: false),
                    DatePosted = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdeaToReleases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TimePublish = table.Column<DateTime>(type: "timestamp", nullable: false),
                    ShortMessage = table.Column<string>(type: "text", nullable: false),
                    LongMessage = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsLetters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsLetters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TimePublish = table.Column<DateTime>(type: "timestamp", nullable: false),
                    ShortMessage = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Keywords = table.Column<string>(type: "text", nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp", nullable: false),
                    projectStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportedBugs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    Bug = table.Column<string>(type: "text", nullable: false),
                    DatePosted = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportedBugs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MainService = table.Column<int>(type: "integer", nullable: false),
                    SubService = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSubscriptionsNewsLetter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    Hastag = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubscriptionsNewsLetter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Author = table.Column<string>(type: "text", nullable: false),
                    Keywords = table.Column<string>(type: "text", nullable: false),
                    BlogCategoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    ImagePath = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPosts_BlogCategories_BlogCategoryId",
                        column: x => x.BlogCategoryId,
                        principalTable: "BlogCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "300fb496-b9db-4a36-b005-d23d523e56d9", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2a082bcb-8c10-4b60-9bb3-34ebd82cf46e", 0, "8366ae3d-8781-4262-a44d-13b7b5ab718e", "info@kostlanovec.cz", true, false, null, "INFO@KOSTLANOVEC.CZ", "ADMIN", "[REDACTED_HASH]", null, false, "39b181e8-277e-4309-807e-2f3777048d20", false, "admin" });

            migrationBuilder.InsertData(
                table: "BlogCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6a86b114-540d-4d89-a2df-62bb45ec97e7"), "blogpříspěvky" },
                    { new Guid("9a8c5196-fcd5-4d53-98e9-1eedab0991e3"), "základ" },
                    { new Guid("ccca5aa9-9b5f-497f-8a58-ca3845cc5db2"), "projekty" }
                });

            migrationBuilder.InsertData(
                table: "ContactForm",
                columns: new[] { "Id", "Date", "Email", "Message", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("1a9e888a-71f6-492b-8d04-2f112411066b"), new DateTime(2024, 12, 25, 13, 45, 25, 157, DateTimeKind.Local).AddTicks(9055), "jan.novak@example.com", "Dobrý den, rád bych se zeptal na možnost spolupráce.", "123456789" },
                    { new Guid("a538e090-cf8b-48c7-a8b6-d17b151cc691"), new DateTime(2024, 12, 25, 13, 45, 25, 157, DateTimeKind.Local).AddTicks(9075), "info@kostlanovec.cz", "Dobrý, mám zájem o nové stránky vámi vyrobené. Těším se, až mi ukážete, co všechno dokážete.", "987654321" }
                });

            migrationBuilder.InsertData(
                table: "IdeaToReleases",
                columns: new[] { "Id", "DatePosted", "Idea" },
                values: new object[] { new Guid("ccf76533-3654-4ab2-aa67-e453ac5f8bcc"), new DateTime(2024, 12, 25, 13, 45, 25, 157, DateTimeKind.Local).AddTicks(9096), "Chtěl bych vytvořit nějakou animaci na vytváření koblih" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Description", "FileName" },
                values: new object[,]
                {
                    { new Guid("31a86bd3-beb3-4881-8c4d-c2adf1df97fb"), "konec světa", "konecsveta.jpg" },
                    { new Guid("87a1fee6-bb5d-4148-9f03-7d523716344d"), "stín minulosti", "stinminulosti.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Content", "Date", "Description", "ImagePath", "Keywords", "Name", "Slug", "Title", "projectStatus" },
                values: new object[,]
                {
                    { new Guid("2e7166ab-69f5-4269-bb3f-43ae8498d49e"), "<main class=\"main blog--post\"><header><h1>Proč používat unity engine?</h1></header><p>V dnešní době unity engine se tak moc rozvinul i skrz ai, že se to dneš již vyplatí.</p></main>", new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Local), "Description 6", "/images/tvorbaher.jpg", "Keywords 6", "Project 6", "slug-6", "Title 6", 2 },
                    { new Guid("815c776e-1117-44ad-bf1b-08f923143cb1"), "<main class=\"main blog--post\"><header><h1>Proč používat unity engine?</h1></header><p>V dnešní době unity engine se tak moc rozvinul i skrz ai, že se to dneš již vyplatí.</p></main>", new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Local), "Description 1", "/images/tvorbaher.jpg", "Keywords 1", "Project 1", "slug-1", "Title 1", 0 },
                    { new Guid("a80797d0-4e6b-4e23-a927-635797653d89"), "<main class=\"main blog--post\"><header><h1>Proč používat unity engine?</h1></header><p>V dnešní době unity engine se tak moc rozvinul i skrz ai, že se to dneš již vyplatí.</p></main>", new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Local), "Description 4", "/images/tvorbaher.jpg", "Keywords 4", "Project 4", "slug-4", "Title 4", 0 },
                    { new Guid("b6b7e5a2-c10a-4c41-8780-bfffc5b131d2"), "<main class=\"main blog--post\"><header><h1>Proč používat unity engine?</h1></header><p>V dnešní době unity engine se tak moc rozvinul i skrz ai, že se to dneš již vyplatí.</p></main>", new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Local), "Description 5", "/images/tvorbaher.jpg", "Keywords 5", "Project 5", "slug-5", "Title 5", 1 },
                    { new Guid("c9d9a4b5-a33a-47c9-85c0-2f1a68511d25"), "<main class=\"main blog--post\"><header><h1>Proč používat unity engine?</h1></header><p>V dnešní době unity engine se tak moc rozvinul i skrz ai, že se to dneš již vyplatí.</p></main>", new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Local), "Description 3", "/images/tvorbaher.jpg", "Keywords 3", "Project 3", "slug-3", "Title 3", 2 },
                    { new Guid("fd1ac414-e35e-4332-a620-20bcd4036509"), "<main class=\"main blog--post\"><header><h1>Proč používat unity engine?</h1></header><p>V dnešní době unity engine se tak moc rozvinul i skrz ai, že se to dneš již vyplatí.</p></main>", new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Local), "Description 2", "/images/tvorbaher.jpg", "Keywords 2", "Project 2", "slug-2", "Title 2", 1 }
                });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "Author", "BlogCategoryId", "Content", "Date", "Description", "ImagePath", "Keywords", "Name", "Slug", "Title" },
                values: new object[,]
                {
                    { new Guid("7d40d486-280c-4a8d-a9df-630c36dda719"), "Pepek Námořník", new Guid("ccca5aa9-9b5f-497f-8a58-ca3845cc5db2"), "<main class=\"main blog--post\"><header><h1>Proč používat unity engine?</h1></header><p>V dnešní době unity engine se tak moc rozvinul i skrz ai, že se to dneš již vyplatí.</p></main>", new DateTime(2024, 12, 25, 13, 45, 25, 157, DateTimeKind.Local).AddTicks(8954), "moje klobasa", "imaablogimages/boxing.jpg", "rohlík, klobása", "Jak mit obri pero", "Jak-mit-obri-pero", "Deset malých švestek" },
                    { new Guid("c337d257-7f9f-4639-9a9b-e5180e254db7"), "Chleba s marmeládou", new Guid("ccca5aa9-9b5f-497f-8a58-ca3845cc5db2"), "<main class=\"main blog--post\"><header><h1>Proč používat unity engine?</h1></header><p>V dnešní době unity engine se tak moc rozvinul i skrz ai, že se to dneš již vyplatí.</p></main>", new DateTime(2024, 12, 25, 13, 45, 25, 157, DateTimeKind.Local).AddTicks(9001), "moje klobasa", "blogimages/boxing.jpg", "Jsi slizký had, nemám tě rád", "deset malych cernousku", "deset-malych-cernousku", "Pět malých kačátek" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_BlogCategoryId",
                table: "BlogPosts",
                column: "BlogCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "ContactForm");

            migrationBuilder.DropTable(
                name: "IdeaToReleases");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "NewsLetters");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "ReportedBugs");

            migrationBuilder.DropTable(
                name: "ServiceRequests");

            migrationBuilder.DropTable(
                name: "UserSubscriptionsNewsLetter");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BlogCategories");
        }
    }
}
