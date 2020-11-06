using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MemberPortal.Migrations
{
    public partial class client3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TransactionID",
                table: "MockDatabases",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_MockDatabases",
                table: "MockDatabases",
                column: "TransactionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MockDatabases",
                table: "MockDatabases");

            migrationBuilder.DropColumn(
                name: "TransactionID",
                table: "MockDatabases");
        }
    }
}
