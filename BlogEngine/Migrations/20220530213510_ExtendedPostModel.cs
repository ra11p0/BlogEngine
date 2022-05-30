using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogEngine.Migrations
{
    public partial class ExtendedPostModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Blogs_BlogId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_BlogId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "OwningBlogBlogId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_OwningBlogBlogId",
                table: "Posts",
                column: "OwningBlogBlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Blogs_OwningBlogBlogId",
                table: "Posts",
                column: "OwningBlogBlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Blogs_OwningBlogBlogId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_OwningBlogBlogId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "OwningBlogBlogId",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BlogId",
                table: "Posts",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Blogs_BlogId",
                table: "Posts",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId");
        }
    }
}
