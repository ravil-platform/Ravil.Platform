using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddCityStateBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_AspNetUsers_ApplicationUserId",
                schema: "dbo",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_City_CityId",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_City_CityId",
                schema: "dbo",
                table: "UserAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_State_StateId",
                schema: "dbo",
                table: "UserAddress");

            migrationBuilder.DropIndex(
                name: "IX_Address_ApplicationUserId",
                schema: "dbo",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "dbo",
                table: "State");

            migrationBuilder.DropColumn(
                name: "CountyId",
                schema: "dbo",
                table: "City");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "dbo",
                table: "City");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "dbo",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "StateId",
                schema: "dbo",
                table: "UserAddress",
                newName: "StateBaseId");

            migrationBuilder.RenameColumn(
                name: "CityId",
                schema: "dbo",
                table: "UserAddress",
                newName: "CityBaseId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddress_StateId",
                schema: "dbo",
                table: "UserAddress",
                newName: "IX_UserAddress_StateBaseId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddress_CityId",
                schema: "dbo",
                table: "UserAddress",
                newName: "IX_UserAddress_CityBaseId");

            migrationBuilder.RenameColumn(
                name: "StateId",
                schema: "dbo",
                table: "City",
                newName: "CityBaseId");

            migrationBuilder.RenameColumn(
                name: "CityId",
                schema: "dbo",
                table: "AspNetUsers",
                newName: "StateBaseId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_CityId",
                schema: "dbo",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_StateBaseId");

            migrationBuilder.AddColumn<int>(
                name: "StateBaseId",
                schema: "dbo",
                table: "State",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CityBaseId",
                schema: "dbo",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CityBase",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CountyId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityBase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StateBase",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Multiplier = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateBase", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_State_StateBaseId",
                schema: "dbo",
                table: "State",
                column: "StateBaseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_City_CityBaseId",
                schema: "dbo",
                table: "City",
                column: "CityBaseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CityBaseId",
                schema: "dbo",
                table: "AspNetUsers",
                column: "CityBaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CityBase_CityBaseId",
                schema: "dbo",
                table: "AspNetUsers",
                column: "CityBaseId",
                principalSchema: "dbo",
                principalTable: "CityBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_StateBase_StateBaseId",
                schema: "dbo",
                table: "AspNetUsers",
                column: "StateBaseId",
                principalSchema: "dbo",
                principalTable: "StateBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_City_CityBase_CityBaseId",
                schema: "dbo",
                table: "City",
                column: "CityBaseId",
                principalSchema: "dbo",
                principalTable: "CityBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_State_StateBase_StateBaseId",
                schema: "dbo",
                table: "State",
                column: "StateBaseId",
                principalSchema: "dbo",
                principalTable: "StateBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_CityBase_CityBaseId",
                schema: "dbo",
                table: "UserAddress",
                column: "CityBaseId",
                principalSchema: "dbo",
                principalTable: "CityBase",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_StateBase_StateBaseId",
                schema: "dbo",
                table: "UserAddress",
                column: "StateBaseId",
                principalSchema: "dbo",
                principalTable: "StateBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CityBase_CityBaseId",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_StateBase_StateBaseId",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_City_CityBase_CityBaseId",
                schema: "dbo",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_State_StateBase_StateBaseId",
                schema: "dbo",
                table: "State");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_CityBase_CityBaseId",
                schema: "dbo",
                table: "UserAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_StateBase_StateBaseId",
                schema: "dbo",
                table: "UserAddress");

            migrationBuilder.DropTable(
                name: "CityBase",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "StateBase",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_State_StateBaseId",
                schema: "dbo",
                table: "State");

            migrationBuilder.DropIndex(
                name: "IX_City_CityBaseId",
                schema: "dbo",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CityBaseId",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StateBaseId",
                schema: "dbo",
                table: "State");

            migrationBuilder.DropColumn(
                name: "CityBaseId",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "StateBaseId",
                schema: "dbo",
                table: "UserAddress",
                newName: "StateId");

            migrationBuilder.RenameColumn(
                name: "CityBaseId",
                schema: "dbo",
                table: "UserAddress",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddress_StateBaseId",
                schema: "dbo",
                table: "UserAddress",
                newName: "IX_UserAddress_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddress_CityBaseId",
                schema: "dbo",
                table: "UserAddress",
                newName: "IX_UserAddress_CityId");

            migrationBuilder.RenameColumn(
                name: "CityBaseId",
                schema: "dbo",
                table: "City",
                newName: "StateId");

            migrationBuilder.RenameColumn(
                name: "StateBaseId",
                schema: "dbo",
                table: "AspNetUsers",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_StateBaseId",
                schema: "dbo",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_CityId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "State",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CountyId",
                schema: "dbo",
                table: "City",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "City",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "dbo",
                table: "Address",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_ApplicationUserId",
                schema: "dbo",
                table: "Address",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_AspNetUsers_ApplicationUserId",
                schema: "dbo",
                table: "Address",
                column: "ApplicationUserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_City_CityId",
                schema: "dbo",
                table: "AspNetUsers",
                column: "CityId",
                principalSchema: "dbo",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_City_CityId",
                schema: "dbo",
                table: "UserAddress",
                column: "CityId",
                principalSchema: "dbo",
                principalTable: "City",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_State_StateId",
                schema: "dbo",
                table: "UserAddress",
                column: "StateId",
                principalSchema: "dbo",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
