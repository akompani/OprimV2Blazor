using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oprim.Domain.Migrations
{
    /// <inheritdoc />
    public partial class nullaberole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkTemplateArticles_OrganizationRole_RoleId",
                table: "WorkTemplateArticles");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkTemplateArticles_Stakeholder_StakeholderId",
                table: "WorkTemplateArticles");

            migrationBuilder.AlterColumn<long>(
                name: "StakeholderId",
                table: "WorkTemplateArticles",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "RoleId",
                table: "WorkTemplateArticles",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTemplateArticles_OrganizationRole_RoleId",
                table: "WorkTemplateArticles",
                column: "RoleId",
                principalTable: "OrganizationRole",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTemplateArticles_Stakeholder_StakeholderId",
                table: "WorkTemplateArticles",
                column: "StakeholderId",
                principalTable: "Stakeholder",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkTemplateArticles_OrganizationRole_RoleId",
                table: "WorkTemplateArticles");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkTemplateArticles_Stakeholder_StakeholderId",
                table: "WorkTemplateArticles");

            migrationBuilder.AlterColumn<long>(
                name: "StakeholderId",
                table: "WorkTemplateArticles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "RoleId",
                table: "WorkTemplateArticles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTemplateArticles_OrganizationRole_RoleId",
                table: "WorkTemplateArticles",
                column: "RoleId",
                principalTable: "OrganizationRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTemplateArticles_Stakeholder_StakeholderId",
                table: "WorkTemplateArticles",
                column: "StakeholderId",
                principalTable: "Stakeholder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
