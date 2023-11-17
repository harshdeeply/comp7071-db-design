using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hrwebapi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmployeeTableDependencies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Employee_ManagerEmployeeId",
                table: "Employee");

            migrationBuilder.AlterColumn<Guid>(
                name: "ManagerEmployeeId",
                table: "Employee",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Employee_ManagerEmployeeId",
                table: "Employee",
                column: "ManagerEmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Employee_ManagerEmployeeId",
                table: "Employee");

            migrationBuilder.AlterColumn<Guid>(
                name: "ManagerEmployeeId",
                table: "Employee",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Employee_ManagerEmployeeId",
                table: "Employee",
                column: "ManagerEmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
