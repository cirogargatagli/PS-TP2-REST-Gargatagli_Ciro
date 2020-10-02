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
                    Imagen = ""
                });
                entity.HasData(new Libro
                {
                    ISBN = "6071121639",
                    Titulo = "Las ventajas de ser invisible",
                    Autor = "Stephen Chbosky",
                    Editorial = "Alfaguara",
                    Edicion = "2013",
                    Stock = 7,
                    Imagen = ""
                });
                entity.HasData(new Libro
                {
                    ISBN = "9789876295116",
                    Titulo = "Las Venas Abiertas De America Latina",
                    Autor = "Eduardo Galeano",
                    Editorial = "SIGLO XXI EDITORES",
                    Edicion = "2014",
                    Stock = 9,
                    Imagen = ""
                });
                entity.HasData(new Libro
                {
                    ISBN = "9788416709823",
                    Titulo = "Ramones",
                    Autor = "Joe Padilla",
                    Editorial = "RESERVOIR BOOKS",
                    Edicion = "2017",
                    Stock = 15,
                    Imagen = ""
                });
                entity.HasData(new Libro
                {
                    ISBN = "9789872813635",
                    Titulo = "Ricky de Flema, El último Punk",
                    Autor = "Sebastián Duarte",
                    Editorial = "Sebastián Duarte, Sr",
                    Edicion = "2016",
                    Stock = 10,
                    Imagen = ""
                });
                entity.HasData(new Libro
                {
                    ISBN = "9789874109019",
                    Titulo = "El Juguete Rabioso",
                    Autor = "Roberto Arlt",
                    Editorial = "EDITORIAL BARENHAUS",
                    Edicion = "2016",
                    Stock = 6,
                    Imagen = ""
                });
                entity.HasData(new Libro
                {
                    ISBN = "9788491053538",
                    Titulo = "La conquista del pan",
                    Autor = "Piotr Kropotkin",
                    Editorial = "PENGUIN CLASICOS",
                    Edicion = "2017",
                    Stock = 13,
                    Imagen = ""
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

        }
    }
}