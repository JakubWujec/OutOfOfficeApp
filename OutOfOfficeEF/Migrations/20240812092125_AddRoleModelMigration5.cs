using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutOfOfficeEF.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleModelMigration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("527be980-5a1e-4523-8d1e-730e0b8be99e"));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "IsActive", "LastName", "OutOfOfficeBalance", "RoleId" },
                values: new object[] { new Guid("57151c1a-c8d3-4b48-a044-732d6ccc835d"), "Admin", true, "Admin", 26, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("57151c1a-c8d3-4b48-a044-732d6ccc835d"));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "IsActive", "LastName", "OutOfOfficeBalance" },
                values: new object[] { new Guid("527be980-5a1e-4523-8d1e-730e0b8be99e"), "Admin", true, "Admin", 26 });
        }
    }
}
