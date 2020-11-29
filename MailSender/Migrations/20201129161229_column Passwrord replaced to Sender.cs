using Microsoft.EntityFrameworkCore.Migrations;

namespace MailSender.Migrations
{
    public partial class columnPasswrordreplacedtoSender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Servers");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Senders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Senders");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Servers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
