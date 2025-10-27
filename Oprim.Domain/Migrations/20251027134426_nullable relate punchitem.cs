using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oprim.Domain.Migrations
{
    /// <inheritdoc />
    public partial class nullablerelatepunchitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PunchItems_ProjectDepartmentItems_DepartmentItemId",
                table: "PunchItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PunchItems_ProjectItems_ProjectItemId",
                table: "PunchItems");

            migrationBuilder.AlterColumn<long>(
                name: "ProjectItemId",
                table: "PunchItems",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DepartmentItemId",
                table: "PunchItems",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_PunchItems_ProjectDepartmentItems_DepartmentItemId",
                table: "PunchItems",
                column: "DepartmentItemId",
                principalTable: "ProjectDepartmentItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PunchItems_ProjectItems_ProjectItemId",
                table: "PunchItems",
                column: "ProjectItemId",
                principalTable: "ProjectItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PunchItems_ProjectDepartmentItems_DepartmentItemId",
                table: "PunchItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PunchItems_ProjectItems_ProjectItemId",
                table: "PunchItems");

            migrationBuilder.AlterColumn<long>(
                name: "ProjectItemId",
                table: "PunchItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DepartmentItemId",
                table: "PunchItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PunchItems_ProjectDepartmentItems_DepartmentItemId",
                table: "PunchItems",
                column: "DepartmentItemId",
                principalTable: "ProjectDepartmentItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PunchItems_ProjectItems_ProjectItemId",
                table: "PunchItems",
                column: "ProjectItemId",
                principalTable: "ProjectItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
