using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddSkillKnowledgeInfoToDb : Migration
    {
        private string seedScriptForFillingSkillKnowledgeTable = @"

SET IDENTITY_INSERT Interviews ON;
INSERT INTO Interviews (Id, CandidateID, EmployeeID, Date, Comment) VALUES
(1, 1, 7, '2021-10-08', 'Good'),
(2, 1, 4, '2021-10-09', 'Normal'),
(3, 2, 9, '2021-10-08', 'Very excellent!'),
(4, 2, 10, '2021-10-11', 'Bad, bitch!'),
(5, 3, 7, '2021-10-10', 'Good'),
(6, 3, 10, '2021-10-13', 'Nice'),
(7, 4, 9, '2021-10-10', 'Good'),
(8, 4, 4, '2020-10-12', 'Good');
SET IDENTITY_INSERT Interviews OFF;


INSERT INTO SkillKnowledges (InterviewID, SkillID, Level) VALUES
(1, 1, 4),
(1, 2, 3),
(1, 3, 2),
(1, 4, 4),
(2, 5, 4),
(2, 12, 4),
(3, 1, 3),
(3, 2, 3),
(3, 3, 4),
(3, 4, 3),
(4, 6, 3),
(4, 7, 3),
(4, 8, 3),
(4, 9, 3),
(4, 10, 4),
(4, 11, 4),
(5, 1, 4),
(5, 2, 4),
(5, 3, 4),
(5, 4, 4),
(6, 13, 4),
(6, 14, 4),
(7, 1, 4),
(7, 2, 4),
(7, 3, 3),
(7, 4, 4),
(8, 5, 4),
(8, 12, 4);
";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(seedScriptForFillingSkillKnowledgeTable);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
