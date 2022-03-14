using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rent_a_car.Migrations
{
    public partial class AddCarsTodb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car_brand",
                columns: table => new
                {
                    car_brand_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    car_brand_name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car_brand", x => x.car_brand_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    user_first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    user_last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EGN = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    user_phone = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    car_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    car_brand_id = table.Column<int>(type: "int", nullable: false),
                    car_year = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    PricaPerDay = table.Column<decimal>(type: "decimal(2,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.car_id);
                    table.ForeignKey(
                        name: "FK_cars_car_brand",
                        column: x => x.car_brand_id,
                        principalTable: "Car_brand",
                        principalColumn: "car_brand_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booked_cars",
                columns: table => new
                {
                    book_car_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    car_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    start_day = table.Column<DateTime>(type: "date", nullable: false),
                    end_day = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_car_id", x => x.book_car_id);
                    table.ForeignKey(
                        name: "FK_booked_cars_cars",
                        column: x => x.car_id,
                        principalTable: "Cars",
                        principalColumn: "car_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cars_users",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booked_cars_car_id",
                table: "Booked_cars",
                column: "car_id");

            migrationBuilder.CreateIndex(
                name: "IX_Booked_cars_user_id",
                table: "Booked_cars",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_car_brand_id",
                table: "Cars",
                column: "car_brand_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__AB6E61647B9AE8EA",
                table: "Users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__C190274629C20443",
                table: "Users",
                column: "EGN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__F3DBC5724EE3AA55",
                table: "Users",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booked_cars");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Car_brand");
        }
    }
}
