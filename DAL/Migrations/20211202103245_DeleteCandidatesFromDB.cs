using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class DeleteCandidatesFromDB : Migration
    {
        private string seedScriptForDelettingCandidatesFromDB = @"
SET IDENTITY_INSERT Candidates ON;
DELETE From Candidates
SET IDENTITY_INSERT Candidates OFF;
";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(seedScriptForDelettingCandidatesFromDB);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
