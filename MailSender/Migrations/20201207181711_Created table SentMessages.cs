using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MailSender.Migrations
{
    public partial class CreatedtableSentMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SentMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddresFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssressTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeSent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MessageSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageBody = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SentMessages", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SentMessages");
        }
    }
}
