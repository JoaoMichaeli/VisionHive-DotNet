using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vision.Hive.Migrations
{
    /// <inheritdoc />
    public partial class InitialTesteCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Motos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Placa = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: true),
                    Chassi = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: true),
                    NumeroMotor = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: true),
                    Prioridade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AreaId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    AreaId1 = table.Column<Guid>(type: "RAW(16)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motos_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motos_Areas_AreaId1",
                        column: x => x.AreaId1,
                        principalTable: "Areas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motos_AreaId",
                table: "Motos",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Motos_AreaId1",
                table: "Motos",
                column: "AreaId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motos");

            migrationBuilder.DropTable(
                name: "Areas");
        }
    }
}
