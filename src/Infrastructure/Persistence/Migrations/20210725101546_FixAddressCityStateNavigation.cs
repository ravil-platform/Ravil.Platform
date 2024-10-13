using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class FixAddressCityStateNavigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_City_CityId",
                schema: "dbo",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_State_StateId",
                schema: "dbo",
                table: "Address");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_CityBase_CityId",
                schema: "dbo",
                table: "Address",
                column: "CityId",
                principalSchema: "dbo",
                principalTable: "CityBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_StateBase_StateId",
                schema: "dbo",
                table: "Address",
                column: "StateId",
                principalSchema: "dbo",
                principalTable: "StateBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_CityBase_CityId",
                schema: "dbo",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_StateBase_StateId",
                schema: "dbo",
                table: "Address");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_City_CityId",
                schema: "dbo",
                table: "Address",
                column: "CityId",
                principalSchema: "dbo",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_State_StateId",
                schema: "dbo",
                table: "Address",
                column: "StateId",
                principalSchema: "dbo",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
