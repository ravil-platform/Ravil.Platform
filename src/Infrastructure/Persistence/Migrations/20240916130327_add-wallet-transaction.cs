using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ravil.Infrastructure.Data.Migrations
{
    public partial class addwallettransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Order_OrderId",
                schema: "dbo",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_PaymentPortal_PaymentPortalId",
                schema: "dbo",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_PaymentPortalId",
                schema: "dbo",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "AdminId",
                schema: "dbo",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "AdminName",
                schema: "dbo",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "dbo",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "LastDeleteBicycleDate",
                schema: "dbo",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "LastDeletePermanentDate",
                schema: "dbo",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "Number",
                schema: "dbo",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "PaymentAmount",
                schema: "dbo",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                schema: "dbo",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "PaymentPortalId",
                schema: "dbo",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "RefId",
                schema: "dbo",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "TrackingCode",
                schema: "dbo",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "Transaction");

            migrationBuilder.RenameColumn(
                name: "LastUpdateDate",
                schema: "dbo",
                table: "Transaction",
                newName: "TransactionDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "Transaction",
                newName: "IsPay");

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                schema: "dbo",
                table: "Transaction",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "AuthCode",
                schema: "dbo",
                table: "Transaction",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "dbo",
                table: "Transaction",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                schema: "dbo",
                table: "Transaction",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Transaction",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RefCode",
                schema: "dbo",
                table: "Transaction",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "Transaction",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TransactionNumber",
                schema: "dbo",
                table: "Transaction",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Wallets",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inventory = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastDeleteBicycleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastDeletePermanentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WalletTransactions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WalletId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletTransactions_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalSchema: "dbo",
                        principalTable: "Transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WalletTransactions_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalSchema: "dbo",
                        principalTable: "Wallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_UserId",
                schema: "dbo",
                table: "Wallets",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WalletTransactions_TransactionId",
                schema: "dbo",
                table: "WalletTransactions",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletTransactions_WalletId",
                schema: "dbo",
                table: "WalletTransactions",
                column: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Order_OrderId",
                schema: "dbo",
                table: "Transaction",
                column: "OrderId",
                principalSchema: "dbo",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Order_OrderId",
                schema: "dbo",
                table: "Transaction");

            migrationBuilder.DropTable(
                name: "WalletTransactions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Wallets",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "dbo",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "dbo",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "RefCode",
                schema: "dbo",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "Title",
                schema: "dbo",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "TransactionNumber",
                schema: "dbo",
                table: "Transaction");

            migrationBuilder.RenameColumn(
                name: "TransactionDate",
                schema: "dbo",
                table: "Transaction",
                newName: "LastUpdateDate");

            migrationBuilder.RenameColumn(
                name: "IsPay",
                schema: "dbo",
                table: "Transaction",
                newName: "IsDeleted");

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                schema: "dbo",
                table: "Transaction",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuthCode",
                schema: "dbo",
                table: "Transaction",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "dbo",
                table: "Transaction",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AdminId",
                schema: "dbo",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminName",
                schema: "dbo",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "dbo",
                table: "Transaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeleteBicycleDate",
                schema: "dbo",
                table: "Transaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeletePermanentDate",
                schema: "dbo",
                table: "Transaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Number",
                schema: "dbo",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PaymentAmount",
                schema: "dbo",
                table: "Transaction",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                schema: "dbo",
                table: "Transaction",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentPortalId",
                schema: "dbo",
                table: "Transaction",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefId",
                schema: "dbo",
                table: "Transaction",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrackingCode",
                schema: "dbo",
                table: "Transaction",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "dbo",
                table: "Transaction",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_PaymentPortalId",
                schema: "dbo",
                table: "Transaction",
                column: "PaymentPortalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Order_OrderId",
                schema: "dbo",
                table: "Transaction",
                column: "OrderId",
                principalSchema: "dbo",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_PaymentPortal_PaymentPortalId",
                schema: "dbo",
                table: "Transaction",
                column: "PaymentPortalId",
                principalSchema: "dbo",
                principalTable: "PaymentPortal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
