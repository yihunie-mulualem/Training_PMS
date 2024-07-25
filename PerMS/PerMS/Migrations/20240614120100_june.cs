using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerMS.Migrations
{
    /// <inheritdoc />
    public partial class june : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FiscalYears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FiscalYear_Year = table.Column<int>(type: "int", nullable: false),
                    FiscalYear_StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FiscalYear_EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FiscalYear_Closed = table.Column<bool>(type: "bit", nullable: false),
                    FiscalYear_IsCurrentYear = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiscalYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HierarchyGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HierarchyGroup_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HierarchyGroup_Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HierarchyGroup_ReportsTo = table.Column<int>(type: "int", nullable: false),
                    HierarchyGroup_PositionIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HierarchyGroup_Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HierarchyGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobPosition_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobPosition_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobPosition_Grade = table.Column<int>(type: "int", nullable: false),
                    JobPosition_Category = table.Column<int>(type: "int", nullable: false),
                    JobPosition_CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobPosition_DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobPosition_Active = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyPmsWeights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Analytical_skills = table.Column<int>(type: "int", nullable: false),
                    Ability_to_work_Under_pressure_and_Multi_Tasking_skills = table.Column<int>(type: "int", nullable: false),
                    Accuracy_Efficiency_and_Time_Management = table.Column<int>(type: "int", nullable: false),
                    Oral_and_Written_Commuinication_Skills = table.Column<int>(type: "int", nullable: false),
                    Collaboration_and_Team_work = table.Column<int>(type: "int", nullable: false),
                    Dressing_Code_and_Attendance = table.Column<int>(type: "int", nullable: false),
                    Knowledge_of_the_Job_and_Initiative_to_learn = table.Column<int>(type: "int", nullable: false),
                    Confidentiality_Honesty_Integertiy = table.Column<int>(type: "int", nullable: false),
                    Innovation_and_Problem_Solving_Skills = table.Column<int>(type: "int", nullable: false),
                    Attitude_toward_Internal_and_External_customers_Collagues_and_the_Bank = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyPmsWeights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Months",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SequenceNumberOnYear = table.Column<int>(type: "int", nullable: false),
                    NameOfMonth = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Months", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role_CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role_LastModfBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role_LastModfDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role_Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clusters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistrictID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clusters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clusters_Districts_DistrictID",
                        column: x => x.DistrictID,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BussinesUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BussinesUnit_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BussinesUnit_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClusterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BussinesUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BussinesUnits_Clusters_ClusterId",
                        column: x => x.ClusterId,
                        principalTable: "Clusters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department_Code = table.Column<int>(type: "int", nullable: false),
                    Department_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department_CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department_DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Department_Active = table.Column<bool>(type: "bit", nullable: false),
                    BussinesUnitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_BussinesUnits_BussinesUnitId",
                        column: x => x.BussinesUnitId,
                        principalTable: "BussinesUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainID = table.Column<int>(type: "int", nullable: false),
                    Employee_FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employee_Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employee_EmploymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employee_EmployeeStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employee_GradeLevel = table.Column<int>(type: "int", nullable: false),
                    Employee_Remark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employee_CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employee_DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Employee_Active = table.Column<bool>(type: "bit", nullable: false),
                    Employee_ContractExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobPositionId = table.Column<int>(type: "int", nullable: false),
                    BussinesUnitId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    HierarchyGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_BussinesUnits_BussinesUnitId",
                        column: x => x.BussinesUnitId,
                        principalTable: "BussinesUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_HierarchyGroups_HierarchyGroupId",
                        column: x => x.HierarchyGroupId,
                        principalTable: "HierarchyGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_JobPositions_JobPositionId",
                        column: x => x.JobPositionId,
                        principalTable: "JobPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HeadQuarterlyPms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee_Id = table.Column<int>(type: "int", nullable: false),
                    FiscalYear_Id = table.Column<int>(type: "int", nullable: false),
                    Month_Id = table.Column<int>(type: "int", nullable: false),
                    Analytical_skills = table.Column<int>(type: "int", nullable: false),
                    Ability_to_work_Under_pressure_and_Multi_Tasking_skills = table.Column<int>(type: "int", nullable: false),
                    Accuracy_Efficiency_and_Time_Management = table.Column<int>(type: "int", nullable: false),
                    Oral_and_Written_Commuinication_Skills = table.Column<int>(type: "int", nullable: false),
                    Collaboration_and_Team_work = table.Column<int>(type: "int", nullable: false),
                    Dressing_Code_and_Attendance = table.Column<int>(type: "int", nullable: false),
                    Knowledge_of_the_Job_and_Initiative_to_learn = table.Column<int>(type: "int", nullable: false),
                    Confidentiality_Honesty_Integertiy = table.Column<int>(type: "int", nullable: false),
                    Innovation_and_Problem_Solving_Skills = table.Column<int>(type: "int", nullable: false),
                    Attitude_toward_Internal_and_External_customers_Collagues_and_the_Bank = table.Column<int>(type: "int", nullable: false),
                    TotalQuarterly = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Additional_Comment_or_sugesstion_by_Supervisor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employes_Comment_on_Evaluation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_of_Employee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employee_signature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employee_SignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name_of_Supervisor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Supervisor_signature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Supevisor_ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsEmployeeApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsSupervisorApproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadQuarterlyPms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeadQuarterlyPms_Employees_Employee_Id",
                        column: x => x.Employee_Id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeadQuarterlyPms_FiscalYears_FiscalYear_Id",
                        column: x => x.FiscalYear_Id,
                        principalTable: "FiscalYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeadQuarterlyPms_Months_Month_Id",
                        column: x => x.Month_Id,
                        principalTable: "Months",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_EmployeeId = table.Column<int>(type: "int", nullable: false),
                    User_BussinesUnitId = table.Column<int>(type: "int", nullable: false),
                    User_RoleId = table.Column<int>(type: "int", nullable: false),
                    User_CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    User_Active = table.Column<bool>(type: "bit", nullable: false),
                    User_Remark = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_BussinesUnits_User_BussinesUnitId",
                        column: x => x.User_BussinesUnitId,
                        principalTable: "BussinesUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Employees_User_EmployeeId",
                        column: x => x.User_EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_User_RoleId",
                        column: x => x.User_RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee_Approves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    HeadMonthlyPMS_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_Approves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Approves_HeadQuarterlyPms_HeadMonthlyPMS_ID",
                        column: x => x.HeadMonthlyPMS_ID,
                        principalTable: "HeadQuarterlyPms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BussinesUnits_ClusterId",
                table: "BussinesUnits",
                column: "ClusterId");

            migrationBuilder.CreateIndex(
                name: "IX_Clusters_DistrictID",
                table: "Clusters",
                column: "DistrictID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_BussinesUnitId",
                table: "Departments",
                column: "BussinesUnitId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Approves_HeadMonthlyPMS_ID",
                table: "Employee_Approves",
                column: "HeadMonthlyPMS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BussinesUnitId",
                table: "Employees",
                column: "BussinesUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_HierarchyGroupId",
                table: "Employees",
                column: "HierarchyGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobPositionId",
                table: "Employees",
                column: "JobPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadQuarterlyPms_Employee_Id",
                table: "HeadQuarterlyPms",
                column: "Employee_Id");

            migrationBuilder.CreateIndex(
                name: "IX_HeadQuarterlyPms_FiscalYear_Id",
                table: "HeadQuarterlyPms",
                column: "FiscalYear_Id");

            migrationBuilder.CreateIndex(
                name: "IX_HeadQuarterlyPms_Month_Id",
                table: "HeadQuarterlyPms",
                column: "Month_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_User_BussinesUnitId",
                table: "Users",
                column: "User_BussinesUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_User_EmployeeId",
                table: "Users",
                column: "User_EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_User_RoleId",
                table: "Users",
                column: "User_RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee_Approves");

            migrationBuilder.DropTable(
                name: "MonthlyPmsWeights");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "HeadQuarterlyPms");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "FiscalYears");

            migrationBuilder.DropTable(
                name: "Months");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "HierarchyGroups");

            migrationBuilder.DropTable(
                name: "JobPositions");

            migrationBuilder.DropTable(
                name: "BussinesUnits");

            migrationBuilder.DropTable(
                name: "Clusters");

            migrationBuilder.DropTable(
                name: "Districts");
        }
    }
}
