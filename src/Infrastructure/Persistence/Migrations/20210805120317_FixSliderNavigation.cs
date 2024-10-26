using Microsoft.EntityFrameworkCore.Migrations;

namespace Ravil.Infrastructure.Data.Migrations
{
    public partial class FixSliderNavigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainSlider_City_CityId",
                schema: "dbo",
                table: "MainSlider");

            migrationBuilder.DropForeignKey(
                name: "FK_MainSlider_State_StateId",
                schema: "dbo",
                table: "MainSlider");

            migrationBuilder.AddForeignKey(
                name: "FK_MainSlider_CityBase_CityId",
                schema: "dbo",
                table: "MainSlider",
                column: "CityId",
                principalSchema: "dbo",
                principalTable: "CityBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MainSlider_StateBase_StateId",
                schema: "dbo",
                table: "MainSlider",
                column: "StateId",
                principalSchema: "dbo",
                principalTable: "StateBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainSlider_CityBase_CityId",
                schema: "dbo",
                table: "MainSlider");

            migrationBuilder.DropForeignKey(
                name: "FK_MainSlider_StateBase_StateId",
                schema: "dbo",
                table: "MainSlider");

            migrationBuilder.AddForeignKey(
                name: "FK_MainSlider_City_CityId",
                schema: "dbo",
                table: "MainSlider",
                column: "CityId",
                principalSchema: "dbo",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MainSlider_State_StateId",
                schema: "dbo",
                table: "MainSlider",
                column: "StateId",
                principalSchema: "dbo",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
