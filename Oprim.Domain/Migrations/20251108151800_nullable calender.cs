using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oprim.Domain.Migrations
{
    /// <inheritdoc />
    public partial class nullablecalender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkTemplates_ProjectCalendar_CalendarId",
                table: "WorkTemplates");

            migrationBuilder.AlterColumn<long>(
                name: "CalendarId",
                table: "WorkTemplates",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTemplates_ProjectCalendar_CalendarId",
                table: "WorkTemplates",
                column: "CalendarId",
                principalTable: "ProjectCalendar",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkTemplates_ProjectCalendar_CalendarId",
                table: "WorkTemplates");

            migrationBuilder.AlterColumn<long>(
                name: "CalendarId",
                table: "WorkTemplates",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTemplates_ProjectCalendar_CalendarId",
                table: "WorkTemplates",
                column: "CalendarId",
                principalTable: "ProjectCalendar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
