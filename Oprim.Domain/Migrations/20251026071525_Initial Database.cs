using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oprim.Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationRoles",
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
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationRoles", x => x.Id);
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
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCalendar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCostBreakdowns",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TopLevelId = table.Column<long>(type: "bigint", nullable: false),
                    EstimateCost = table.Column<long>(type: "bigint", nullable: false),
                    TotalCost = table.Column<long>(type: "bigint", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCostBreakdowns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectDepartment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDepartment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectDepartmentItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    Row = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDepartmentItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectDepartmentItem_ProjectDepartment_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "ProjectDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProjectItemGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectItemGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectItemGroupId = table.Column<long>(type: "bigint", nullable: false),
                    ProjectCostBreakdownId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineeringLeadDays = table.Column<int>(type: "int", nullable: false),
                    ProcurementLeadDays = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityForOneHour = table.Column<double>(type: "float", nullable: false),
                    EstimateQuantity = table.Column<double>(type: "float", nullable: false),
                    TotalQuantity = table.Column<double>(type: "float", nullable: false),
                    EstimateUnitCost = table.Column<double>(type: "float", nullable: false),
                    EstimateCost = table.Column<double>(type: "float", nullable: false),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectItems_ProjectCostBreakdowns_ProjectCostBreakdownId",
                        column: x => x.ProjectCostBreakdownId,
                        principalTable: "ProjectCostBreakdowns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProjectItems_ProjectItemGroups_ProjectItemGroupId",
                        column: x => x.ProjectItemGroupId,
                        principalTable: "ProjectItemGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    No = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lock = table.Column<bool>(type: "bit", nullable: false),
                    ContractDurationDays = table.Column<int>(type: "int", nullable: false),
                    ContractContinuousDays = table.Column<int>(type: "int", nullable: false),
                    ContractContinuousDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseAmount = table.Column<long>(type: "bigint", nullable: false),
                    PlanType = table.Column<byte>(type: "tinyint", nullable: false),
                    ConsultantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFehrestic = table.Column<bool>(type: "bit", nullable: false),
                    FehrestYear = table.Column<short>(type: "smallint", nullable: false),
                    Escalation = table.Column<bool>(type: "bit", nullable: false),
                    EscalationBasePeriod = table.Column<int>(type: "int", nullable: false),
                    EscalationDecimal = table.Column<byte>(type: "tinyint", nullable: false),
                    SiteMobilizationFieldCode = table.Column<int>(type: "int", nullable: false),
                    OverheadFactor = table.Column<double>(type: "float", nullable: false),
                    OfferDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OfferFactor = table.Column<double>(type: "float", nullable: false),
                    Apply76574 = table.Column<bool>(type: "bit", nullable: false),
                    ComponentType = table.Column<int>(type: "int", nullable: false),
                    LastUpdateProgress = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PunchItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    DepartmentItemId = table.Column<long>(type: "bigint", nullable: false),
                    ProjectItemId = table.Column<long>(type: "bigint", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpponentLinks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PunchItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PunchItems_ProjectDepartmentItem_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "ProjectDepartmentItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PunchItems_ProjectItems_ProjectItemId",
                        column: x => x.ProjectItemId,
                        principalTable: "ProjectItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PunchItems_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StakeholderGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StakeholderGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stakeholders",
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
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stakeholders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stakeholders_StakeholderGroups_StakeholderGroupId",
                        column: x => x.StakeholderGroupId,
                        principalTable: "StakeholderGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Stakeholders_Stakeholders_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Stakeholders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
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
                        name: "FK_WorkTemplates_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WorkTemplates_Stakeholders_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Stakeholders",
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
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
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
                        name: "FK_Works_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Works_Stakeholders_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Stakeholders",
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
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTemplateArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkTemplateArticles_OrganizationRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "OrganizationRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WorkTemplateArticles_Stakeholders_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Stakeholders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WorkTemplateArticles_Stakeholders_StakeholderId",
                        column: x => x.StakeholderId,
                        principalTable: "Stakeholders",
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
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkArticles_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WorkArticles_Stakeholders_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Stakeholders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WorkArticles_Stakeholders_StakeholderId",
                        column: x => x.StakeholderId,
                        principalTable: "Stakeholders",
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationRoles_CreatorId",
                table: "OrganizationRoles",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationRoles_ProjectId",
                table: "OrganizationRoles",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCalendar_CreatorId",
                table: "ProjectCalendar",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCalendar_ProjectId",
                table: "ProjectCalendar",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCostBreakdowns_CreatorId",
                table: "ProjectCostBreakdowns",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCostBreakdowns_ProjectId",
                table: "ProjectCostBreakdowns",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDepartment_CreatorId",
                table: "ProjectDepartment",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDepartment_ProjectId",
                table: "ProjectDepartment",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDepartmentItem_CreatorId",
                table: "ProjectDepartmentItem",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDepartmentItem_DepartmentId",
                table: "ProjectDepartmentItem",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDepartmentItem_ProjectId",
                table: "ProjectDepartmentItem",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItemGroups_CreatorId",
                table: "ProjectItemGroups",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItemGroups_ProjectId",
                table: "ProjectItemGroups",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItems_CreatorId",
                table: "ProjectItems",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItems_ProjectCostBreakdownId",
                table: "ProjectItems",
                column: "ProjectCostBreakdownId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItems_ProjectId",
                table: "ProjectItems",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItems_ProjectItemGroupId",
                table: "ProjectItems",
                column: "ProjectItemGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CreatorId",
                table: "Projects",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PunchItems_CreatorId",
                table: "PunchItems",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PunchItems_DepartmentId",
                table: "PunchItems",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PunchItems_ProjectId",
                table: "PunchItems",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PunchItems_ProjectItemId",
                table: "PunchItems",
                column: "ProjectItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StakeholderGroups_CreatorId",
                table: "StakeholderGroups",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Stakeholders_CreatorId",
                table: "Stakeholders",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Stakeholders_StakeholderGroupId",
                table: "Stakeholders",
                column: "StakeholderGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkArticles_CreatorId",
                table: "WorkArticles",
                column: "CreatorId");

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
                name: "IX_Works_CreatorId",
                table: "Works",
                column: "CreatorId");

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
                name: "IX_WorkTemplateArticles_CreatorId",
                table: "WorkTemplateArticles",
                column: "CreatorId");

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
                name: "IX_WorkTemplates_CreatorId",
                table: "WorkTemplates",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTemplates_ProjectId",
                table: "WorkTemplates",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationRoles_Projects_ProjectId",
                table: "OrganizationRoles",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationRoles_Stakeholders_CreatorId",
                table: "OrganizationRoles",
                column: "CreatorId",
                principalTable: "Stakeholders",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectCalendar_Projects_ProjectId",
                table: "ProjectCalendar",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectCalendar_Stakeholders_CreatorId",
                table: "ProjectCalendar",
                column: "CreatorId",
                principalTable: "Stakeholders",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectCostBreakdowns_Projects_ProjectId",
                table: "ProjectCostBreakdowns",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectCostBreakdowns_Stakeholders_CreatorId",
                table: "ProjectCostBreakdowns",
                column: "CreatorId",
                principalTable: "Stakeholders",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectDepartment_Projects_ProjectId",
                table: "ProjectDepartment",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectDepartment_Stakeholders_CreatorId",
                table: "ProjectDepartment",
                column: "CreatorId",
                principalTable: "Stakeholders",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectDepartmentItem_Projects_ProjectId",
                table: "ProjectDepartmentItem",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectDepartmentItem_Stakeholders_CreatorId",
                table: "ProjectDepartmentItem",
                column: "CreatorId",
                principalTable: "Stakeholders",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectItemGroups_Projects_ProjectId",
                table: "ProjectItemGroups",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectItemGroups_Stakeholders_CreatorId",
                table: "ProjectItemGroups",
                column: "CreatorId",
                principalTable: "Stakeholders",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectItems_Projects_ProjectId",
                table: "ProjectItems",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectItems_Stakeholders_CreatorId",
                table: "ProjectItems",
                column: "CreatorId",
                principalTable: "Stakeholders",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Stakeholders_CreatorId",
                table: "Projects",
                column: "CreatorId",
                principalTable: "Stakeholders",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PunchItems_Stakeholders_CreatorId",
                table: "PunchItems",
                column: "CreatorId",
                principalTable: "Stakeholders",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_StakeholderGroups_Stakeholders_CreatorId",
                table: "StakeholderGroups",
                column: "CreatorId",
                principalTable: "Stakeholders",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StakeholderGroups_Stakeholders_CreatorId",
                table: "StakeholderGroups");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "PunchItems");

            migrationBuilder.DropTable(
                name: "WorkArticles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ProjectDepartmentItem");

            migrationBuilder.DropTable(
                name: "ProjectItems");

            migrationBuilder.DropTable(
                name: "WorkTemplateArticles");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "ProjectDepartment");

            migrationBuilder.DropTable(
                name: "ProjectCostBreakdowns");

            migrationBuilder.DropTable(
                name: "ProjectItemGroups");

            migrationBuilder.DropTable(
                name: "OrganizationRoles");

            migrationBuilder.DropTable(
                name: "WorkTemplates");

            migrationBuilder.DropTable(
                name: "ProjectCalendar");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Stakeholders");

            migrationBuilder.DropTable(
                name: "StakeholderGroups");
        }
    }
}
