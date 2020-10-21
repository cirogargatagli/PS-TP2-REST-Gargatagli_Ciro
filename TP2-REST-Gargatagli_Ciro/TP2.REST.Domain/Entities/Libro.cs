using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP2.REST.Domain.Entities
{
    public class Libro
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        public string ISBN { get; set; }

        [Required]
        [Column(TypeName = "varchar(45)")]
        public string Titulo { get; set; }

        [Required]
        [Column(TypeName = "varchar(45)")]
        public string Autor { get; set; }

        [Required]
        [Column(TypeName = "varchar(45)")]
        public string Editorial { get; set; }

        [Required]
        [Column(TypeName = "varchar(45)")]
        public string Edicion { get; set; }

        public int Stock { get; set; }

        [Required]
        [Column(TypeName = "varchar(110)")]
        public string Imagen { get; set; }
    }
}
