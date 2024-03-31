using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreWebApp.Migrations
{
    /// <inheritdoc />
    public partial class booksInBookGalleryChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookGalleries_Books_BooksId",
                table: "BookGalleries");

            migrationBuilder.DropIndex(
                name: "IX_BookGalleries_BooksId",
                table: "BookGalleries");

            migrationBuilder.DropColumn(
                name: "BooksId",
                table: "BookGalleries");

            migrationBuilder.CreateIndex(
                name: "IX_BookGalleries_BookId",
                table: "BookGalleries",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookGalleries_Books_BookId",
                table: "BookGalleries",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookGalleries_Books_BookId",
                table: "BookGalleries");

            migrationBuilder.DropIndex(
                name: "IX_BookGalleries_BookId",
                table: "BookGalleries");

            migrationBuilder.AddColumn<int>(
                name: "BooksId",
                table: "BookGalleries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookGalleries_BooksId",
                table: "BookGalleries",
                column: "BooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookGalleries_Books_BooksId",
                table: "BookGalleries",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
