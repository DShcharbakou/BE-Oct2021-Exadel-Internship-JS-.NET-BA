using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddSpecializationSandbox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesSandboxes_Candidates_CandidateID",
                table: "CandidatesSandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesSandboxes_Sandbox_SandboxID",
                table: "CandidatesSandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesSandboxes_Statuses_StatusID",
                table: "CandidatesSandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_States_State_Id",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesSkills_Employees_EmployeeID",
                table: "EmployeesSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesSkills_Skills_SkillID",
                table: "EmployeesSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Candidates_CandidateID",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Employees_EmployeeID",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_SandboxTeam_CandidatesSandboxes_CandidateSandboxID",
                table: "SandboxTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_SandboxTeam_InternshipTeams_TeamID",
                table: "SandboxTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillKnowledges_Interviews_InterviewID",
                table: "SkillKnowledges");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillKnowledges_Skills_SkillID",
                table: "SkillKnowledges");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Countries_Country_Id",
                table: "States");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamsMentors_Employees_EmployeeID",
                table: "TeamsMentors");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamsMentors_InternshipTeams_TeamID",
                table: "TeamsMentors");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicsSkills_Skills_SkillID",
                table: "TopicsSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicsSkills_Topics_TopicID",
                table: "TopicsSkills");

            migrationBuilder.CreateTable(
                name: "SpecializationSandbox",
                columns: table => new
                {
                    SandboxID = table.Column<int>(type: "int", nullable: false),
                    SpecializationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecializationSandbox", x => new { x.SandboxID, x.SpecializationID });
                    table.ForeignKey(
                        name: "FK_SpecializationSandbox_Sandbox_SandboxID",
                        column: x => x.SandboxID,
                        principalTable: "Sandbox",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpecializationSandbox_Specializations_SpecializationID",
                        column: x => x.SpecializationID,
                        principalTable: "Specializations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationSandbox_SpecializationID",
                table: "SpecializationSandbox",
                column: "SpecializationID");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesSandboxes_Candidates_CandidateID",
                table: "CandidatesSandboxes",
                column: "CandidateID",
                principalTable: "Candidates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesSandboxes_Sandbox_SandboxID",
                table: "CandidatesSandboxes",
                column: "SandboxID",
                principalTable: "Sandbox",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesSandboxes_Statuses_StatusID",
                table: "CandidatesSandboxes",
                column: "StatusID",
                principalTable: "Statuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_States_State_Id",
                table: "Cities",
                column: "State_Id",
                principalTable: "States",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesSkills_Employees_EmployeeID",
                table: "EmployeesSkills",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesSkills_Skills_SkillID",
                table: "EmployeesSkills",
                column: "SkillID",
                principalTable: "Skills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Candidates_CandidateID",
                table: "Interviews",
                column: "CandidateID",
                principalTable: "Candidates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Employees_EmployeeID",
                table: "Interviews",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SandboxTeam_CandidatesSandboxes_CandidateSandboxID",
                table: "SandboxTeam",
                column: "CandidateSandboxID",
                principalTable: "CandidatesSandboxes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SandboxTeam_InternshipTeams_TeamID",
                table: "SandboxTeam",
                column: "TeamID",
                principalTable: "InternshipTeams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillKnowledges_Interviews_InterviewID",
                table: "SkillKnowledges",
                column: "InterviewID",
                principalTable: "Interviews",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillKnowledges_Skills_SkillID",
                table: "SkillKnowledges",
                column: "SkillID",
                principalTable: "Skills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Countries_Country_Id",
                table: "States",
                column: "Country_Id",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsMentors_Employees_EmployeeID",
                table: "TeamsMentors",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsMentors_InternshipTeams_TeamID",
                table: "TeamsMentors",
                column: "TeamID",
                principalTable: "InternshipTeams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicsSkills_Skills_SkillID",
                table: "TopicsSkills",
                column: "SkillID",
                principalTable: "Skills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicsSkills_Topics_TopicID",
                table: "TopicsSkills",
                column: "TopicID",
                principalTable: "Topics",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesSandboxes_Candidates_CandidateID",
                table: "CandidatesSandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesSandboxes_Sandbox_SandboxID",
                table: "CandidatesSandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesSandboxes_Statuses_StatusID",
                table: "CandidatesSandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_States_State_Id",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesSkills_Employees_EmployeeID",
                table: "EmployeesSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesSkills_Skills_SkillID",
                table: "EmployeesSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Candidates_CandidateID",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Employees_EmployeeID",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_SandboxTeam_CandidatesSandboxes_CandidateSandboxID",
                table: "SandboxTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_SandboxTeam_InternshipTeams_TeamID",
                table: "SandboxTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillKnowledges_Interviews_InterviewID",
                table: "SkillKnowledges");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillKnowledges_Skills_SkillID",
                table: "SkillKnowledges");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Countries_Country_Id",
                table: "States");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamsMentors_Employees_EmployeeID",
                table: "TeamsMentors");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamsMentors_InternshipTeams_TeamID",
                table: "TeamsMentors");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicsSkills_Skills_SkillID",
                table: "TopicsSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicsSkills_Topics_TopicID",
                table: "TopicsSkills");

            migrationBuilder.DropTable(
                name: "SpecializationSandbox");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesSandboxes_Candidates_CandidateID",
                table: "CandidatesSandboxes",
                column: "CandidateID",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesSandboxes_Sandbox_SandboxID",
                table: "CandidatesSandboxes",
                column: "SandboxID",
                principalTable: "Sandbox",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesSandboxes_Statuses_StatusID",
                table: "CandidatesSandboxes",
                column: "StatusID",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_States_State_Id",
                table: "Cities",
                column: "State_Id",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesSkills_Employees_EmployeeID",
                table: "EmployeesSkills",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesSkills_Skills_SkillID",
                table: "EmployeesSkills",
                column: "SkillID",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Candidates_CandidateID",
                table: "Interviews",
                column: "CandidateID",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Employees_EmployeeID",
                table: "Interviews",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SandboxTeam_CandidatesSandboxes_CandidateSandboxID",
                table: "SandboxTeam",
                column: "CandidateSandboxID",
                principalTable: "CandidatesSandboxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SandboxTeam_InternshipTeams_TeamID",
                table: "SandboxTeam",
                column: "TeamID",
                principalTable: "InternshipTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillKnowledges_Interviews_InterviewID",
                table: "SkillKnowledges",
                column: "InterviewID",
                principalTable: "Interviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillKnowledges_Skills_SkillID",
                table: "SkillKnowledges",
                column: "SkillID",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_States_Countries_Country_Id",
                table: "States",
                column: "Country_Id",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsMentors_Employees_EmployeeID",
                table: "TeamsMentors",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsMentors_InternshipTeams_TeamID",
                table: "TeamsMentors",
                column: "TeamID",
                principalTable: "InternshipTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicsSkills_Skills_SkillID",
                table: "TopicsSkills",
                column: "SkillID",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicsSkills_Topics_TopicID",
                table: "TopicsSkills",
                column: "TopicID",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
