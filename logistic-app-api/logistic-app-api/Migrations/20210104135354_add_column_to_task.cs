using Microsoft.EntityFrameworkCore.Migrations;

namespace logistic_app_api.Migrations
{
    public partial class add_column_to_task : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrentLocation",
                table: "DeliveryTasks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentLocation",
                table: "DeliveryTasks");
        }
    }
}
