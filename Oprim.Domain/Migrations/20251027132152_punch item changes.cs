using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oprim.Domain.Migrations
{
    /// <inheritdoc />
    public partial class punchitemchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Stakeholder_CreatorId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectCostBreakdowns_Stakeholder_CreatorId",
                table: "ProjectCostBreakdowns");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectDepartmentItems_Stakeholder_CreatorId",
                table: "ProjectDepartmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectDepartments_Stakeholder_CreatorId",
                table: "ProjectDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectItemGroups_Stakeholder_CreatorId",
                table: "ProjectItemGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectItems_Stakeholder_CreatorId",
                table: "ProjectItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PunchItems_Stakeholder_CreatorId",
                table: "PunchItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Stakeholder_StakeholderGroup_StakeholderGroupId",
                table: "Stakeholder");

            migrationBuilder.DropTable(
                name: "StakeholderGroup");

            migrationBuilder.DropTable(
                name: "Stakeholder");

            migrationBuilder.DropIndex(
                name: "IX_PunchItems_CreatorId",
                table: "PunchItems");

            migrationBuilder.DropIndex(
                name: "IX_ProjectItems_CreatorId",
                table: "ProjectItems");

            migrationBuilder.DropIndex(
                name: "IX_ProjectItemGroups_CreatorId",
                table: "ProjectItemGroups");

            migrationBuilder.DropIndex(
                name: "IX_ProjectDepartments_CreatorId",
                table: "ProjectDepartments");

            migrationBuilder.DropIndex(
                name: "IX_ProjectDepartmentItems_CreatorId",
                table: "ProjectDepartmentItems");

            migrationBuilder.DropIndex(
                name: "IX_ProjectCostBreakdowns_CreatorId",
                table: "ProjectCostBreakdowns");

            migrationBuilder.DropIndex(
                name: "IX_Project_CreatorId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "PunchItems");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "ProjectItems");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "ProjectItemGroups");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "ProjectDepartments");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "ProjectDepartmentItems");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "ProjectCostBreakdowns");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Project");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "PunchItems",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreateTime",
                table: "PunchItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<long>(
                name: "CreatorId",
                table: "PunchItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatorId",
                table: "ProjectItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatorId",
                table: "ProjectItemGroups",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatorId",
                table: "ProjectDepartments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatorId",
                table: "ProjectDepartmentItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatorId",
                table: "ProjectCostBreakdowns",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatorId",
                table: "Project",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Stakeholder",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    StakeholderGroupId = table.Column<long>(type: "bigint", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLegalPersonality = table.Column<bool>(type: "bit", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stakeholder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stakeholder_Stakeholder_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Stakeholder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StakeholderGroup",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StakeholderGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StakeholderGroup_Stakeholder_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Stakeholder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PunchItems_CreatorId",
                table: "PunchItems",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItems_CreatorId",
                table: "ProjectItems",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItemGroups_CreatorId",
                table: "ProjectItemGroups",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDepartments_CreatorId",
                table: "ProjectDepartments",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDepartmentItems_CreatorId",
                table: "ProjectDepartmentItems",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCostBreakdowns_CreatorId",
                table: "ProjectCostBreakdowns",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CreatorId",
                table: "Project",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Stakeholder_CreatorId",
                table: "Stakeholder",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Stakeholder_StakeholderGroupId",
                table: "Stakeholder",
                column: "StakeholderGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StakeholderGroup_CreatorId",
                table: "StakeholderGroup",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Stakeholder_CreatorId",
                table: "Project",
                column: "CreatorId",
                principalTable: "Stakeholder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectCostBreakdowns_Stakeholder_CreatorId",
                table: "ProjectCostBreakdowns",
                column: "CreatorId",
                principalTable: "Stakeholder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectDepartmentItems_Stakeholder_CreatorId",
                table: "ProjectDepartmentItems",
                column: "CreatorId",
                principalTable: "Stakeholder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectDepartments_Stakeholder_CreatorId",
                table: "ProjectDepartments",
                column: "CreatorId",
                principalTable: "Stakeholder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectItemGroups_Stakeholder_CreatorId",
                table: "ProjectItemGroups",
                column: "CreatorId",
                principalTable: "Stakeholder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectItems_Stakeholder_CreatorId",
                table: "ProjectItems",
                column: "CreatorId",
                principalTable: "Stakeholder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PunchItems_Stakeholder_CreatorId",
                table: "PunchItems",
                column: "CreatorId",
                principalTable: "Stakeholder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stakeholder_StakeholderGroup_StakeholderGroupId",
                table: "Stakeholder",
                column: "StakeholderGroupId",
                principalTable: "StakeholderGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
