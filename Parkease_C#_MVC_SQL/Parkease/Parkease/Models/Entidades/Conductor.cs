using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parkease.Models.Entidades
{
    [Table("conductor")]
    public class Conductor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idConductor { get; set; }

        [Required]
        [StringLength(45)]
        public string primerNombre { get; set; } = string.Empty;

        [Required]
        [StringLength(45)]
        public string primerApellido { get; set; } = string.Empty;

        [Required]
        public long numDocu { get; set; }

        [Required]
        [StringLength(45)]
        [EmailAddress]
        public string correo { get; set; } = string.Empty;

        [Required]
        public int edad { get; set; }

        [Required]
        [StringLength(45)]
        public string placa { get; set; } = string.Empty;

        [Required]
        [StringLength(45)]
        public string contrasena { get; set; } = string.Empty;

        [Required]
        [Compare("contrasena", ErrorMessage = "Las contraseñas no coinciden.")]
        public string confirmaContra { get; set; } = string.Empty;


        public ICollection<Reserva>? Reservas { get; set; }
    }
}