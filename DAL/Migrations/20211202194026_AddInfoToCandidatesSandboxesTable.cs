using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddInfoToCandidatesSandboxesTable : Migration
    {
        private string seedScriptForFillingDB = @"
        SET IDENTITY_INSERT CandidatesSandboxes ON;
        INSERT INTO CandidatesSandboxes(Id, CandidateID, SandboxID, StatusID, Comment, Grade) VALUES
        (1, 1, 1, 1, 'Good sandbox', 10),
        (2, 3, 1, 1, 'Bad sandbox', 2),
        (3, 2, 2, 1, 'Norm', 5),
        (4, 4, 3, 1, 'Excellent!', 10);
        SET IDENTITY_INSERT CandidatesSandboxes OFF;";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(seedScriptForFillingDB);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
