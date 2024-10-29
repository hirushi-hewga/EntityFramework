using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2024_09_20___HW__Migrations_.Migrations
{
    /// <inheritdoc />
    public partial class InitQuantityRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rating",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rating",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 4,
                column: "Rating",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 5,
                column: "Rating",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 6,
                column: "Rating",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Quantity", "Rating" },
                values: new object[] { 42329, 6 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Quantity", "Rating" },
                values: new object[] { 8976, 8 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Quantity", "Rating" },
                values: new object[] { 19874, 5 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Quantity", "Rating" },
                values: new object[] { 32912, 10 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Quantity", "Rating" },
                values: new object[] { 14565, 9 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Quantity", "Rating" },
                values: new object[] { 45676, 4 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 4,
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 5,
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 6,
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Quantity", "Rating" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Quantity", "Rating" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Quantity", "Rating" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Quantity", "Rating" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Quantity", "Rating" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Quantity", "Rating" },
                values: new object[] { 0, 0 });
        }
    }
}
