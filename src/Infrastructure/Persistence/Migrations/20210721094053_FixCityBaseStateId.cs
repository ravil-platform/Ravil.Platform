using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class FixCityBaseStateId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StateBaseId",
                schema: "dbo",
                table: "CityBase",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CityBase_StateBaseId",
                schema: "dbo",
                table: "CityBase",
                column: "StateBaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CityBase_StateBase_StateBaseId",
                schema: "dbo",
                table: "CityBase",
                column: "StateBaseId",
                principalSchema: "dbo",
                principalTable: "StateBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityBase_StateBase_StateBaseId",
                schema: "dbo",
                table: "CityBase");

            migrationBuilder.DropIndex(
                name: "IX_CityBase_StateBaseId",
                schema: "dbo",
                table: "CityBase");

            migrationBuilder.DropColumn(
                name: "StateBaseId",
                schema: "dbo",
                table: "CityBase");
        }
    }
}
