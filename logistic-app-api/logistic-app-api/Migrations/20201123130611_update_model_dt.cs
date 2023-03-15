using Microsoft.EntityFrameworkCore.Migrations;

namespace logistic_app_api.Migrations
{
    public partial class update_model_dt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FromContact",
                table: "DeliveryTasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToCompanyBox",
                table: "DeliveryTasks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromContact",
                table: "DeliveryTasks");

            migrationBuilder.DropColumn(
                name: "ToCompanyBox",
                table: "DeliveryTasks");
        }
    }
}
