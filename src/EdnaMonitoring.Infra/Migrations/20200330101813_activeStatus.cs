using Microsoft.EntityFrameworkCore.Migrations;

namespace EdnaMonitoring.Infra.Migrations
{
    public partial class activeStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TransLines",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Icts",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TransLines");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Icts");
        }
    }
}
