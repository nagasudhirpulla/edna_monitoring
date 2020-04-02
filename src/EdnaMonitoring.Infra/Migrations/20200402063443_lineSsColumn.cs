using Microsoft.EntityFrameworkCore.Migrations;

namespace EdnaMonitoring.Infra.Migrations
{
    public partial class lineSsColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Substation",
                table: "TransLines",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransLines_Name_Substation",
                table: "TransLines",
                columns: new[] { "Name", "Substation" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TransLines_Name_Substation",
                table: "TransLines");

            migrationBuilder.DropColumn(
                name: "Substation",
                table: "TransLines");
        }
    }
}
