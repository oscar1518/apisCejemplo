using Microsoft.EntityFrameworkCore.Migrations;

namespace apiPrueba.Migrations
{
    public partial class AddColumnToSongs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstaCancion_SeEscuchaMucho",
                table: "songs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstaCancion_SeEscuchaMucho",
                table: "songs");
        }
    }
}
