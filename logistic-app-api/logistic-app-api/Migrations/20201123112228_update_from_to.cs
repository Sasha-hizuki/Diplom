using Microsoft.EntityFrameworkCore.Migrations;

namespace logistic_app_api.Migrations
{
    public partial class update_from_to : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryTasks_Destinations_FromId",
                table: "DeliveryTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryTasks_Destinations_ToId",
                table: "DeliveryTasks");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryTasks_FromId",
                table: "DeliveryTasks");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryTasks_ToId",
                table: "DeliveryTasks");

            migrationBuilder.DropColumn(
                name: "FromId",
                table: "DeliveryTasks");

            migrationBuilder.DropColumn(
                name: "ToId",
                table: "DeliveryTasks");

            migrationBuilder.AddColumn<string>(
                name: "From",
                table: "DeliveryTasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "To",
                table: "DeliveryTasks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                table: "DeliveryTasks");

            migrationBuilder.DropColumn(
                name: "To",
                table: "DeliveryTasks");

            migrationBuilder.AddColumn<int>(
                name: "FromId",
                table: "DeliveryTasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToId",
                table: "DeliveryTasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryTasks_FromId",
                table: "DeliveryTasks",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryTasks_ToId",
                table: "DeliveryTasks",
                column: "ToId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryTasks_Destinations_FromId",
                table: "DeliveryTasks",
                column: "FromId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryTasks_Destinations_ToId",
                table: "DeliveryTasks",
                column: "ToId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
