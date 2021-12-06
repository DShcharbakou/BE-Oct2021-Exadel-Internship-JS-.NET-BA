using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddNewCandidatesToDB : Migration
    {
        private string seedScriptForFillingNewCandidatesToDB = @"
SET IDENTITY_INSERT Candidates ON;
INSERT INTO Candidates (Id, FirstName, LastName, Email, Phone, Skype, RegDate, IsArchived,  CityID, EnglishLevelID, SpecializationID, CountryID) VALUES
(1, 'Jack', 'Sparrow', 'jacksparrow@test.com', '+3751231230', 'jacksparrow', '2021-10-08', 0, 7469, 3, 1, 20),
(2, 'Deyneris', 'Targarien', 'deyneristargarien@test.com', '+3570010209', 'deyneristargarien', '2021-09-08', 0, 7409, 4, 2, 20),
(3, 'Klark', 'Kent', 'klarkkent@test.com', '80445677631', '123456fghjk', '2021-10-15', 0, 7409, 2, 3, 20),
(4, 'Luke', 'Skywolker', 'lukeskywolker@test.com', '+88001005001', 'lukskyoker', '2020-10-23', 1, 7447, 5, 1, 20);
SET IDENTITY_INSERT Candidates OFF;
";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(seedScriptForFillingNewCandidatesToDB);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
