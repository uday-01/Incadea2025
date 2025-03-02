using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_ERP_System.Migrations
{
    /// <inheritdoc />
    public partial class SalesOrderTableUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrders_Products_ProductsProductId",
                table: "SalesOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrders_Users_UsersUserId",
                table: "SalesOrders");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrders_ProductsProductId",
                table: "SalesOrders");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrders_UsersUserId",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "ProductsProductId",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "UsersUserId",
                table: "SalesOrders");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_ProductId",
                table: "SalesOrders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_UserId",
                table: "SalesOrders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrders_Products_ProductId",
                table: "SalesOrders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrders_Users_UserId",
                table: "SalesOrders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrders_Products_ProductId",
                table: "SalesOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrders_Users_UserId",
                table: "SalesOrders");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrders_ProductId",
                table: "SalesOrders");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrders_UserId",
                table: "SalesOrders");

            migrationBuilder.AddColumn<int>(
                name: "ProductsProductId",
                table: "SalesOrders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsersUserId",
                table: "SalesOrders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_ProductsProductId",
                table: "SalesOrders",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_UsersUserId",
                table: "SalesOrders",
                column: "UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrders_Products_ProductsProductId",
                table: "SalesOrders",
                column: "ProductsProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrders_Users_UsersUserId",
                table: "SalesOrders",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
