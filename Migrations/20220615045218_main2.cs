using Microsoft.EntityFrameworkCore.Migrations;

namespace AmlexTradeWeb.Migrations
{
    public partial class main2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PluginID",
                table: "Commands");

            migrationBuilder.AddColumn<string>(
                name: "PluginName",
                table: "Commands",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PluginName",
                table: "Commands");

            migrationBuilder.AddColumn<int>(
                name: "PluginID",
                table: "Commands",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
