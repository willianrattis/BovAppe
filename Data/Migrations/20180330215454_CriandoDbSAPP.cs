using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SAPP.Data.Migrations
{
    public partial class CriandoDbSAPP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CPF = table.Column<string>(maxLength: 14, nullable: false),
                    Nome = table.Column<string>(maxLength: 30, nullable: false),
                    Senha = table.Column<string>(maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fazendas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ClienteId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fazendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fazendas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    DtCompra = table.Column<DateTime>(nullable: true),
                    DtVenda = table.Column<DateTime>(nullable: true),
                    FazendaId = table.Column<int>(nullable: true),
                    Tag = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animais_Fazendas_FazendaId",
                        column: x => x.FazendaId,
                        principalTable: "Fazendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pesos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AnimalId = table.Column<int>(nullable: false),
                    Dtpesagem = table.Column<DateTime>(nullable: true),
                    Quilos = table.Column<float>(maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pesos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pesos_Animais_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Animais_FazendaId",
                table: "Animais",
                column: "FazendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Fazendas_ClienteId",
                table: "Fazendas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pesos_AnimalId",
                table: "Pesos",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Pesos");

            migrationBuilder.DropTable(
                name: "Animais");

            migrationBuilder.DropTable(
                name: "Fazendas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
