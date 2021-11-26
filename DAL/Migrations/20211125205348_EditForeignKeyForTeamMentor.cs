using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class EditForeignKeyForTeamMentor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamsMentors_InternshipTeams_EmployeeID",
                table: "TeamsMentors");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsMentors_TeamID",
                table: "TeamsMentors",
                column: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsMentors_InternshipTeams_TeamID",
                table: "TeamsMentors",
                column: "TeamID",
                principalTable: "InternshipTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamsMentors_InternshipTeams_TeamID",
                table: "TeamsMentors");

            migrationBuilder.DropIndex(
                name: "IX_TeamsMentors_TeamID",
                table: "TeamsMentors");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsMentors_InternshipTeams_EmployeeID",
                table: "TeamsMentors",
                column: "EmployeeID",
                principalTable: "InternshipTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
