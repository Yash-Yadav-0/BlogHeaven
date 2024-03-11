using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogHeaven.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogsByBlogger",
                keyColumn: "BlogId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BlogsByBlogger",
                keyColumn: "BlogId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BlogsByBlogger",
                keyColumn: "BlogId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "BloggerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "BloggerId",
                keyValue: 2);
        }
    }
}
