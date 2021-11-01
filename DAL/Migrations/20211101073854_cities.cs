using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class cities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TopicsStacks",
                table: "TopicsStacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterviewResults",
                table: "InterviewResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeesStacks",
                table: "EmployeesStacks");

            migrationBuilder.DropColumn(
                name: "EnglishLevel",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "Specialisation",
                table: "Candidates");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TopicsStacks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TeamsMentors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "InterviewResults",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EmployeesStacks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Candidates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EnglishLevelID",
                table: "Candidates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpecialisationID",
                table: "Candidates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TopicsStacks",
                table: "TopicsStacks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterviewResults",
                table: "InterviewResults",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeesStacks",
                table: "EmployeesStacks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnglishLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnglishLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TopicsStacks_StackID",
                table: "TopicsStacks",
                column: "StackID");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewResults_InterviewID",
                table: "InterviewResults",
                column: "InterviewID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesStacks_EmployeeID",
                table: "EmployeesStacks",
                column: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "EnglishLevel");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TopicsStacks",
                table: "TopicsStacks");

            migrationBuilder.DropIndex(
                name: "IX_TopicsStacks_StackID",
                table: "TopicsStacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterviewResults",
                table: "InterviewResults");

            migrationBuilder.DropIndex(
                name: "IX_InterviewResults_InterviewID",
                table: "InterviewResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeesStacks",
                table: "EmployeesStacks");

            migrationBuilder.DropIndex(
                name: "IX_EmployeesStacks_EmployeeID",
                table: "EmployeesStacks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TopicsStacks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TeamsMentors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "InterviewResults");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EmployeesStacks");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "EnglishLevelID",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "SpecialisationID",
                table: "Candidates");

            migrationBuilder.AddColumn<string>(
                name: "EnglishLevel",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specialisation",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TopicsStacks",
                table: "TopicsStacks",
                columns: new[] { "StackID", "TopicID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterviewResults",
                table: "InterviewResults",
                columns: new[] { "InterviewID", "TopicID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeesStacks",
                table: "EmployeesStacks",
                columns: new[] { "EmployeeID", "StackID" });
        }
    }
}
