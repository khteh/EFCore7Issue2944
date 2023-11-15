using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreNullBug.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSchema8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Address_HouseType",
                table: "Persons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Address_IsMobile",
                table: "Persons",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_HouseType",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Address_IsMobile",
                table: "Persons");
        }
    }
}
