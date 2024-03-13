using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogHeaven.Migrations
{
    /// <inheritdoc />
    public partial class InitialSql : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BloggerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloggerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BloggerDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BloggerId);
                });

            migrationBuilder.CreateTable(
                name: "BlogsByBlogger",
                columns: table => new
                {
                    BlogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BlogDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloggerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogsByBlogger", x => x.BlogId);
                    table.ForeignKey(
                        name: "FK_BlogsByBlogger_Blogs_BloggerId",
                        column: x => x.BloggerId,
                        principalTable: "Blogs",
                        principalColumn: "BloggerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "BloggerId", "BloggerDescription", "BloggerName" },
                values: new object[,]
                {
                    { 1, "Tech Enthusiast", "Yash Yadav" },
                    { 2, "Travel Explorer", "Dipesh Shah" }
                });

            migrationBuilder.InsertData(
                table: "BlogsByBlogger",
                columns: new[] { "BlogId", "BlogDescription", "BlogTitle", "BloggerId" },
                values: new object[,]
                {
                    { 3, "Nvidia is 2x faster then AMD.", "Nvidia Gpu", 1 },
                    { 4, "Inter is expensive and uses more power.", "Intel Downfall", 1 },
                    { 5, "Discovering the less-explored wonders of Southeast Asia.", "Hidden Gems in Southeast Asia", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogsByBlogger_BloggerId",
                table: "BlogsByBlogger",
                column: "BloggerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogsByBlogger");

            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
