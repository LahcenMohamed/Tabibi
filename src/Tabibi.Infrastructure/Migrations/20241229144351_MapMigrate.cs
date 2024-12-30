using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tabibi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MapMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_Note",
                table: "Clinics",
                newName: "Address_UrlOnMap");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_UrlOnMap",
                table: "Clinics",
                newName: "Address_Note");
        }
    }
}
