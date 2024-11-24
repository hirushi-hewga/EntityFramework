using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Airline_Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class AddFlights : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightId", "AircraftId", "ArrivalCityId", "FlightDate" },
                values: new object[,]
                {
                    { 3, 1, 1, new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, 2, new DateTime(2024, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, 3, new DateTime(2024, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 2, 4, new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 1, 1, new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 2, 2, new DateTime(2024, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 1, 3, new DateTime(2024, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 2, 4, new DateTime(2024, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 1, 1, new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 2, 2, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 1, 3, new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 2, 4, new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 1, 1, new DateTime(2024, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 2, 2, new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 1, 3, new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 2, 4, new DateTime(2024, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 1, 1, new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 2, 2, new DateTime(2024, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 1, 3, new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 2, 4, new DateTime(2024, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
