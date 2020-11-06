using Microsoft.EntityFrameworkCore.Migrations;

namespace MemberPortal.Migrations
{
    public partial class client6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "MockDatabases");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "MockDatabases",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
