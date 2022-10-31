using Microsoft.EntityFrameworkCore.Migrations;

namespace IlligalParking.Data.Migrations
{
    public partial class FMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.UpdateData(
                table: "Parking",
                keyColumn: "TypeID",
                keyValue: 2,
                columns: new[] { "Name", "Restriction", "UsableTo" },
                values: new object[] { "Residence students Parking", "Car Must be in working condition.", "Students that resides on campus" });

            migrationBuilder.UpdateData(
                table: "Parking",
                keyColumn: "TypeID",
                keyValue: 3,
                column: "UsableTo",
                value: "Staff of the specific faculty");

            migrationBuilder.UpdateData(
                table: "Parking",
                keyColumn: "TypeID",
                keyValue: 4,
                column: "UsableTo",
                value: "Marked parking for the officials");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "Parking",
                keyColumn: "TypeID",
                keyValue: 2,
                columns: new[] { "Name", "Restriction", "UsableTo" },
                values: new object[] { "Student Residence Parking", "Car Must be in working order", "Students within that Resisence" });

            migrationBuilder.UpdateData(
                table: "Parking",
                keyColumn: "TypeID",
                keyValue: 3,
                column: "UsableTo",
                value: "Staff of that faculty");

            migrationBuilder.UpdateData(
                table: "Parking",
                keyColumn: "TypeID",
                keyValue: 4,
                column: "UsableTo",
                value: "Marked parking for a certain Individuals");
        }
    }
}
