using Microsoft.EntityFrameworkCore.Migrations;

namespace MemberPortal.Migrations
{
    public partial class client1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MockDatabases",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(nullable: true),
                    PolicyID = table.Column<int>(nullable: true),
                    ClaimID = table.Column<int>(nullable: true),
                    BenefitID = table.Column<int>(nullable: true),
                    HospitalId = table.Column<int>(nullable: true),
                    ClaimAmount = table.Column<double>(nullable: true),
                    BenefitName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MockDatabases", x => x.TransactionID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MockDatabases");
        }
    }
}
