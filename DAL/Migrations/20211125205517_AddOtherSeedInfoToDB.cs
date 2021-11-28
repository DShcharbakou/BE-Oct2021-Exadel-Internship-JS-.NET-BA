using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddOtherSeedInfoToDB : Migration
    {
        private string seedScriptForFillingDB = @"
SET IDENTITY_INSERT Specializations ON;
INSERT INTO Specializations (Id, Name) VALUES
(1, '.Net'),
(2, 'JavaScript'),
(3, 'Business Analyst');
SET IDENTITY_INSERT Specializations OFF;

SET IDENTITY_INSERT EnglishLevel ON;
INSERT INTO EnglishLevel (Id, LevelName) VALUES
(1, 'Elementary'),
(2, 'PreIntermediate'),
(3, 'Intermediate'),
(4, 'UpperIntermediate'),
(5, 'Advanced'),
(6, 'Proficiency');
SET IDENTITY_INSERT EnglishLevel OFF;

SET IDENTITY_INSERT Candidates ON;
INSERT INTO Candidates (Id, FirstName, LastName, Email, Phone, Skype, RegDate, IsArchived,  CityID, EnglishLevelID, SpecializationID) VALUES
(1, 'Jack', 'Sparrow', 'jacksparrow@test.com', '+3751231230', 'jacksparrow', '2021-10-08', 0, 1, 3, 1),
(2, 'Deyneris', 'Targarien', 'deyneristargarien@test.com', '+3570010209', 'deyneristargarien', '2021-09-08', 0, 10, 4, 2),
(3, 'Klark', 'Kent', 'klarkkent@test.com', '80445677631', '123456fghjk', '2021-10-15', 0, 20, 2, 3),
(4, 'Luke', 'Skywolker', 'lukeskywolker@test.com', '+88001005001', 'lukskyoker', '2020-10-23', 1, 30, 5, 1);
SET IDENTITY_INSERT Candidates OFF;

SET IDENTITY_INSERT Sandbox ON;
INSERT INTO Sandbox (Id, StartDate, EndDate) VALUES
(1, '2021-10-08', '2021-12-08'),
(2, '2021-08-08', '2021-10-07'),
(3, '2020-10-08', '2020-12-08');
SET IDENTITY_INSERT Sandbox OFF;

SET IDENTITY_INSERT Employees ON;
INSERT INTO Employees (Id, FirstName, LastName, Email, Phone, Skype) VALUES
(1, 'Kirill', 'Kirillov', 'supermentorKirill@exadel.com', '+375291234567', 'supermentorskype'),
(2, 'Sasha', 'Sashov', 'mentorSasha@exadel.com', '+375291234567', 'mentorskype'),
(3, 'Lesha', 'Leshov', 'managerLesha@exadel.com', '+375291234567', 'managerskype'),
(4, 'Dima', 'Dimov', 'interviewerDima@exadel.com', '+375291234567', 'interviewerskype'),
(5, 'Katya', 'Kotova', 'managerKatya@exadel.com', '+375291234567', 'managerskype'),
(6, 'Lena', 'Lenova', 'supermentorLena@exadel.com', '+375291234567', 'supermentorskype'),
(7, 'Vasya', 'Vasylyev', 'recruiterVasya@exadel.com', '+375291234567', 'recruiterskype'),
(8, 'Admin', 'Admin', 'admin@exadel.com', '+375291234567', 'adminskype'),
(9, 'Petya', 'Petrov', 'recruiterPetya@exadel.com', '+375291234567', 'recruiterskype'),
(10, 'Kostya', 'Kostov', 'interviewerKostya@exadel.com', '+375291234567', 'interviewerskype'),
(11, 'Vadim', 'Vodov', 'mentorVadim@exadel.com', '+375291234567', 'mentorskype');
SET IDENTITY_INSERT Employees OFF;

SET IDENTITY_INSERT Interviews ON;
INSERT INTO Interviews (Id, CandidateID, EmployeeID, Date) VALUES
(1, 1, 7, '2021-10-08'),
(2, 1, 4, '2021-10-09'),
(3, 2, 9, '2021-10-08'),
(4, 2, 10, '2021-10-11'),
(5, 3, 7, '2021-10-10'),
(6, 3, 10, '2021-10-13'),
(7, 4, 9, '2021-10-10'),
(8, 4, 4, '2020-10-12');
SET IDENTITY_INSERT Interviews OFF;

SET IDENTITY_INSERT InternshipTeams ON;
INSERT INTO InternshipTeams (Id, TeamNumber) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4);
SET IDENTITY_INSERT InternshipTeams OFF;

