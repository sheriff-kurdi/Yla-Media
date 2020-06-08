using Microsoft.EntityFrameworkCore.Migrations;

namespace YallaMedia.Data.Migrations
{
    public partial class caption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Caption",
                table: "Blogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Caption",
                table: "Blogs");
        }
    }
}
