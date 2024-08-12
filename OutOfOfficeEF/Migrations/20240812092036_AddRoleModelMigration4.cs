using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutOfOfficeEF.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleModelMigration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("5a210c86-df4e-48bf-9da8-acec99f142d2"));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "IsActive", "LastName", "OutOfOfficeBalance" },
                values: new object[] { new Guid("527be980-5a1e-4523-8d1e-730e0b8be99e"), "Admin", true, "Admin", 26 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("527be980-5a1e-4523-8d1e-730e0b8be99e"));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "IsActive", "LastName", "OutOfOfficeBalance" },
                values: new object[] { new Guid("5a210c86-df4e-48bf-9da8-acec99f142d2"), "Admin", true, "Admin", 26 });
        }
    }
}
