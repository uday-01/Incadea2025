using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erpsystemfinal.Migrations
{
    /// <inheritdoc />
    public partial class Suppiers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "SalesOrders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "SalesOrders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_ProductId",
                table: "SalesOrders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrders_Products_ProductId",
                table: "SalesOrders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrders_Products_ProductId",
                table: "SalesOrders");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrders_ProductId",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "SalesOrders");
        }
    }
}
