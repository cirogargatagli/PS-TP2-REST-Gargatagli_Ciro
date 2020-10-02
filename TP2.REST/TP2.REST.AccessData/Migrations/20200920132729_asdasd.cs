using Microsoft.EntityFrameworkCore.Migrations;

namespace TP2.REST.AccessData.Migrations
{
    public partial class asdasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alquiler_Libro_LibroISBN",
                table: "Alquiler");

            migrationBuilder.DropIndex(
                name: "IX_Alquiler_LibroISBN",
                table: "Alquiler");

            migrationBuilder.DropColumn(
                name: "LibroISBN",
                table: "Alquiler");

            migrationBuilder.CreateIndex(
                name: "IX_Alquiler_ISBN",
                table: "Alquiler",
                column: "ISBN");

            migrationBuilder.AddForeignKey(
                name: "FK_Alquiler_Libro_ISBN",
                table: "Alquiler",
                column: "ISBN",
                principalTable: "Libro",
                principalColumn: "ISBN",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alquiler_Libro_ISBN",
                table: "Alquiler");

            migrationBuilder.DropIndex(
                name: "IX_Alquiler_ISBN",
                table: "Alquiler");

            migrationBuilder.AddColumn<string>(
                name: "LibroISBN",
                table: "Alquiler",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alquiler_LibroISBN",
                table: "Alquiler",
                column: "LibroISBN");

            migrationBuilder.AddForeignKey(
                name: "FK_Alquiler_Libro_LibroISBN",
                table: "Alquiler",
                column: "LibroISBN",
                principalTable: "Libro",
                principalColumn: "ISBN",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
