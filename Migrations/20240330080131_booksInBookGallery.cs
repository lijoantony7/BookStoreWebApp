using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreWebApp.Migrations
{
    /// <inheritdoc />
    public partial class booksInBookGallery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookGalleries_Books_BooksId",
                table: "BookGalleries");

            migrationBuilder.AlterColumn<int>(
                name: "BooksId",
                table: "BookGalleries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookGalleries_Books_BooksId",
                table: "BookGalleries",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookGalleries_Books_BooksId",
                table: "BookGalleries");

            migrationBuilder.AlterColumn<int>(
                name: "BooksId",
                table: "BookGalleries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BookGalleries_Books_BooksId",
                table: "BookGalleries",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id");
        }
    }
}
