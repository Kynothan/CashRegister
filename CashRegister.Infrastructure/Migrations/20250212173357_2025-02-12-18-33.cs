using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashRegister.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _202502121833 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Payment_PaymentId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_PaymentId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Transaction");

            migrationBuilder.AddColumn<int>(
                name: "IdPayment",
                table: "Transaction",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_IdPayment",
                table: "Transaction",
                column: "IdPayment");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Payment_IdPayment",
                table: "Transaction",
                column: "IdPayment",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Payment_IdPayment",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_IdPayment",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "IdPayment",
                table: "Transaction");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Transaction",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_PaymentId",
                table: "Transaction",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Payment_PaymentId",
                table: "Transaction",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "Id");
        }
    }
}
