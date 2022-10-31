using Microsoft.EntityFrameworkCore.Migrations;

namespace IlligalParking.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Complain",
                columns: table => new
                {
                    ComplainID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReporterName = table.Column<string>(nullable: true),
                    CarRegistration = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Violation = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complain", x => x.ComplainID);
                });

            migrationBuilder.CreateTable(
                name: "Parking",
                columns: table => new
                {
                    TypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    UsableTo = table.Column<string>(nullable: true),
                    Restriction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parking", x => x.TypeID);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverName = table.Column<string>(nullable: false),
                    Registration = table.Column<string>(nullable: false),
                    CellNumber = table.Column<string>(nullable: false),
                    IDNumber = table.Column<string>(maxLength: 13, nullable: false),
                    ParkingAssigned = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.UserID);
                });

            migrationBuilder.InsertData(
                table: "Parking",
                columns: new[] { "TypeID", "Name", "Restriction", "UsableTo" },
                values: new object[,]
                {
                    { 1, "Visitor Parking", "May not leave Vehicle overnight", "Anyone" },
                    { 2, "Student Residence Parking", "Car Must be in working order", "Students within that Resisence" },
                    { 3, "Staff Parking", "May not park overnight", "Staff of that faculty" },
                    { 4, "Reserved Parking", "No Restriction", "Marked parking for a certain Individuals" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Complain");

            migrationBuilder.DropTable(
                name: "Parking");

            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
