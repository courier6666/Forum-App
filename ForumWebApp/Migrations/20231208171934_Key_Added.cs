﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumWebApp.Migrations
{
    /// <inheritdoc />
    public partial class Key_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ForumThreadUserFollows",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ForumThreadUserFollows");
        }
    }
}
