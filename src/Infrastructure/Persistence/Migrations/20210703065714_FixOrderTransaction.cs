using Microsoft.EntityFrameworkCore.Migrations;

namespace Ravil.Infrastructure.Data.Migrations
{
    public partial class FixOrderTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_PromotionCode_PromotionCodeId",
                schema: "dbo",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_PromotionCodeId",
                schema: "dbo",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "PromotionCodeId",
                schema: "dbo",
                table: "Transaction");

            migrationBuilder.AddColumn<double>(
                name: "PaymentAmount",
                schema: "dbo",
                table: "Order",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentPortalId",
                schema: "dbo",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentPortalId",
                schema: "dbo",
                table: "Order",
                column: "PaymentPortalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_PaymentPortal_PaymentPortalId",
                schema: "dbo",
                table: "Order",
                column: "PaymentPortalId",
                principalSchema: "dbo",
                principalTable: "PaymentPortal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_PaymentPortal_PaymentPortalId",
                schema: "dbo",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_PaymentPortalId",
                schema: "dbo",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PaymentAmount",
                schema: "dbo",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PaymentPortalId",
                schema: "dbo",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "PromotionCodeId",
                schema: "dbo",
                table: "Transaction",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_PromotionCodeId",
                schema: "dbo",
                table: "Transaction",
                column: "PromotionCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_PromotionCode_PromotionCodeId",
                schema: "dbo",
                table: "Transaction",
                column: "PromotionCodeId",
                principalSchema: "dbo",
                principalTable: "PromotionCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
