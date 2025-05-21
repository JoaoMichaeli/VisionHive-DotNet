using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vision.Hive.Migrations
{
    /// <inheritdoc />
    public partial class AddFilialAndPatioEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motos_Areas_AreaId",
                table: "Motos");

            migrationBuilder.DropForeignKey(
                name: "FK_Motos_Areas_AreaId1",
                table: "Motos");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_Motos_AreaId1",
                table: "Motos");

            migrationBuilder.DropColumn(
                name: "AreaId1",
                table: "Motos");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "Motos",
                newName: "PatioId");

            migrationBuilder.RenameIndex(
                name: "IX_Motos_AreaId",
                table: "Motos",
                newName: "IX_Motos_PatioId");

            migrationBuilder.CreateTable(
                name: "Filiais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Bairro = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Cnpj = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    LimiteMotos = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FilialId = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patios_Filiais_FilialId",
                        column: x => x.FilialId,
                        principalTable: "Filiais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patios_FilialId",
                table: "Patios",
                column: "FilialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Motos_Patios_PatioId",
                table: "Motos",
                column: "PatioId",
                principalTable: "Patios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motos_Patios_PatioId",
                table: "Motos");

            migrationBuilder.DropTable(
                name: "Patios");

            migrationBuilder.DropTable(
                name: "Filiais");

            migrationBuilder.RenameColumn(
                name: "PatioId",
                table: "Motos",
                newName: "AreaId");

            migrationBuilder.RenameIndex(
                name: "IX_Motos_PatioId",
                table: "Motos",
                newName: "IX_Motos_AreaId");

            migrationBuilder.AddColumn<Guid>(
                name: "AreaId1",
                table: "Motos",
                type: "RAW(16)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motos_AreaId1",
                table: "Motos",
                column: "AreaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Motos_Areas_AreaId",
                table: "Motos",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Motos_Areas_AreaId1",
                table: "Motos",
                column: "AreaId1",
                principalTable: "Areas",
                principalColumn: "Id");
        }
    }
}
