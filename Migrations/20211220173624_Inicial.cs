using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App1.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Email_Cliente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Id_Cliente = table.Column<int>(type: "int", nullable: false),
                    Nome_Cliente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    ClienteEmail_Cliente = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Email_Cliente);
                    table.ForeignKey(
                        name: "FK_Clientes_Clientes_ClienteEmail_Cliente",
                        column: x => x.ClienteEmail_Cliente,
                        principalTable: "Clientes",
                        principalColumn: "Email_Cliente");
                });

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    Id_Contato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mensagem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.Id_Contato);
                });

            migrationBuilder.CreateTable(
                name: "Destino",
                columns: table => new
                {
                    Id_Destino = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Destino = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Preco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hora_Voo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DestinoId_Destino = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destino", x => x.Id_Destino);
                    table.ForeignKey(
                        name: "FK_Destino_Destino_DestinoId_Destino",
                        column: x => x.DestinoId_Destino,
                        principalTable: "Destino",
                        principalColumn: "Id_Destino");
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    Id_Compra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email_Cliente = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Id_Destino = table.Column<int>(type: "int", nullable: false),
                    FormaPagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_Compra = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.Id_Compra);
                    table.ForeignKey(
                        name: "FK_Compra_Clientes_Email_Cliente",
                        column: x => x.Email_Cliente,
                        principalTable: "Clientes",
                        principalColumn: "Email_Cliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compra_Destino_Id_Destino",
                        column: x => x.Id_Destino,
                        principalTable: "Destino",
                        principalColumn: "Id_Destino",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ClienteEmail_Cliente",
                table: "Clientes",
                column: "ClienteEmail_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_Email_Cliente",
                table: "Compra",
                column: "Email_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_Id_Destino",
                table: "Compra",
                column: "Id_Destino");

            migrationBuilder.CreateIndex(
                name: "IX_Destino_DestinoId_Destino",
                table: "Destino",
                column: "DestinoId_Destino");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Destino");
        }
    }
}
