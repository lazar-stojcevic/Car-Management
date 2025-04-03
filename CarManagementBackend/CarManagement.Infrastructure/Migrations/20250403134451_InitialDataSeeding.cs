using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Color", "IsElectric", "Manufacturer", "ModelName", "Year" },
                values: new object[,]
                {
                    { new Guid("e688880b-fe34-4362-8786-e4464744bf87"), "Red", false, "Toyota", "Corolla", 2020L },
                    { new Guid("e688880b-fe34-4362-8786-e4464744bf88"), "Blue", false, "Honda", "Civic", 2019L },
                    { new Guid("e688880b-fe34-4362-8786-e4464744bf89"), "Black", false, "Ford", "Mustang", 2021L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("e688880b-fe34-4362-8786-e4464744bf87"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("e688880b-fe34-4362-8786-e4464744bf88"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("e688880b-fe34-4362-8786-e4464744bf89"));
        }
    }
}
