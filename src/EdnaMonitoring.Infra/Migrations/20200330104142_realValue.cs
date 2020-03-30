using Microsoft.EntityFrameworkCore.Migrations;

namespace EdnaMonitoring.Infra.Migrations
{
    public partial class realValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "RealValue",
                table: "TransLines",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "RealValue",
                table: "Icts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RealValue",
                table: "TransLines");

            migrationBuilder.DropColumn(
                name: "RealValue",
                table: "Icts");
        }
    }
}
