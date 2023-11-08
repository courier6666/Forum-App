using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumWebApp.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyAddedThreadPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThreadPosts_ForumThreads_ForumThreadId",
                table: "ThreadPosts");

            migrationBuilder.RenameColumn(
                name: "ForumThreadId",
                table: "ThreadPosts",
                newName: "ThreadId");

            migrationBuilder.RenameIndex(
                name: "IX_ThreadPosts_ForumThreadId",
                table: "ThreadPosts",
                newName: "IX_ThreadPosts_ThreadId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThreadPosts_ForumThreads_ThreadId",
                table: "ThreadPosts",
                column: "ThreadId",
                principalTable: "ForumThreads",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThreadPosts_ForumThreads_ThreadId",
                table: "ThreadPosts");

            migrationBuilder.RenameColumn(
                name: "ThreadId",
                table: "ThreadPosts",
                newName: "ForumThreadId");

            migrationBuilder.RenameIndex(
                name: "IX_ThreadPosts_ThreadId",
                table: "ThreadPosts",
                newName: "IX_ThreadPosts_ForumThreadId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThreadPosts_ForumThreads_ForumThreadId",
                table: "ThreadPosts",
                column: "ForumThreadId",
                principalTable: "ForumThreads",
                principalColumn: "Id");
        }
    }
}
