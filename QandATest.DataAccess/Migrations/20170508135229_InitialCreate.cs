using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QandATest.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Advertisement",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdTitle = table.Column<string>(maxLength: 500, nullable: false),
                    CooperationType = table.Column<string>(maxLength: 50, nullable: false),
                    Deadline = table.Column<DateTime>(nullable: false),
                    DutyDesc = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    EmployerAddress = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    EmployerCompany = table.Column<string>(maxLength: 64, nullable: false),
                    EmployerDescription = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    EmployerEmail = table.Column<string>(maxLength: 50, nullable: false),
                    EmployerPhoneNumber = table.Column<string>(maxLength: 50, nullable: false),
                    EmployerWebsite = table.Column<string>(maxLength: 50, nullable: false),
                    JobTitle = table.Column<string>(maxLength: 50, nullable: false),
                    SkillDesc = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnswerType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnswerTypeText = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "QuestionType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QTypeTitle = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Application",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdId = table.Column<int>(nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    UserEmail = table.Column<string>(maxLength: 256, nullable: false),
                    UserId = table.Column<string>(maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Application_Advertisement_AdId",
                        column: x => x.AdId,
                        principalSchema: "dbo",
                        principalTable: "Advertisement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Duty",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdId = table.Column<int>(nullable: false),
                    DutyTitle = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Duty_Advertisement_AdId",
                        column: x => x.AdId,
                        principalSchema: "dbo",
                        principalTable: "Advertisement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdId = table.Column<int>(nullable: false),
                    SkillTitle = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skill_Advertisement_AdId",
                        column: x => x.AdId,
                        principalSchema: "dbo",
                        principalTable: "Advertisement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDependent = table.Column<bool>(nullable: false),
                    QTypeId = table.Column<int>(nullable: false),
                    QuestionTitle = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_QuestionType_QTypeId",
                        column: x => x.QTypeId,
                        principalSchema: "dbo",
                        principalTable: "QuestionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questionnaire",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdId = table.Column<int>(nullable: false),
                    Order = table.Column<short>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionnaire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questionnaire_Advertisement_AdId",
                        column: x => x.AdId,
                        principalSchema: "dbo",
                        principalTable: "Advertisement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questionnaire_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "dbo",
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnswerText = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    AnswerTypeId = table.Column<int>(nullable: false),
                    NextQuestionId = table.Column<int>(nullable: false),
                    QuestionnaireId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answer_AnswerType_AnswerTypeId",
                        column: x => x.AnswerTypeId,
                        principalSchema: "dbo",
                        principalTable: "AnswerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answer_Questionnaire_QuestionnaireId",
                        column: x => x.QuestionnaireId,
                        principalSchema: "dbo",
                        principalTable: "Questionnaire",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_AnswerTypeId",
                schema: "dbo",
                table: "Answer",
                column: "AnswerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionnaireId",
                schema: "dbo",
                table: "Answer",
                column: "QuestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_AdId",
                schema: "dbo",
                table: "Application",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_Duty_AdId",
                schema: "dbo",
                table: "Duty",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_QTypeId",
                schema: "dbo",
                table: "Question",
                column: "QTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Questionnaire_AdId",
                schema: "dbo",
                table: "Questionnaire",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_Questionnaire_QuestionId",
                schema: "dbo",
                table: "Questionnaire",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_AdId",
                schema: "dbo",
                table: "Skill",
                column: "AdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Application",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Duty",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "People",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Skill",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AnswerType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Questionnaire",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Advertisement",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Question",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "QuestionType",
                schema: "dbo");
        }
    }
}
