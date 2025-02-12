using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashRegister.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Iteration_202502112233 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Payment",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Payment");
        }
    }
}
