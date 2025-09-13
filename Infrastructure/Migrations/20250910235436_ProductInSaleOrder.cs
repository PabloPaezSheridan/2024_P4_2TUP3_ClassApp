using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductInSaleOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SaleOrderId",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_SaleOrderId",
                table: "Products",
                column: "SaleOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SaleOrders_SaleOrderId",
                table: "Products",
                column: "SaleOrderId",
                principalTable: "SaleOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_SaleOrders_SaleOrderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SaleOrderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SaleOrderId",
                table: "Products");
        }
    }
}
