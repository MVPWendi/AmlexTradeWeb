using Microsoft.EntityFrameworkCore.Migrations;

namespace AmlexTradeWeb.Migrations
{
    public partial class main3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommandName",
                table: "Commands");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommandName",
                table: "Commands",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
