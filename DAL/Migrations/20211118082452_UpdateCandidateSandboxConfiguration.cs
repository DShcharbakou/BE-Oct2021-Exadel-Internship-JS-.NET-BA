using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UpdateCandidateSandboxConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CandidatesSandboxes_StatusID",
                table: "CandidatesSandboxes",
                column: "StatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesSandboxes_Statuses_StatusID",
                table: "CandidatesSandboxes",
                column: "StatusID",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesSandboxes_Statuses_StatusID",
                table: "CandidatesSandboxes");

            migrationBuilder.DropIndex(
                name: "IX_CandidatesSandboxes_StatusID",
                table: "CandidatesSandboxes");
        }
    }
}
