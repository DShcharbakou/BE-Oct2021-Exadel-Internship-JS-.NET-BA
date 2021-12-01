using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class RenameTopicIDToSkillIDForSkillKnowledge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillKnowledges_Topics_TopicID",
                table: "SkillKnowledges");

            migrationBuilder.RenameColumn(
                name: "TopicID",
                table: "SkillKnowledges",
                newName: "SkillID");

            migrationBuilder.RenameIndex(
                name: "IX_SkillKnowledges_TopicID",
                table: "SkillKnowledges",
                newName: "IX_SkillKnowledges_SkillID");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillKnowledges_Skills_SkillID",
                table: "SkillKnowledges",
                column: "SkillID",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillKnowledges_Skills_SkillID",
                table: "SkillKnowledges");

            migrationBuilder.RenameColumn(
                name: "SkillID",
                table: "SkillKnowledges",
                newName: "TopicID");

            migrationBuilder.RenameIndex(
                name: "IX_SkillKnowledges_SkillID",
                table: "SkillKnowledges",
                newName: "IX_SkillKnowledges_TopicID");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillKnowledges_Topics_TopicID",
                table: "SkillKnowledges",
                column: "TopicID",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
