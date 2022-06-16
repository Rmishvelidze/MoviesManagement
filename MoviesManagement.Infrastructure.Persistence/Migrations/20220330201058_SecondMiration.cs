using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesManagement.Infrastructure.Persistence.Migrations
{
    public partial class SecondMiration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Movies");
        }
    }
}
