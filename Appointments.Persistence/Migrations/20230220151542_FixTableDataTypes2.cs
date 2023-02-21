using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appointments.Persistence.Migrations
{
    public partial class FixTableDataTypes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SpecializationName",
                table: "Services",
                type: "character varying(350)",
                maxLength: 350,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 350);

            migrationBuilder.AlterColumn<string>(
                name: "ServiceCategoryName",
                table: "Services",
                type: "character varying(350)",
                maxLength: 350,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 350);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SpecializationName",
                table: "Services",
                type: "integer",
                maxLength: 350,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(350)",
                oldMaxLength: 350);

            migrationBuilder.AlterColumn<int>(
                name: "ServiceCategoryName",
                table: "Services",
                type: "integer",
                maxLength: 350,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(350)",
                oldMaxLength: 350);
        }
    }
}
