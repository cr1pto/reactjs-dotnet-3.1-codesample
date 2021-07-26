using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiSampleReact.Data.Migrater.CarDealershipMigrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    _id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Year = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", maxLength: 150, nullable: false),
                    HasSunroof = table.Column<bool>(type: "bit", nullable: false),
                    IsFourWheelDrive = table.Column<bool>(type: "bit", nullable: false),
                    HasLowMiles = table.Column<bool>(type: "bit", nullable: false),
                    HasPowerWindows = table.Column<bool>(type: "bit", nullable: false),
                    HasNavigation = table.Column<bool>(type: "bit", nullable: false),
                    HasHeatedSeats = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x._id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars__id",
                table: "Cars",
                column: "_id")
                .Annotation("SqlServer:Include", new[] { "Year", "Price", "Make", "IsFourWheelDrive", "HasSunroof", "HasPowerWindows", "HasNavigation", "HasLowMiles", "HasHeatedSeats", "Color" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
