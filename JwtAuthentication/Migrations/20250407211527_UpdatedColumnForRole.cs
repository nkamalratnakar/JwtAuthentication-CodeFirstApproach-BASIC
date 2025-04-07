using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JwtAuthentication.Migrations
{
    public partial class UpdatedColumnForRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Logins");
        }
    }
}
