using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreNullBug.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSchema2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Buyer",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Buyer",
                table: "Orders");
        }
    }
}
