using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Appointments.Persistence.Migrations
{
    public partial class AddDoctorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    SpecializationName = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false),
                    PhotoUrl = table.Column<string>(type: "text", nullable: false),
                    OfficeName = table.Column<string>(type: "text", nullable: false),
                    OfficeCity = table.Column<string>(type: "text", nullable: false),
                    OfficeRegion = table.Column<string>(type: "text", nullable: false),
                    OfficeStreet = table.Column<string>(type: "text", nullable: false),
                    OfficePostalCode = table.Column<string>(type: "text", nullable: false),
                    OfficeHouseNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Id",
                table: "Doctors",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
