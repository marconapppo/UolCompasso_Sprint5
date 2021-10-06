using Microsoft.EntityFrameworkCore.Migrations;

namespace Sprint05_API_Cidade.Migrations
{
    public partial class CriandoTabelaCidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTE_CIDADE_CIDADE_ID",
                table: "CLIENTE");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_CIDADE_Id",
                table: "CIDADE");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CLIENTE",
                table: "CLIENTE",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CIDADE",
                table: "CIDADE",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTE_CIDADE_ID",
                table: "CLIENTE",
                column: "CIDADE_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CLIENTE_CIDADE_CIDADE_ID",
                table: "CLIENTE",
                column: "CIDADE_ID",
                principalTable: "CIDADE",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTE_CIDADE_CIDADE_ID",
                table: "CLIENTE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CLIENTE",
                table: "CLIENTE");

            migrationBuilder.DropIndex(
                name: "IX_CLIENTE_CIDADE_ID",
                table: "CLIENTE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CIDADE",
                table: "CIDADE");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CIDADE_Id",
                table: "CIDADE",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CLIENTE_CIDADE_CIDADE_ID",
                table: "CLIENTE",
                column: "CIDADE_ID",
                principalTable: "CIDADE",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
