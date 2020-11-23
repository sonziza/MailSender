using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MailSender.Migrations
{
    public partial class CreatedShedulerTaskmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShedulerTaskId",
                table: "Recipients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShedulerTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServerId = table.Column<int>(type: "int", nullable: true),
                    SenderId = table.Column<int>(type: "int", nullable: true),
                    MessageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShedulerTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShedulerTasks_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShedulerTasks_Senders_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Senders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShedulerTasks_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_ShedulerTaskId",
                table: "Recipients",
                column: "ShedulerTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_ShedulerTasks_MessageId",
                table: "ShedulerTasks",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_ShedulerTasks_SenderId",
                table: "ShedulerTasks",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShedulerTasks_ServerId",
                table: "ShedulerTasks",
                column: "ServerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipients_ShedulerTasks_ShedulerTaskId",
                table: "Recipients",
                column: "ShedulerTaskId",
                principalTable: "ShedulerTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipients_ShedulerTasks_ShedulerTaskId",
                table: "Recipients");

            migrationBuilder.DropTable(
                name: "ShedulerTasks");

            migrationBuilder.DropIndex(
                name: "IX_Recipients_ShedulerTaskId",
                table: "Recipients");

            migrationBuilder.DropColumn(
                name: "ShedulerTaskId",
                table: "Recipients");
        }
    }
}
