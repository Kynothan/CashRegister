using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashRegister.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Iteration_202502112144 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_StockMovement_StockMovementId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Tax_TaxId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMovement_Stock_StockId",
                table: "StockMovement");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Product_ProductId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Tax_TaxId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_StockMovement_StockId",
                table: "StockMovement");

            migrationBuilder.DropIndex(
                name: "IX_Product_StockMovementId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "StockMovement");

            migrationBuilder.DropColumn(
                name: "StockMovementId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "TaxId",
                table: "Transaction",
                newName: "IdTax");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Transaction",
                newName: "IdProduct");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_TaxId",
                table: "Transaction",
                newName: "IX_Transaction_IdTax");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_ProductId",
                table: "Transaction",
                newName: "IX_Transaction_IdProduct");

            migrationBuilder.RenameColumn(
                name: "TaxId",
                table: "Product",
                newName: "IdTax");

            migrationBuilder.RenameIndex(
                name: "IX_Product_TaxId",
                table: "Product",
                newName: "IX_Product_IdTax");

            migrationBuilder.AddColumn<int>(
                name: "IdStock",
                table: "StockMovement",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductStockMovement",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "INTEGER", nullable: false),
                    StockMovementsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStockMovement", x => new { x.ProductsId, x.StockMovementsId });
                    table.ForeignKey(
                        name: "FK_ProductStockMovement_Product_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductStockMovement_StockMovement_StockMovementsId",
                        column: x => x.StockMovementsId,
                        principalTable: "StockMovement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockMovement_IdStock",
                table: "StockMovement",
                column: "IdStock");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStockMovement_StockMovementsId",
                table: "ProductStockMovement",
                column: "StockMovementsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Tax_IdTax",
                table: "Product",
                column: "IdTax",
                principalTable: "Tax",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovement_Stock_IdStock",
                table: "StockMovement",
                column: "IdStock",
                principalTable: "Stock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Product_IdProduct",
                table: "Transaction",
                column: "IdProduct",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Tax_IdTax",
                table: "Transaction",
                column: "IdTax",
                principalTable: "Tax",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Tax_IdTax",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMovement_Stock_IdStock",
                table: "StockMovement");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Product_IdProduct",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Tax_IdTax",
                table: "Transaction");

            migrationBuilder.DropTable(
                name: "ProductStockMovement");

            migrationBuilder.DropIndex(
                name: "IX_StockMovement_IdStock",
                table: "StockMovement");

            migrationBuilder.DropColumn(
                name: "IdStock",
                table: "StockMovement");

            migrationBuilder.RenameColumn(
                name: "IdTax",
                table: "Transaction",
                newName: "TaxId");

            migrationBuilder.RenameColumn(
                name: "IdProduct",
                table: "Transaction",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_IdTax",
                table: "Transaction",
                newName: "IX_Transaction_TaxId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_IdProduct",
                table: "Transaction",
                newName: "IX_Transaction_ProductId");

            migrationBuilder.RenameColumn(
                name: "IdTax",
                table: "Product",
                newName: "TaxId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_IdTax",
                table: "Product",
                newName: "IX_Product_TaxId");

            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "StockMovement",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StockMovementId",
                table: "Product",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockMovement_StockId",
                table: "StockMovement",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_StockMovementId",
                table: "Product",
                column: "StockMovementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_StockMovement_StockMovementId",
                table: "Product",
                column: "StockMovementId",
                principalTable: "StockMovement",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Tax_TaxId",
                table: "Product",
                column: "TaxId",
                principalTable: "Tax",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovement_Stock_StockId",
                table: "StockMovement",
                column: "StockId",
                principalTable: "Stock",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Product_ProductId",
                table: "Transaction",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Tax_TaxId",
                table: "Transaction",
                column: "TaxId",
                principalTable: "Tax",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
