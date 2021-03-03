using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class KullaniciModeli : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departmanlar_Firmalar_FirmaId",
                table: "Departmanlar");

            migrationBuilder.DropIndex(
                name: "IX_Departmanlar_FirmaId",
                table: "Departmanlar");

            migrationBuilder.DropColumn(
                name: "FirmaId",
                table: "Departmanlar");

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.AddColumn<int>(
                name: "FirmaId",
                table: "Departmanlar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departmanlar_FirmaId",
                table: "Departmanlar",
                column: "FirmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departmanlar_Firmalar_FirmaId",
                table: "Departmanlar",
                column: "FirmaId",
                principalTable: "Firmalar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
