using Microsoft.EntityFrameworkCore.Migrations;

namespace SecureBadge.Migrations
{
    public partial class BadgeTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BadgeTemplate",
                schema: "Badge",
                table: "Assessments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BadgeTemplate",
                schema: "Badge",
                table: "Assessments");
        }
    }
}
