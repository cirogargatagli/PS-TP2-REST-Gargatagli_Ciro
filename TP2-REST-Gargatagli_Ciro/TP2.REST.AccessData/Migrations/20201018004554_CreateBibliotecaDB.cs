using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TP2.REST.AccessData.Migrations
{
    public partial class CreateBibliotecaDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<string>(type: "varchar(10)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(45)", nullable: false),
                    Apellido = table.Column<string>(type: "varchar(45)", nullable: false),
                    Email = table.Column<string>(type: "varchar(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "EstadoAlquiler",
                columns: table => new
                {
                    EstadoAlquilerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoAlquiler", x => x.EstadoAlquilerId);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "varchar(50)", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(45)", nullable: false),
                    Autor = table.Column<string>(type: "varchar(45)", nullable: false),
                    Editorial = table.Column<string>(type: "varchar(45)", nullable: false),
                    Edicion = table.Column<string>(type: "varchar(45)", nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    Imagen = table.Column<string>(type: "varchar(110)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.ISBN);
                });

            migrationBuilder.CreateTable(
                name: "Alquiler",
                columns: table => new
                {
                    AlquilerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteID = table.Column<int>(nullable: false),
                    ISBN = table.Column<string>(type: "varchar(50)", nullable: false),
                    EstadoID = table.Column<int>(nullable: false),
                    FechaAlquiler = table.Column<DateTime>(nullable: true),
                    FechaReserva = table.Column<DateTime>(nullable: true),
                    FechaDevolucion = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alquiler", x => x.AlquilerId);
                    table.ForeignKey(
                        name: "FK_Alquiler_Cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alquiler_EstadoAlquiler_EstadoID",
                        column: x => x.EstadoID,
                        principalTable: "EstadoAlquiler",
                        principalColumn: "EstadoAlquilerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alquiler_Libro_ISBN",
                        column: x => x.ISBN,
                        principalTable: "Libro",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "ClienteId", "Apellido", "DNI", "Email", "Nombre" },
                values: new object[] { 1, "Gargatagli", "40394722", "ciroshaila@gmail.com", "Ciro" });

            migrationBuilder.InsertData(
                table: "EstadoAlquiler",
                columns: new[] { "EstadoAlquilerId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Reservado" },
                    { 2, "Alquilado" },
                    { 3, "Cancelado" }
                });

            migrationBuilder.InsertData(
                table: "Libro",
                columns: new[] { "ISBN", "Autor", "Edicion", "Editorial", "Imagen", "Stock", "Titulo" },
                values: new object[,]
                {
                    { "8478884459", "J.K. Rowling", "1997", "Salamandra", "https://images.cdn2.buscalibre.com/fit-in/360x360/a2/9e/a29ebbd39810f964999f2a9f5f773af8.jpg", 10, "Harry Potter y la piedra filosofal" },
                    { "6071121639", "Stephen Chbosky", "2013", "Alfaguara", "https://images-na.ssl-images-amazon.com/images/I/514XOeteoRL._SX319_BO1,204,203,200_.jpg", 7, "Las ventajas de ser invisible" },
                    { "9789876295116", "Eduardo Galeano", "2014", "SIGLO XXI EDITORES", "https://contentv2.tap-commerce.com/cover/large/9789876295116_1.jpg?id_com=1113", 9, "Las Venas Abiertas De America Latina" },
                    { "9788416709823", "Joe Padilla", "2017", "RESERVOIR BOOKS", "https://www.isadoralibros.com.uy/sitio/repo/img/9788417125011.jpg", 15, "Ramones" },
                    { "9789872813635", "Sebastián Duarte", "2016", "Sebastián Duarte, Sr", "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcTuZGW7GD3BU0e-JZs2CocWnq28bBt3qS8Rtw&usqp=CAU", 10, "Ricky de Flema, El último Punk" },
                    { "9789874109019", "Roberto Arlt", "2016", "EDITORIAL BARENHAUS", "https://image.isu.pub/181210203225-bdf0823d1bf285c49563674ba22812f3/jpg/page_1.jpg", 6, "El Juguete Rabioso" },
                    { "9788491053538", "Piotr Kropotkin", "2017", "PENGUIN CLASICOS", "https://images-na.ssl-images-amazon.com/images/I/31XJ19CQG1L._SX311_BO1,204,203,200_.jpg", 13, "La conquista del pan" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alquiler_ClienteID",
                table: "Alquiler",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Alquiler_EstadoID",
                table: "Alquiler",
                column: "EstadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Alquiler_ISBN",
                table: "Alquiler",
                column: "ISBN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alquiler");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "EstadoAlquiler");

            migrationBuilder.DropTable(
                name: "Libro");
        }
    }
}
