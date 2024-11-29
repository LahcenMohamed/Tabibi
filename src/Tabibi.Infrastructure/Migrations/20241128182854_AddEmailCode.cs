using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tabibi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailCode",
                table: "AspNetUsers");
        }
    }
}
