using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parkease.Models.Entidades
{
    [Table("vehiculo")]
    public class Vehiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idVehiculo { get; set; }

        [Required]
        [StringLength(15)]
        public string colorVeh { get; set; }

        [Required]
        [StringLength(45)]
        public string tipoVeh { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "La placa no puede tener más de 10 caracteres.")]
        [RegularExpression(@"^[A-Z0-9-]+$", ErrorMessage = "La placa solo puede contener letras mayúsculas, números y guiones.")]
        public string placaVeh { get; set; }

        [Required]
        [StringLength(15)]
        public string modeloVeh { get; set; }

        [Required]
        [StringLength(30)]
        public string marcaVeh { get; set; }

        [Column("imagenReserva")]
        [StringLength(255)] // Cambiar a VARCHAR(255) en MySQL en lugar de byte[]
        public string? imagenReserva { get; set; }

        // ✅ Especificar la clave foránea correctamente
        [Required]
        [ForeignKey("Conductor")]
        [Column("idConductor")]
        public int idConductor { get; set; }

        public Conductor? Conductor { get; set; } // Relación con la tabla Conductor
    }
}