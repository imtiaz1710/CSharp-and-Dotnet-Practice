using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppPractice.Migrations.ClassRoomDb
{
    public partial class UpdateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Chairs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Chairs");
        }
    }
}
