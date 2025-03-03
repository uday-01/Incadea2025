using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erpsystemfinal.Migrations
{
    /// <inheritdoc />
    public partial class PurchaseOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "PurchaseOrders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "purchasequantity",
                table: "PurchaseOrders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_ProductId",
                table: "PurchaseOrders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_Products_ProductId",
                table: "PurchaseOrders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_Products_ProductId",
                table: "PurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrders_ProductId",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "purchasequantity",
                table: "PurchaseOrders");
        }
    }
}
