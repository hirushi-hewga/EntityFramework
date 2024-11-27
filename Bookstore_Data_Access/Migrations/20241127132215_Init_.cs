using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bookstore_Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class Init_ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AuthorSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.PublisherId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NumberOfPages = table.Column<int>(type: "int", nullable: false),
                    YearOfRelease = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    ContinuationBook = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "PublisherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName", "AuthorSurname" },
                values: new object[,]
                {
                    { 1, "F. Scott", "Fitzgerald" },
                    { 2, "Michelle", "Obama" },
                    { 3, "Tara", "Westover" },
                    { 4, "George", "Orwell" },
                    { 5, "Harper", "Lee" },
                    { 6, "J.D.", "Salinger" },
                    { 7, "Anne", "Frank" },
                    { 8, "Yuval Noah", "Harari" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "GenreName" },
                values: new object[,]
                {
                    { 1, "Classic Literature" },
                    { 2, "Memoir" },
                    { 3, "Dystopian Fiction" },
                    { 4, "Southern Gothic" },
                    { 5, "Non-Fiction" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublisherId", "PublisherName" },
                values: new object[,]
                {
                    { 1, "Scribner" },
                    { 2, "Crown Publishing Group" },
                    { 3, "Harcourt Brace Jovanovich" },
                    { 4, "Little, Brown and Company" },
                    { 5, "J.B. Lippincott & Co." },
                    { 6, "HarperCollins" },
                    { 7, "Viking Press" },
                    { 8, "Harper" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "BookName", "ContinuationBook", "Cost", "GenreId", "NumberOfPages", "Price", "PublisherId", "YearOfRelease" },
                values: new object[,]
                {
                    { 1, 1, "The Great Gatsby", "-", 10.99f, 1, 180, 15.99f, 1, new DateTime(1925, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, "Tender Is the Night", "The Great Gatsby", 12.99f, 1, 304, 18.99f, 1, new DateTime(1934, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, "Becoming", "-", 15.99f, 2, 400, 22.99f, 2, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 3, "Educated", "-", 16.5f, 2, 334, 24.99f, 2, new DateTime(2018, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 4, "1984", "-", 13.5f, 3, 328, 20f, 3, new DateTime(1949, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 5, "To Kill a Mockingbird", "-", 10.99f, 4, 281, 15.99f, 3, new DateTime(1960, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 6, "The Catcher in the Rye", "-", 11.99f, 1, 214, 17.99f, 4, new DateTime(1951, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 7, "The Diary of a Young Girl", "-", 12.5f, 2, 283, 18.5f, 5, new DateTime(1947, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 8, "Sapiens: A Brief History of Humankind", "-", 18.99f, 5, 443, 27.99f, 6, new DateTime(2011, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
