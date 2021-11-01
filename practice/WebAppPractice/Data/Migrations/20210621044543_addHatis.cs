using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppPractice.Data.Migrations
{
    public partial class addHatis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Hatis",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Hatis");
        }
    }
}