INSERT INTO TeamsMentors (TeamID, EmployeeID) VALUES
(1, 2),
(1, 11),
(2, 2),
(2, 11),
(3, 2),
(3, 11),
(4, 2),
(4, 11);

SET IDENTITY_INSERT Statuses ON;
INSERT INTO Statuses (Id, Name) VALUES
(1, 'Accepted'),
(2, 'Questionable'),
(3, 'Declined');
SET IDENTITY_INSERT Statuses OFF;

SET IDENTITY_INSERT CandidatesSandboxes ON;
INSERT INTO CandidatesSandboxes (Id, CandidateID, SandboxID, StatusID) VALUES
(1, 1, 1, 1),
(2, 3, 1, 1),
(3, 2, 2, 1),
(4, 4, 3, 1);
SET IDENTITY_INSERT CandidatesSandboxes OFF;

INSERT INTO SandboxTeam (TeamID, CandidateSandboxID) VALUES
(1, 1),
(1, 2),
(2, 3),
(3, 4);

SET IDENTITY_INSERT Skills ON;
INSERT INTO Skills (Id, Description, Type) VALUES
(1, 'English', 0),
(2, 'Communicative Skills', 0),
(3, 'Ability to listen', 0),
(4, 'Self-confidence', 0),
(5, '.Net', 1),
(6, 'Javascript', 1),
(7, 'Html', 1),
(8, 'Css', 1),
(9, 'Figma', 1),
(10, 'Angular', 1),
(11, 'React', 1),
(12, 'Sql', 1),
(13, 'Python', 1),
(14, 'Excel', 1);
SET IDENTITY_INSERT Skills OFF;

SET IDENTITY_INSERT Topics ON;
INSERT INTO Topics (Id, Description) VALUES
(1, 'English'),
(2, 'Communicative Skills'),
(3, 'Ability to listen'),
(4, 'Self-confidence'),
(5, 'Syntax'),
(6, 'Solid'),
(7, 'Mysql'),
(8, 'Mssql'),
(9, 'Classes'),
(10, 'Delegates'),
(11, 'Design'),
(12, 'Tags');
SET IDENTITY_INSERT Topics OFF;

INSERT INTO TopicsSkills (TopicID, SkillID) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(5, 6),
(5, 7),
(5, 8),
(5, 9),
(5, 10),
(6, 5),
(6, 6),
(7, 12),
(8, 9),
(9, 11),
(10, 5),
(10, 9),
(11, 5),
(11, 9),
(12, 5),
(12, 7),
(12, 8);

INSERT INTO SkillKnowledges (InterviewID, SkillID, Level, Comment) VALUES
(1, 1, 4, 'norm'),
(1, 2, 3, 'good'),
(1, 3, 2, 'bad'),
(1, 4, 4, 'nice'),
(2, 5, 4, 'norm'),
(2, 12, 4, 'good'),
(3, 1, 3, 'norm'),
(3, 2, 3, 'nice'),
(3, 3, 4, 'excellent'),
(3, 4, 3, 'good'),
(4, 6, 3, 'good'),
(4, 7, 3, 'good'),
(4, 8, 3, 'good'),
(4, 9, 3, 'good'),
(4, 10, 4, 'nice'),
(4, 11, 4, 'nice'),
(5, 1, 4, 'nice'),
(5, 2, 4, 'nice'),
(5, 3, 4, 'good'),
(5, 4, 4, 'nice'),
(6, 13, 4, 'nice'),
(6, 14, 4, 'nice'),
(7, 1, 4, 'nice'),
(7, 2, 4, 'nice'),
(7, 3, 3, 'good'),
(7, 4, 4, 'nice'),
(8, 5, 4, 'norm'),
(8, 12, 4, 'good');

INSERT INTO EmployeesSkills (EmployeeID, SkillID) VALUES
(4, 5),
(4, 12),
(10, 6),
(10, 7),
(10, 8),
(10, 9),
(10, 10),
(10, 11),
(10, 13),
(10, 14),
(7, 1),
(7, 2),
(7, 3),
(7, 4),
(9, 1),
(9, 2),
(9, 3),
(9, 4);";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(seedScriptForFillingDB);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
