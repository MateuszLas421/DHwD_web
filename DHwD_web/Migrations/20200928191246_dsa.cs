using Microsoft.EntityFrameworkCore.Migrations;

namespace DHwD_web.Migrations
{
    public partial class dsa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "description",
                table: "Games",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Games",
                newName: "description");
        }
    }
}
