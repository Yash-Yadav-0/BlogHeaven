using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogHeaven.Migrations
{
    /// <inheritdoc />
    public partial class BlogHeavenInitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BloggerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BloggerName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    BloggerDescription = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BloggerId);
                });

            migrationBuilder.CreateTable(
                name: "BlogsByBlogger",
                columns: table => new
                {
                    BlogId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BlogTitle = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    BlogDescription = table.Column<string>(type: "TEXT", nullable: false),
                    BloggerId = table.Column<int>(type: "INTEGER", nullable: false)
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
