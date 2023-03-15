using Microsoft.EntityFrameworkCore.Migrations;

namespace logistic_app_api.Migrations
{
    public partial class user_pos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User_position",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "User_positionId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserPositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPositions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_User_positionId",
                table: "Users",
                column: "User_positionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserPositions_User_positionId",
                table: "Users",
                column: "User_positionId",
                principalTable: "UserPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserPositions_User_positionId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserPositions");

            migrationBuilder.DropIndex(
                name: "IX_Users_User_positionId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "User_positionId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "User_position",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
