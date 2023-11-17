using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hrwebapi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PayInfo",
                columns: table => new
                {
                    PayInfoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Salary = table.Column<double>(type: "double", nullable: false),
                    HourlyWage = table.Column<double>(type: "double", nullable: false),
                    OvertimeRate = table.Column<double>(type: "double", nullable: false),
                    SickDaysLeft = table.Column<int>(type: "int", nullable: false),
                    VacationDaysLeft = table.Column<double>(type: "double", nullable: false),
                    MaxBreakTime = table.Column<double>(type: "double", nullable: false),
                    DirectDepositAccountNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DirectDepositBranchNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DirectDepositTransitNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayInfo", x => x.PayInfoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmergencyContactName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmergencyContactNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmergencyContactRelationship = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JobTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EmploymentType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PayInfoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkShift = table.Column<double>(type: "double", nullable: false),
                    AttendanceRate = table.Column<double>(type: "double", nullable: false),
                    ManagerEmployeeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_Employee_ManagerEmployeeId",
                        column: x => x.ManagerEmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_PayInfo_PayInfoId",
                        column: x => x.PayInfoId,
                        principalTable: "PayInfo",
                        principalColumn: "PayInfoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DayOff",
                columns: table => new
                {
                    DayOffId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EmployeeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Reason = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Shift = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOff", x => x.DayOffId);
                    table.ForeignKey(
                        name: "FK_DayOff_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EmploymentEvent",
                columns: table => new
                {
                    EmploymentEventId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Event = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmployeeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentEvent", x => x.EmploymentEventId);
                    table.ForeignKey(
                        name: "FK_EmploymentEvent_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Paycheque",
                columns: table => new
                {
                    PaychequeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EmployeeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PayDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PayTotal = table.Column<double>(type: "double", nullable: false),
                    PayStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PayEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paycheque", x => x.PaychequeId);
                    table.ForeignKey(
                        name: "FK_Paycheque_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DeductionDetail",
                columns: table => new
                {
                    DeductionDetailId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DeductionType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalAmount = table.Column<double>(type: "double", nullable: false),
                    PaychequeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeductionDetail", x => x.DeductionDetailId);
                    table.ForeignKey(
                        name: "FK_DeductionDetail_Paycheque_PaychequeId",
                        column: x => x.PaychequeId,
                        principalTable: "Paycheque",
                        principalColumn: "PaychequeId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PayDetail",
                columns: table => new
                {
                    PayDetailId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PayType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rate = table.Column<double>(type: "double", nullable: false),
                    Hours = table.Column<double>(type: "double", nullable: false),
                    PaychequeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayDetail", x => x.PayDetailId);
                    table.ForeignKey(
                        name: "FK_PayDetail_Paycheque_PaychequeId",
                        column: x => x.PaychequeId,
                        principalTable: "Paycheque",
                        principalColumn: "PaychequeId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    ShiftId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EmployeeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ScheduledTimeIn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ScheduledTimeOut = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ActualTimeIn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ActualTimeOut = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    VacationDaysLeft = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BreakTimeIn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BreakTimeOut = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PaychequeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.ShiftId);
                    table.ForeignKey(
                        name: "FK_Shift_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shift_Paycheque_PaychequeId",
                        column: x => x.PaychequeId,
                        principalTable: "Paycheque",
                        principalColumn: "PaychequeId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DayOff_EmployeeId",
                table: "DayOff",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DeductionDetail_PaychequeId",
                table: "DeductionDetail",
                column: "PaychequeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ManagerEmployeeId",
                table: "Employee",
                column: "ManagerEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PayInfoId",
                table: "Employee",
                column: "PayInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentEvent_EmployeeId",
                table: "EmploymentEvent",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayDetail_PaychequeId",
                table: "PayDetail",
                column: "PaychequeId");

            migrationBuilder.CreateIndex(
                name: "IX_Paycheque_EmployeeId",
                table: "Paycheque",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shift_EmployeeId",
                table: "Shift",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shift_PaychequeId",
                table: "Shift",
                column: "PaychequeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayOff");

            migrationBuilder.DropTable(
                name: "DeductionDetail");

            migrationBuilder.DropTable(
                name: "EmploymentEvent");

            migrationBuilder.DropTable(
                name: "PayDetail");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "Paycheque");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "PayInfo");
        }
    }
}
