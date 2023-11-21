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
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AddressLine1 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressLine2 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Province = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostalCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PayInfos",
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
                    table.PrimaryKey("PK_PayInfos", x => x.PayInfoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ScheduledTimeIn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ScheduledTimeOut = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrentAddressAddressId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Discriminator = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmergencyContactId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Relationship = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmployeeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    EmergencyContactInfoPersonId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    JobTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EmploymentType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PayInfoId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    WorkShift = table.Column<double>(type: "double", nullable: true),
                    AttendanceRate = table.Column<double>(type: "double", nullable: true),
                    ManagerPersonId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_People_Addresses_CurrentAddressAddressId",
                        column: x => x.CurrentAddressAddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "FK_People_PayInfos_PayInfoId",
                        column: x => x.PayInfoId,
                        principalTable: "PayInfos",
                        principalColumn: "PayInfoId");
                    table.ForeignKey(
                        name: "FK_People_People_EmergencyContactInfoPersonId",
                        column: x => x.EmergencyContactInfoPersonId,
                        principalTable: "People",
                        principalColumn: "PersonId");
                    table.ForeignKey(
                        name: "FK_People_People_ManagerPersonId",
                        column: x => x.ManagerPersonId,
                        principalTable: "People",
                        principalColumn: "PersonId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DayOffs",
                columns: table => new
                {
                    DayOffId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Reason = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmployeePersonId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOffs", x => x.DayOffId);
                    table.ForeignKey(
                        name: "FK_DayOffs_People_EmployeePersonId",
                        column: x => x.EmployeePersonId,
                        principalTable: "People",
                        principalColumn: "PersonId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EmployeeSchedule",
                columns: table => new
                {
                    EmployeesPersonId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SchedulesScheduleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSchedule", x => new { x.EmployeesPersonId, x.SchedulesScheduleId });
                    table.ForeignKey(
                        name: "FK_EmployeeSchedule_People_EmployeesPersonId",
                        column: x => x.EmployeesPersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSchedule_Schedules_SchedulesScheduleId",
                        column: x => x.SchedulesScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EmploymentEvents",
                columns: table => new
                {
                    EmploymentEventId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Event = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmployeePersonId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentEvents", x => x.EmploymentEventId);
                    table.ForeignKey(
                        name: "FK_EmploymentEvents_People_EmployeePersonId",
                        column: x => x.EmployeePersonId,
                        principalTable: "People",
                        principalColumn: "PersonId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Paycheques",
                columns: table => new
                {
                    PaychequeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PayDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PayTotal = table.Column<double>(type: "double", nullable: false),
                    PayStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PayEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EmployeePersonId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paycheques", x => x.PaychequeId);
                    table.ForeignKey(
                        name: "FK_Paycheques_People_EmployeePersonId",
                        column: x => x.EmployeePersonId,
                        principalTable: "People",
                        principalColumn: "PersonId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DeductionDetails",
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
                    table.PrimaryKey("PK_DeductionDetails", x => x.DeductionDetailId);
                    table.ForeignKey(
                        name: "FK_DeductionDetails_Paycheques_PaychequeId",
                        column: x => x.PaychequeId,
                        principalTable: "Paycheques",
                        principalColumn: "PaychequeId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PayDetails",
                columns: table => new
                {
                    PayDetailId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PayType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rate = table.Column<double>(type: "double", nullable: false),
                    Hours = table.Column<double>(type: "double", nullable: false),
                    PaychequeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayDetails", x => x.PayDetailId);
                    table.ForeignKey(
                        name: "FK_PayDetails_Paycheques_PaychequeId",
                        column: x => x.PaychequeId,
                        principalTable: "Paycheques",
                        principalColumn: "PaychequeId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    ShiftId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ActualTimeIn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ActualTimeOut = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BreakTimeIn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BreakTimeOut = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EmployeePersonId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    PaychequeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ScheduleId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.ShiftId);
                    table.ForeignKey(
                        name: "FK_Shifts_Paycheques_PaychequeId",
                        column: x => x.PaychequeId,
                        principalTable: "Paycheques",
                        principalColumn: "PaychequeId");
                    table.ForeignKey(
                        name: "FK_Shifts_People_EmployeePersonId",
                        column: x => x.EmployeePersonId,
                        principalTable: "People",
                        principalColumn: "PersonId");
                    table.ForeignKey(
                        name: "FK_Shifts_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "ScheduleId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DayOffs_EmployeePersonId",
                table: "DayOffs",
                column: "EmployeePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_DeductionDetails_PaychequeId",
                table: "DeductionDetails",
                column: "PaychequeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSchedule_SchedulesScheduleId",
                table: "EmployeeSchedule",
                column: "SchedulesScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentEvents_EmployeePersonId",
                table: "EmploymentEvents",
                column: "EmployeePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PayDetails_PaychequeId",
                table: "PayDetails",
                column: "PaychequeId");

            migrationBuilder.CreateIndex(
                name: "IX_Paycheques_EmployeePersonId",
                table: "Paycheques",
                column: "EmployeePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_People_CurrentAddressAddressId",
                table: "People",
                column: "CurrentAddressAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_People_EmergencyContactInfoPersonId",
                table: "People",
                column: "EmergencyContactInfoPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_People_ManagerPersonId",
                table: "People",
                column: "ManagerPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_People_PayInfoId",
                table: "People",
                column: "PayInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_EmployeePersonId",
                table: "Shifts",
                column: "EmployeePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_PaychequeId",
                table: "Shifts",
                column: "PaychequeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_ScheduleId",
                table: "Shifts",
                column: "ScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayOffs");

            migrationBuilder.DropTable(
                name: "DeductionDetails");

            migrationBuilder.DropTable(
                name: "EmployeeSchedule");

            migrationBuilder.DropTable(
                name: "EmploymentEvents");

            migrationBuilder.DropTable(
                name: "PayDetails");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Paycheques");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "PayInfos");
        }
    }
}
