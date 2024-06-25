using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kolokwium2.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "colors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "models",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_models", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VIN = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    PricePerDay = table.Column<int>(type: "int", nullable: false),
                    ModelID = table.Column<int>(type: "int", nullable: false),
                    ColorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.ID);
                    table.ForeignKey(
                        name: "FK_cars_colors_ColorID",
                        column: x => x.ColorID,
                        principalTable: "colors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cars_models_ModelID",
                        column: x => x.ModelID,
                        principalTable: "models",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "car_rentals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    CarID = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_rentals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_car_rentals_cars_CarID",
                        column: x => x.CarID,
                        principalTable: "cars",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_car_rentals_clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "clients",
                columns: new[] { "ID", "Address", "FirstName", "LastName" },
                values: new object[] { 1, "ul. Wilcza 8c/12", "Adam", "Ryszka" });

            migrationBuilder.InsertData(
                table: "colors",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "Blue" });

            migrationBuilder.InsertData(
                table: "models",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "Model1" });

            migrationBuilder.InsertData(
                table: "cars",
                columns: new[] { "ID", "ColorID", "ModelID", "Name", "PricePerDay", "Seats", "VIN" },
                values: new object[] { 1, 1, 1, "car1", 1000, 2, "aaaa" });

            migrationBuilder.InsertData(
                table: "car_rentals",
                columns: new[] { "ID", "CarID", "ClientID", "DateFrom", "DateTo", "Discount", "TotalPrice" },
                values: new object[] { 1, 1, 1, new DateTime(2024, 6, 25, 12, 35, 34, 868, DateTimeKind.Local).AddTicks(3678), new DateTime(2024, 6, 30, 12, 35, 34, 868, DateTimeKind.Local).AddTicks(3722), 10, 900 });

            migrationBuilder.CreateIndex(
                name: "IX_car_rentals_CarID",
                table: "car_rentals",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_car_rentals_ClientID",
                table: "car_rentals",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_cars_ColorID",
                table: "cars",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_cars_ModelID",
                table: "cars",
                column: "ModelID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "car_rentals");

            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "colors");

            migrationBuilder.DropTable(
                name: "models");
        }
    }
}
