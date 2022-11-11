using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class v13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnswerQuestionnaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticipantName = table.Column<string>(type: "varchar(100)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<int>(type: "int", nullable: false),
                    QuestionnaireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerQuestionnaire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerQuestionnaire_Questionnaire_QuestionnaireId",
                        column: x => x.QuestionnaireId,
                        principalTable: "Questionnaire",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnswerQuestionnaireDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerId = table.Column<int>(type: "int", nullable: false),
                    AnswerQuestionnaireId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerQuestionnaireDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerQuestionnaireDetail_Answer_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnswerQuestionnaireDetail_AnswerQuestionnaire_AnswerQuestionnaireId",
                        column: x => x.AnswerQuestionnaireId,
                        principalTable: "AnswerQuestionnaire",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerQuestionnaire_QuestionnaireId",
                table: "AnswerQuestionnaire",
                column: "QuestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerQuestionnaireDetail_AnswerId",
                table: "AnswerQuestionnaireDetail",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerQuestionnaireDetail_AnswerQuestionnaireId",
                table: "AnswerQuestionnaireDetail",
                column: "AnswerQuestionnaireId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerQuestionnaireDetail");

            migrationBuilder.DropTable(
                name: "AnswerQuestionnaire");
        }
    }
}
