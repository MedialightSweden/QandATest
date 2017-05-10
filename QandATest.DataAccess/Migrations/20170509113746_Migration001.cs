using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QandATest.DataAccess.Migrations
{
    public partial class Migration001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NextQuestionId",
                schema: "dbo",
                table: "Answer",
                newName: "NextQuestion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NextQuestion",
                schema: "dbo",
                table: "Answer",
                newName: "NextQuestionId");
        }
    }
}
