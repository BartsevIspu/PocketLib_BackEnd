using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genre", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Passport = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bonuses = table.Column<int>(type: "int", nullable: true),
                    Role = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsApproved = table.Column<sbyte>(type: "tinyint", nullable: false),
                    RefreshToken = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Consistance = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.Id);
                    table.ForeignKey(
                        name: "userFK",
                        column: x => x.GenreId,
                        principalTable: "genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "library",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserRating = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_library", x => x.Id);
                    table.ForeignKey(
                        name: "bookIdx",
                        column: x => x.BookId,
                        principalTable: "book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "userId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.InsertData(
                table: "genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Детектив" },
                    { 2, "Фэнтези" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "Bonuses", "Email", "IsApproved", "Name", "Passport", "Password", "Phone", "RefreshToken", "Role" },
                values: new object[,]
                {
                    { 1, 0, "abc@gmail.com", (sbyte)1, "Александр Барцев Викторович", null, "1U+u9QwJ8SdXuiRip3b83S7jiu06Z0PxlaPHFOJZJ+Q=:tiUz98Ow0IbpP7gWSLBCcA==", "+79038795616", null, "user" },
                    { 2, null, "admin@gmail.com", (sbyte)1, "Администратор", "2415 771077", "8eqn6A6N11WY0k4j8PLlVfcmDvnUQZJOvTtxdBYtINA=:5tZTJitFXi/473n+fWFzog==", "+79106151273", null, "admin" },
                    { 3, null, "worker@gmail.com", (sbyte)1, "Работник", "2416 772076", "ucPtmgnShnsbFBQVZg7kNukEDDluMTr2/fYAq3odDF8=:amw/M3NvUh1kzCQkIJnVIg==", "+79156251375", null, "worker" },
                    { 4, null, "courier@gmail.com", (sbyte)1, "Курьер", "2316 771071", "ucPtmgnShnsbFBQVZg7kNukEDDluMTr2/fYAq3odDF8=:amw/M3NvUh1kzCQkIJnVIg==", "+79176221355", null, "courier" }
                });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "Id", "Consistance", "Description", "GenreId", "Name", "Photo", "Price", "Rating" },
                values: new object[,]
                {
                    { 1, "Содержание 1", "Описание книги 1", 1, "Название книги 1", "https://w7.pngwing.com/pngs/571/549/png-transparent-california-roll-sushi-canape-platter-garnish-hot-roll-thumbnail.png", 770m, 5m },
                    { 2, "Содержание ", "Описание книги 2", 2, "Название книги 2", "https://w7.pngwing.com/pngs/964/36/png-transparent-california-roll-makizushi-sushi-tempura-philadelphia-sushi-rolls-food-recipe-sashimi-thumbnail.png", 990m, 5m },
                    { 3, "Содержание ", "Описание книги 3", 1, "Название книги 3", "https://w7.pngwing.com/pngs/193/635/png-transparent-makizushi-sushi-smoked-salmon-california-roll-pizza-sushi-thumbnail.png", 612m, 5m },
                    { 4, "Содержание ", "Описание книги 4", 2, "Название книги 4", "https://w7.pngwing.com/pngs/571/549/png-transparent-california-roll-sushi-canape-platter-garnish-hot-roll-thumbnail.png", 562m, 5m }
                });

            migrationBuilder.InsertData(
                table: "library",
                columns: new[] { "Id", "BookId", "Pages", "UserId", "UserRating" },
                values: new object[] { 1, 1, 0, 1, 1m });

            migrationBuilder.CreateIndex(
                name: "genre_idx",
                table: "book",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "book_idx",
                table: "library",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "user_idx",
                table: "library",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "library");

            migrationBuilder.DropTable(
                name: "book");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "genre");
        }
    }
}
