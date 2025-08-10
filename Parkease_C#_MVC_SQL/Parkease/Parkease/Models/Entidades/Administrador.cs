using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parkease.Models.Entidades
{
    [Table("administrador")]
    public class Administrador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAdministrador { get; set; }

        [Required]
        [StringLength(45)]
        public string PrimerNombre { get; set; }

        [Required]
        [StringLength(45)]
        public string PrimerApellido { get; set; }

        [Required]
        [StringLength(45)]
        [EmailAddress]
        public string CorreoAdmin { get; set; }

        [Required]
        public int DocumentoAdmin { get; set; }

        [Required]
        public int TelefonoAdmin { get; set; }

        [Required]
        [StringLength(45)]
        public string Direccion { get; set; }
    }
}
