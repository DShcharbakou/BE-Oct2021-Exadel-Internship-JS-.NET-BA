using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class FixNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeesStacks");

            migrationBuilder.DropTable(
                name: "InterviewResults");

            migrationBuilder.DropTable(
                name: "TopicsStacks");

            migrationBuilder.DropTable(
                name: "Stacks");

            migrationBuilder.CreateTable(
                name: "SkillKnowledges",
                columns: table => new
                {
                    InterviewID = table.Column<int>(type: "int", nullable: false),
                    TopicID = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillKnowledges", x => new { x.InterviewID, x.TopicID });
                    table.ForeignKey(
                        name: "FK_SkillKnowledges_Interviews_InterviewID",
                        column: x => x.InterviewID,
                        principalTable: "Interviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillKnowledges_Topics_TopicID",
                        column: x => x.TopicID,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesSkills",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    SkillID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesSkills", x => new { x.EmployeeID, x.SkillID });
                    table.ForeignKey(
                        name: "FK_EmployeesSkills_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeesSkills_Skills_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopicsSkills",
                columns: table => new
                {
                    TopicID = table.Column<int>(type: "int", nullable: false),
                    SkillID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicsSkills", x => new { x.SkillID, x.TopicID });
                    table.ForeignKey(
                        name: "FK_TopicsSkills_Skills_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicsSkills_Topics_TopicID",
                        column: x => x.TopicID,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesSkills_SkillID",
                table: "EmployeesSkills",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_SkillKnowledges_TopicID",
                table: "SkillKnowledges",
                column: "TopicID");

            migrationBuilder.CreateIndex(
                name: "IX_TopicsSkills_TopicID",
                table: "TopicsSkills",
                column: "TopicID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeesSkills");

            migrationBuilder.DropTable(
                name: "SkillKnowledges");

            migrationBuilder.DropTable(
                name: "TopicsSkills");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.CreateTable(
                name: "InterviewResults",
                columns: table => new
                {
                    InterviewID = table.Column<int>(type: "int", nullable: false),
                    TopicID = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewResults", x => new { x.InterviewID, x.TopicID });
                    table.ForeignKey(
                        name: "FK_InterviewResults_Interviews_InterviewID",
                        column: x => x.InterviewID,
                        principalTable: "Interviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterviewResults_Topics_TopicID",
                        column: x => x.TopicID,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesStacks",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    StackID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesStacks", x => new { x.EmployeeID, x.StackID });
                    table.ForeignKey(
                        name: "FK_EmployeesStacks_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeesStacks_Stacks_StackID",
                        column: x => x.StackID,
                        principalTable: "Stacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopicsStacks",
                columns: table => new
                {
                    StackID = table.Column<int>(type: "int", nullable: false),
                    TopicID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicsStacks", x => new { x.StackID, x.TopicID });
                    table.ForeignKey(
                        name: "FK_TopicsStacks_Stacks_StackID",
                        column: x => x.StackID,
                        principalTable: "Stacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicsStacks_Topics_TopicID",
                        column: x => x.TopicID,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesStacks_StackID",
                table: "EmployeesStacks",
                column: "StackID");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewResults_TopicID",
                table: "InterviewResults",
                column: "TopicID");

            migrationBuilder.CreateIndex(
                name: "IX_TopicsStacks_TopicID",
                table: "TopicsStacks",
                column: "TopicID");
        }
    }
}
