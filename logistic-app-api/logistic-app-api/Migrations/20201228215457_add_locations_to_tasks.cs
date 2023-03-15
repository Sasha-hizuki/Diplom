using Microsoft.EntityFrameworkCore.Migrations;

namespace logistic_app_api.Migrations
{
    public partial class add_locations_to_tasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FromLocation",
                table: "DeliveryTasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToLocation",
                table: "DeliveryTasks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromLocation",
                table: "DeliveryTasks");

            migrationBuilder.DropColumn(
                name: "ToLocation",
                table: "DeliveryTasks");
        }
    }
}
