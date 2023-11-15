using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreNullBug.Migrations
{
    /// <inheritdoc />
    public partial class AddItemId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Item_ItemId",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Item_ItemId",
                table: "Orders");
        }
    }
}
