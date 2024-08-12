using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutOfOfficeEF.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleModelMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("0248c07c-cf9f-40c9-9a25-0a306f1f38df"));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "IsActive", "LastName", "OutOfOfficeBalance" },
                values: new object[] { new Guid("dfe5dc88-8ad5-46be-96e0-1822a30e2094"), "Admin", true, "Admin", 26 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "HR Manager");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Member");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("dfe5dc88-8ad5-46be-96e0-1822a30e2094"));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "IsActive", "LastName", "OutOfOfficeBalance" },
                values: new object[] { new Guid("0248c07c-cf9f-40c9-9a25-0a306f1f38df"), "Admin", true, "Admin", 26 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Manager");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "User");
        }
    }
}
