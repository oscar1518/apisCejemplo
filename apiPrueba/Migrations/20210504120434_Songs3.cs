using Microsoft.EntityFrameworkCore.Migrations;

namespace apiPrueba.Migrations
{
    public partial class Songs3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Songs",
                newName: "PublishDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublishDate",
                table: "Songs",
                newName: "Duration");
        }
    }
}
