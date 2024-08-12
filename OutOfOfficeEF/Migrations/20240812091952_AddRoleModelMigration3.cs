using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutOfOfficeEF.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleModelMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("dfe5dc88-8ad5-46be-96e0-1822a30e2094"));

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Employees",
                type: "INTEGER",
                nullable: false,
                defaultValue: 3);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "IsActive", "LastName", "OutOfOfficeBalance" },
                values: new object[] { new Guid("5a210c86-df4e-48bf-9da8-acec99f142d2"), "Admin", true, "Admin", 26 });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleId",
                table: "Employees",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Roles_RoleId",
                table: "Employees",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Roles_RoleId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_RoleId",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("5a210c86-df4e-48bf-9da8-acec99f142d2"));

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "IsActive", "LastName", "OutOfOfficeBalance" },
                values: new object[] { new Guid("dfe5dc88-8ad5-46be-96e0-1822a30e2094"), "Admin", true, "Admin", 26 });
        }
    }
}
