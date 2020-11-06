using Microsoft.EntityFrameworkCore.Migrations;

namespace MemberPortal.Migrations
{
    public partial class client2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MockDatabases",
                table: "MockDatabases");

            migrationBuilder.DropColumn(
                name: "TransactionID",
                table: "MockDatabases");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionID",
                table: "MockDatabases",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MockDatabases",
                table: "MockDatabases",
                column: "TransactionID");
        }
    }
}
