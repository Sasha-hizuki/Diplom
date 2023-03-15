using Microsoft.EntityFrameworkCore.Migrations;

namespace logistic_app_api.Migrations
{
    public partial class finish_model1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BorderCrossings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Border = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorderCrossings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Info = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryTasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<int>(nullable: true),
                    CarId = table.Column<int>(nullable: true),
                    TrailerId = table.Column<int>(nullable: true),
                    FromId = table.Column<int>(nullable: true),
                    ToId = table.Column<int>(nullable: true),
                    Weight = table.Column<double>(nullable: false),
                    ContainerNumber = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>(nullable: true),
                    DeclarantId = table.Column<int>(nullable: true),
                    CustomsId = table.Column<int>(nullable: true),
                    BorderCrossingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryTasks_BorderCrossings_BorderCrossingId",
                        column: x => x.BorderCrossingId,
                        principalTable: "BorderCrossings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryTasks_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryTasks_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryTasks_Customs_CustomsId",
                        column: x => x.CustomsId,
                        principalTable: "Customs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryTasks_Declarants_DeclarantId",
                        column: x => x.DeclarantId,
                        principalTable: "Declarants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryTasks_Users_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryTasks_Destinations_FromId",
                        column: x => x.FromId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryTasks_Destinations_ToId",
                        column: x => x.ToId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryTasks_Trailers_TrailerId",
                        column: x => x.TrailerId,
                        principalTable: "Trailers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryTasks_BorderCrossingId",
                table: "DeliveryTasks",
                column: "BorderCrossingId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryTasks_CarId",
                table: "DeliveryTasks",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryTasks_ClientId",
                table: "DeliveryTasks",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryTasks_CustomsId",
                table: "DeliveryTasks",
                column: "CustomsId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryTasks_DeclarantId",
                table: "DeliveryTasks",
                column: "DeclarantId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryTasks_DriverId",
                table: "DeliveryTasks",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryTasks_FromId",
                table: "DeliveryTasks",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryTasks_ToId",
                table: "DeliveryTasks",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryTasks_TrailerId",
                table: "DeliveryTasks",
                column: "TrailerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryTasks");

            migrationBuilder.DropTable(
                name: "BorderCrossings");

            migrationBuilder.DropTable(
                name: "Customs");

            migrationBuilder.DropTable(
                name: "Destinations");
        }
    }
}
