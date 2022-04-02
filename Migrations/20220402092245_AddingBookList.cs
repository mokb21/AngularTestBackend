using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularTest.Migrations
{
    public partial class AddingBookList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BookListId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "BookList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookList", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookListId",
                table: "Books",
                column: "BookListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookList_BookListId",
                table: "Books",
                column: "BookListId",
                principalTable: "BookList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookList_BookListId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "BookList");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookListId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookListId",
                table: "Books");
        }
    }
}
