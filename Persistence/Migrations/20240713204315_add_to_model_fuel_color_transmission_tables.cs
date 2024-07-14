using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_to_model_fuel_color_transmission_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Brands_BrandId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Transmissions_TransmissionId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Fuels_Models_ModelId",
                table: "Fuels");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Transmissions_Models_ModelId",
                table: "Transmissions");

            migrationBuilder.DropTable(
                name: "ColorModel");

            migrationBuilder.DropIndex(
                name: "IX_Transmissions_ModelId",
                table: "Transmissions");

            migrationBuilder.DropIndex(
                name: "IX_Fuels_ModelId",
                table: "Fuels");

            migrationBuilder.DropIndex(
                name: "IX_Cars_TransmissionId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Transmissions");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Fuels");

            migrationBuilder.DropColumn(
                name: "FuelId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "TransmissionId",
                table: "Cars");

            migrationBuilder.AlterColumn<Guid>(
                name: "BrandId",
                table: "Models",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModelId",
                table: "Models",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TransmissionId",
                table: "Models",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "BrandId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Brands_BrandId",
                table: "Cars",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Brands_BrandId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "TransmissionId",
                table: "Models");

            migrationBuilder.AddColumn<Guid>(
                name: "ModelId",
                table: "Transmissions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BrandId",
                table: "Models",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ModelId",
                table: "Fuels",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BrandId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FuelId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TransmissionId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ColorModel",
                columns: table => new
                {
                    ColorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorModel", x => new { x.ColorsId, x.ModelsId });
                    table.ForeignKey(
                        name: "FK_ColorModel_Colors_ColorsId",
                        column: x => x.ColorsId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColorModel_Models_ModelsId",
                        column: x => x.ModelsId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transmissions_ModelId",
                table: "Transmissions",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Fuels_ModelId",
                table: "Fuels",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TransmissionId",
                table: "Cars",
                column: "TransmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorModel_ModelsId",
                table: "ColorModel",
                column: "ModelsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Brands_BrandId",
                table: "Cars",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Transmissions_TransmissionId",
                table: "Cars",
                column: "TransmissionId",
                principalTable: "Transmissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fuels_Models_ModelId",
                table: "Fuels",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transmissions_Models_ModelId",
                table: "Transmissions",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id");
        }
    }
}
