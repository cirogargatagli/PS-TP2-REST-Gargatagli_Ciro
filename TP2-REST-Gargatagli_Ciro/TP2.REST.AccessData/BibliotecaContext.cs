using Microsoft.EntityFrameworkCore;
using TP2.REST.Domain.Entities;

namespace TP2.REST.AccessData
{
    public class BibliotecaContext : DbContext
    {
        private DbSet<Cliente> cliente;
        private DbSet<Libro> libro;
        private DbSet<Alquiler> alquiler;
        private DbSet<EstadoAlquiler> estadoAlquiler;

        public DbSet<Cliente> Cliente { get => cliente; set => cliente = value; }
        public DbSet<Libro> Libro { get => libro; set => libro = value; }
        public DbSet<Alquiler> Alquiler { get => alquiler; set => alquiler = value; }
        public DbSet<EstadoAlquiler> EstadoAlquiler { get => estadoAlquiler; set => estadoAlquiler = value; }

        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Cargo libros a la tabla Libro
            modelBuilder.Entity<Libro>(entity =>
            {
                entity.ToTable("Libro");
                entity.HasData(new Libro
                {
                    ISBN = "8478884459",
                    Titulo = "Harry Potter y la piedra filosofal",
                    Autor = "J.K. Rowling",
                    Editorial = "Salamandra",
                    Edicion = "1997",
                    Stock = 10,
                    Imagen = "https://images.cdn2.buscalibre.com/fit-in/360x360/a2/9e/a29ebbd39810f964999f2a9f5f773af8.jpg"
                });
                entity.HasData(new Libro
                {
                    ISBN = "6071121639",
                    Titulo = "Las ventajas de ser invisible",
                    Autor = "Stephen Chbosky",
                    Editorial = "Alfaguara",
                    Edicion = "2013",
                    Stock = 7,
                    Imagen = "https://images-na.ssl-images-amazon.com/images/I/514XOeteoRL._SX319_BO1,204,203,200_.jpg"
                });
                entity.HasData(new Libro
                {
                    ISBN = "9789876295116",
                    Titulo = "Las Venas Abiertas De America Latina",
                    Autor = "Eduardo Galeano",
                    Editorial = "SIGLO XXI EDITORES",
                    Edicion = "2014",
                    Stock = 9,
                    Imagen = "https://contentv2.tap-commerce.com/cover/large/9789876295116_1.jpg?id_com=1113"
                });
                entity.HasData(new Libro
                {
                    ISBN = "9788416709823",
                    Titulo = "Ramones",
                    Autor = "Joe Padilla",
                    Editorial = "RESERVOIR BOOKS",
                    Edicion = "2017",
                    Stock = 15,
                    Imagen = "https://www.isadoralibros.com.uy/sitio/repo/img/9788417125011.jpg"
                });
                entity.HasData(new Libro
                {
                    ISBN = "9789872813635",
                    Titulo = "Ricky de Flema, El último Punk",
                    Autor = "Sebastián Duarte",
                    Editorial = "Sebastián Duarte, Sr",
                    Edicion = "2016",
                    Stock = 10,
                    Imagen = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcTuZGW7GD3BU0e-JZs2CocWnq28bBt3qS8Rtw&usqp=CAU"
                });
                entity.HasData(new Libro
                {
                    ISBN = "9789874109019",
                    Titulo = "El Juguete Rabioso",
                    Autor = "Roberto Arlt",
                    Editorial = "EDITORIAL BARENHAUS",
                    Edicion = "2016",
                    Stock = 6,
                    Imagen = "https://image.isu.pub/181210203225-bdf0823d1bf285c49563674ba22812f3/jpg/page_1.jpg"
                });
                entity.HasData(new Libro
                {
                    ISBN = "9788491053538",
                    Titulo = "La conquista del pan",
                    Autor = "Piotr Kropotkin",
                    Editorial = "PENGUIN CLASICOS",
                    Edicion = "2017",
                    Stock = 13,
                    Imagen = "https://images-na.ssl-images-amazon.com/images/I/31XJ19CQG1L._SX311_BO1,204,203,200_.jpg"
                });
            });

            //Cargo estados a tabla EstadoAlquiler
            modelBuilder.Entity<EstadoAlquiler>(entity =>
            {
                entity.ToTable("EstadoAlquiler");
                entity.HasData(new EstadoAlquiler { EstadoAlquilerId = 1, Descripcion = "Reservado" });
                entity.HasData(new EstadoAlquiler { EstadoAlquilerId = 2, Descripcion = "Alquilado" });
                entity.HasData(new EstadoAlquiler { EstadoAlquilerId = 3, Descripcion = "Cancelado" });
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");
                entity.HasData(new Cliente
                {
                    ClienteId = 1,
                    Nombre = "Ciro",
                    Apellido = "Gargatagli",
                    DNI = "40394722",
                    Email = "ciroshaila@gmail.com"
                });
            });
        }
    }
}