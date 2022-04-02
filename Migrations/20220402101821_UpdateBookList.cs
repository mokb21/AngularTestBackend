using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularTest.Migrations
{
    public partial class UpdateBookList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookList_BookListId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookList",
                table: "BookList");

            migrationBuilder.RenameTable(
                name: "BookList",
                newName: "BookLists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookLists",
                table: "BookLists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookLists_BookListId",
                table: "Books",
                column: "BookListId",
                principalTable: "BookLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookLists_BookListId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookLists",
                table: "BookLists");

            migrationBuilder.RenameTable(
                name: "BookLists",
                newName: "BookList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookList",
                table: "BookList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookList_BookListId",
                table: "Books",
                column: "BookListId",
                principalTable: "BookList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
