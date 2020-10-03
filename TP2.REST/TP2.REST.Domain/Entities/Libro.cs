using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP2.REST.Domain.Entities
{
    public class Libro
    {
        private string isbnId;
        private string titulo;
        private string autor;
        private string editorial;
        private string edicion;
        private int stock;
        private string imagen;

        [Key]
        [Column(TypeName = "varchar(50)")]
        public string ISBN { get => isbnId; set => isbnId = value; }

        [Required]
        [Column(TypeName = "varchar(45)")]
        public string Titulo { get => titulo; set => titulo = value; }

        [Required]
        [Column(TypeName = "varchar(45)")]
        public string Autor { get => autor; set => autor = value; }

        [Required]
        [Column(TypeName = "varchar(45)")]
        public string Editorial { get => editorial; set => editorial = value; }

        [Required]
        [Column(TypeName = "varchar(45)")]
        public string Edicion { get => edicion; set => edicion = value; }

        public int Stock { get => stock; set => stock = value; }

        [Required]
        [Column(TypeName = "varchar(45)")]
        public string Imagen { get => imagen; set => imagen = value; }

        public override string ToString()
        {
            return "ISBN: " + ISBN + "\n" +
                   "Título: " + Titulo + "\n" +
                   "Autor: " + Autor + "\n" +
                   "Editorial: " + Editorial + "\n" +
                   "Edición: " + Edicion + "\n" +
                   "Stock: " + Stock;
        }

        public string InformarLibro()
        {
            return "ISBN: " + ISBN + "\n" +
                   "Título: " + Titulo + "\n" +
                   "Autor: " + Autor + "\n" +
                   "Editorial: " + Editorial + "\n" +
                   "Edición: " + Edicion;
        }
    }
}
