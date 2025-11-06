using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oprim.Domain.Migrations
{
    /// <inheritdoc />
    public partial class addwork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrganizationRole",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TopLevelRoleId = table.Column<int>(type: "int", nullable: false),
                    ComponentType = table.Column<int>(type: "int", nullable: false),
                    UniquePerson = table.Column<bool>(type: "bit", nullable: false),
                    OrganizationRanking = table.Column<byte>(type: "tinyint", nullable: false),
                    ExternalRole = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationRole_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCalendar",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Saturday = table.Column<bool>(type: "bit", nullable: false),
                    SaturdayTimes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sunday = table.Column<bool>(type: "bit", nullable: false),
                    SundayTimes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Monday = table.Column<bool>(type: "bit", nullable: false),
                    MondayTimes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tuesday = table.Column<bool>(type: "bit", nullable: false),
                    TuesdayTimes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wednesday = table.Column<bool>(type: "bit", nullable: false),
                    WednesdayTimes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thursday = table.Column<bool>(type: "bit", nullable: false),
                    ThursdayTimes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Friday = table.Column<bool>(type: "bit", nullable: false),
                    FridayTimes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCalendar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectCalendar_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StakeholderGroup",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StakeholderGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkTemplates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalendarId = table.Column<long>(type: "bigint", nullable: false),
                    PrefixCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BaseTimeDurationIndex = table.Column<double>(type: "float", nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TextColorCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Penalty = table.Column<long>(type: "bigint", nullable: false),
                    PenaltyApplyType = table.Column<byte>(type: "tinyint", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    ScoreApplyType = table.Column<byte>(type: "tinyint", nullable: false),
                    NoArticle = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkTemplates_ProjectCalendar_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "ProjectCalendar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WorkTemplates_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Stakeholder",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StakeholderGroupId = table.Column<long>(type: "bigint", nullable: false),
                    IsLegalPersonality = table.Column<bool>(type: "bit", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stakeholder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stakeholder_StakeholderGroup_StakeholderGroupId",
                        column: x => x.StakeholderGroupId,
                        principalTable: "StakeholderGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectCalendarId = table.Column<long>(type: "bigint", nullable: false),
                    WorkTemplateId = table.Column<long>(type: "bigint", nullable: false),
                    ScheduleWorkId = table.Column<int>(type: "int", nullable: false),
                    WorkFlowWithDocument = table.Column<bool>(type: "bit", nullable: false),
                    DocumentTypeId = table.Column<long>(type: "bigint", nullable: false),
                    DocumentId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Critical = table.Column<bool>(type: "bit", nullable: false),
                    Important = table.Column<bool>(type: "bit", nullable: false),
                    PlanStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlanFinish = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlanDurationHours = table.Column<int>(type: "int", nullable: false),
                    ActualStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualFinish = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualDurationHours = table.Column<int>(type: "int", nullable: false),
                    Situation = table.Column<byte>(type: "tinyint", nullable: false),
                    Progress = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastArticleId = table.Column<long>(type: "bigint", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Works_ProjectCalendar_ProjectCalendarId",
                        column: x => x.ProjectCalendarId,
                        principalTable: "ProjectCalendar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Works_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Works_WorkTemplates_WorkTemplateId",
                        column: x => x.WorkTemplateId,
                        principalTable: "WorkTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "WorkTemplateArticles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkTemplateId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    StakeholderId = table.Column<long>(type: "bigint", nullable: false),
                    Order = table.Column<byte>(type: "tinyint", nullable: false),
                    FixTime = table.Column<int>(type: "int", nullable: false),
                    FitOnBaseTimeDurationIndex = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ArticleAction = table.Column<byte>(type: "tinyint", nullable: false),
                    SendNotificationOnCreate = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTemplateArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkTemplateArticles_OrganizationRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "OrganizationRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WorkTemplateArticles_Stakeholder_StakeholderId",
                        column: x => x.StakeholderId,
                        principalTable: "Stakeholder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WorkTemplateArticles_WorkTemplates_WorkTemplateId",
                        column: x => x.WorkTemplateId,
                        principalTable: "WorkTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "WorkArticles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrevArticleId = table.Column<long>(type: "bigint", nullable: false),
                    Row = table.Column<int>(type: "int", nullable: false),
                    WorkId = table.Column<long>(type: "bigint", nullable: false),
                    WorkTemplateArticleId = table.Column<long>(type: "bigint", nullable: false),
                    StakeholderId = table.Column<long>(type: "bigint", nullable: false),
                    PlanStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlanFinish = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlanDurationHours = table.Column<int>(type: "int", nullable: false),
                    ActualFinish = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualDurationHours = table.Column<int>(type: "int", nullable: false),
                    DelayHours = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Penalty = table.Column<int>(type: "int", nullable: false),
                    PenaltyOrScoreApplyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QualityValue = table.Column<byte>(type: "tinyint", nullable: false),
                    Situation = table.Column<byte>(type: "tinyint", nullable: false),
                    IsFinalArticle = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkArticles_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WorkArticles_Stakeholder_StakeholderId",
                        column: x => x.StakeholderId,
                        principalTable: "Stakeholder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WorkArticles_WorkTemplateArticles_WorkTemplateArticleId",
                        column: x => x.WorkTemplateArticleId,
                        principalTable: "WorkTemplateArticles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WorkArticles_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationRole_ProjectId",
                table: "OrganizationRole",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCalendar_ProjectId",
                table: "ProjectCalendar",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Stakeholder_StakeholderGroupId",
                table: "Stakeholder",
                column: "StakeholderGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkArticles_ProjectId",
                table: "WorkArticles",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkArticles_StakeholderId",
                table: "WorkArticles",
                column: "StakeholderId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkArticles_WorkId",
                table: "WorkArticles",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkArticles_WorkTemplateArticleId",
                table: "WorkArticles",
                column: "WorkTemplateArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_ProjectCalendarId",
                table: "Works",
                column: "ProjectCalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_ProjectId",
                table: "Works",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_WorkTemplateId",
                table: "Works",
                column: "WorkTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTemplateArticles_RoleId",
                table: "WorkTemplateArticles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTemplateArticles_StakeholderId",
                table: "WorkTemplateArticles",
                column: "StakeholderId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTemplateArticles_WorkTemplateId",
                table: "WorkTemplateArticles",
                column: "WorkTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTemplates_CalendarId",
                table: "WorkTemplates",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTemplates_ProjectId",
                table: "WorkTemplates",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkArticles");

            migrationBuilder.DropTable(
                name: "WorkTemplateArticles");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "OrganizationRole");

            migrationBuilder.DropTable(
                name: "Stakeholder");

            migrationBuilder.DropTable(
                name: "WorkTemplates");

            migrationBuilder.DropTable(
                name: "StakeholderGroup");

            migrationBuilder.DropTable(
                name: "ProjectCalendar");
        }
    }
}
