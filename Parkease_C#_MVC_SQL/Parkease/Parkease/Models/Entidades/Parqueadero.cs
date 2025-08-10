using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parkease.Models.Entidades
{
    [Table("parqueadero")]
    public class Parqueadero
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdParqueadero { get; set; }

        [Required]
        [StringLength(45)]
        public string NombreParq { get; set; }

        [Required]
        [StringLength(45)]
        public string DireccionParq { get; set; }

        [Required]
        public int TelefonoParq { get; set; }

        [Required]
        public int PrecioParq { get; set; }
    }
}