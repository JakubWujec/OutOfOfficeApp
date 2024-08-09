using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutOfOfficeEF.Migrations
{
    /// <inheritdoc />
    public partial class LeaveRequestStatusMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "LeaveRequests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "LeaveRequests");
        }
    }
}
