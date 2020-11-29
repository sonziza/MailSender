using Microsoft.EntityFrameworkCore.Migrations;

namespace MailSender.Migrations
{
    public partial class removedLogninServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "Servers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Servers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
