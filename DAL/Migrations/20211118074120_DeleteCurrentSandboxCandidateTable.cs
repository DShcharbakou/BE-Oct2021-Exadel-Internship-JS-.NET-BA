using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class DeleteCurrentSandboxCandidateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrentSandboxCandidateDatas");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CandidatesSandboxes");

            migrationBuilder.AddColumn<int>(
                name: "StatusID",
                table: "CandidatesSandboxes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusID",
                table: "CandidatesSandboxes");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CandidatesSandboxes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CurrentSandboxCandidateDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateID = table.Column<int>(type: "int", nullable: false),
                    SandboxID = table.Column<int>(type: "int", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentSandboxCandidateDatas", x => x.Id);
                });
        }
    }
}
